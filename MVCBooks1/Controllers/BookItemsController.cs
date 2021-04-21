using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVCBooks1.Models;

namespace MVCBooks1.Controllers
{
    public class BookItemsController : Controller
    {
        private readonly BookContext _context;

        public BookItemsController(BookContext context)
        {
            _context = context;
        }

        // GET: BookItems
        public async Task<IActionResult> Index()
        {
            string select = $@"
                SELECT *, dbo.IsSubscribed({HttpContext.Session.GetInt32("UserId")}, BookId) Subscribed 
                FROM dbo.Book";

            return View(await _context.BookItems.FromSqlRaw(select).ToListAsync());
        }

        // GET: BookItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookItem = await _context.BookItems
                .FirstOrDefaultAsync(m => m.bookId == id);
            if (bookItem == null)
            {
                return NotFound();
            }

            return View(bookItem);
        }

        // GET: BookItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bookId,name,text,price")] BookItem bookItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookItem);
        }

        // GET: BookItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookItem = await _context.BookItems.FindAsync(id);
            if (bookItem == null)
            {
                return NotFound();
            }
            return View(bookItem);
        }

        // POST: BookItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bookId,name,text,price")] BookItem bookItem)
        {
            if (id != bookItem.bookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookItemExists(bookItem.bookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookItem);
        }

        // GET: BookItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookItem = await _context.BookItems
                .FirstOrDefaultAsync(m => m.bookId == id);
            if (bookItem == null)
            {
                return NotFound();
            }

            return View(bookItem);
        }

        // POST: BookItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookItem = await _context.BookItems.FindAsync(id);
            _context.BookItems.Remove(bookItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookItemExists(int id)
        {
            return _context.BookItems.Any(e => e.bookId == id);
        }

        public async Task<IActionResult> BookSubscribe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string sql = "EXEC dbo.BookSubscribe @BookId, @UserId";

            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters    
                new SqlParameter { ParameterName = "@BookId", Value = id },
                new SqlParameter { ParameterName = "@UserId", Value = HttpContext.Session.GetInt32("UserId") }
            };

            _context.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> BookUnsubscribe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string sql = "EXEC dbo.BookUnsubscribe @BookId, @UserId";

            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters    
                new SqlParameter { ParameterName = "@BookId", Value = id },
                new SqlParameter { ParameterName = "@UserId", Value = HttpContext.Session.GetInt32("UserId") }
            };

            _context.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return RedirectToAction(nameof(Index));
        }
    }
}
