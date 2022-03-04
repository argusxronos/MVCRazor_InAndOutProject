using System;
using System.Collections.Generic;
using inAndOut.Data;
using inAndOut.Models;
using Microsoft.AspNetCore.Mvc;

namespace inAndOut.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Book> objList = _db.Book;
            return View(objList);
        }

        // GET: /<controller>/
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Book obj)
        {
            if (ModelState.IsValid)
            {
                _db.Book.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Book created successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: update
        public IActionResult Update(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Book.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: Update
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(Book obj)
        {
            if (ModelState.IsValid)
            {
                _db.Book.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Book updated successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                ModelState.AddModelError("CustomError", "No se encontró el registro.");
                return NotFound();
            }
            var obj = _db.Book.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST-Delete
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(int id)
        {
            var obj = _db.Book.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Book.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Book deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
