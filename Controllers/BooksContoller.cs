using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Book.Models;
using Book.Areas.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Book.Areas.Identity.Data;


namespace Book.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        public BooksController(ApplicationDbContext db)
            

       
        {
          
        
                   _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Books> objBooksList = _db.Books.ToList();
            return View(objBooksList);

        }

        //GET
        [HttpGet]
       
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        

        public IActionResult Create(Books obj)
        {
            if(ModelState.IsValid)
            {

            
            _db.Books.Add(obj);
            _db.SaveChanges();
            return View ("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Edit(int? BookId)
        {
            if (BookId == null || BookId == 0)
            {
                return NotFound();

            }
            var BooksFromDb = _db.Books.Find(BookId);
            if (BooksFromDb == null)
            {
                return NotFound();
            }
            return View(BooksFromDb);

        }
        //GET Details
       public async Task<IActionResult> Details(int? BookId)
        {
            if (BookId == null || BookId == 0)
            {
                return NotFound();
            }
            var Books = await _db.Books
                .FirstOrDefaultAsync(u => u.BookId == BookId);
            if (Books == null)
            {
                return NotFound();
            }
            return View(Books);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Books obj)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Books Updates Successfully";
                return RedirectToAction("Index");

            }
            return View(obj);

        }


        //GET
        public IActionResult Delete(int? BookId)
        {
            if (BookId == null || BookId == 0)
            {
                return NotFound();
            }
            var BooksFromDb = _db.Users.Find(BookId);
            if (BooksFromDb == null)
            {
                return NotFound();
            }
            return View(BooksFromDb);
        }


        //POST  
        [HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? BookId)
        {
            var obj = _db.Books.Find(BookId);
            if (obj == null)
            {
                return NotFound();
            }
            {
                _db.Books.Remove(obj);
                _db.SaveChanges();
                TempData["sucess"] = "Book deleted Sucessfully";
                return RedirectToAction("Index");
            }
        }
    }
}
