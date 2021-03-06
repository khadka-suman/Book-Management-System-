using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Book.Areas.Identity.Data;
using Book.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Book.Controllers
{
   
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager; 

        public BooksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "User,Admin")]
        
        public async Task<IActionResult> Index()
        {
          

            var applicationDbContext = _context.Books.Include(b => b.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET:Details
       [Authorize(Roles = "Admin,Developer,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.BooksId == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET:Create
        [HttpGet]
       [Authorize(Roles ="User, Admin")]
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Categories, "Id", "Id");
            ViewData["Name"] = new SelectList(_context.Categories, "Name", "Name");
            return View();
        }

        // POST:Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User, Admin")]

        public async Task<IActionResult> Create([Bind("BooksId,Bookname,Bookdetails,Bookgenre,Id, Name")] Books books)
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(userid);
            books.User = user;
            var FirstName = user.firstname;
            var LastName = user.lastname;
            _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            ViewData["Id"] = new SelectList(_context.Categories, "Id", "Id", books.Id);
            ViewData["Name"] = new SelectList(_context.Categories, "Name", "Name", books.Id);
        }
        
        // GET:Edit
        [HttpGet]
        [Authorize(Roles = "Admin,Developer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Categories, "Id", "Id", books.Id);
            ViewData["Name"] = new SelectList(_context.Categories, "Name", "Name", books.Id);
            return View(books);
        }

        // POST:Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Developer")]
        public async Task<IActionResult> Edit (int id, [Bind("BooksId,Bookname,Bookdetails,Bookgenre,Id, Name")] Books books)
        {
            if (id != books.BooksId)
            {
                return NotFound();
            }

          
            var userid = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(userid);
            books.User = user;
            var FirstName = user.firstname;
            var LastName = user.lastname;

            //
                    _context.Update(books);
                    await _context.SaveChangesAsync();
               
            ViewData["Id"] = new SelectList(_context.Categories, "Id","Id", books.Id);
            ViewData["Name"] = new SelectList(_context.Categories,"Name", "Name", books.Id);
            return RedirectToAction("Index");
        }

        // GET:Delete
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.BooksId == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST:Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Books'  is null.");
            }
            var books = await _context.Books.FindAsync(id);
            if (books != null)
            {
                _context.Books.Remove(books);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
