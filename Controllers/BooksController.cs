using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Book.Models;
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
            return RedirectToAction ("Index");
            }
            return View(obj);
        }
        //GET
        [HttpGet]
        [HttpGet, ActionName("Edit")]
        public IActionResult Edit(int? BooksId)
        {
            if (BooksId == null || BooksId == 0)
            {
                return NotFound();

            }
            var BooksFromDb = _db.Books.Find(BooksId);
            if (BooksFromDb == null)
            {
                return NotFound();
            }
            return View(BooksFromDb);
        }


        //Post
        [HttpPost]
        [HttpPost, ActionName("Edit")]
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
        //GET Details
        [HttpGet]
       public async Task<IActionResult> Details(int? BooksId)
        {
            if (BooksId == null || BooksId == 0)
            {
                return NotFound();
            }
            var Books = await _db.Books
                .FirstOrDefaultAsync(u => u.BooksId == BooksId);
            if (Books == null)
            {
                return NotFound();
            }
            return View(Books);
        }

       


        //GET
        [HttpGet]
        public IActionResult Delete(int? BooksId)
        {
            if (BooksId == null || BooksId == 0)
            {
                return NotFound();
            }
            var BooksFromDb = _db.Users.Find(BooksId);
            if (BooksFromDb == null)
            {
                return NotFound();
            }
            return View(BooksFromDb);
        }


        //POST  
        [HttpPost]
        [HttpPost, ActionName("Delete")]
        
        public IActionResult DeletePost(int? BooksId)
        {
            var obj = _db.Books.Find(BooksId);
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
