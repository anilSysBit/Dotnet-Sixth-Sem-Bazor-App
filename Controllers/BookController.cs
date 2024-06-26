using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Data;
using MyMvcApp.Models;
using MyMvcApp.Data;

namespace MyMvcApp.Controllers;

public class BookController : Controller{
    private ApplicationDbContext _db;

    public BookController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index(){
        var books = _db.Books.ToList();

        return View(books);
    }

    public IActionResult Create(){
        BooksEntity newBook = new BooksEntity{Id = 0};
        return View("Create",newBook);
    }

    [HttpPost]
    public IActionResult CreateBook(BooksEntity book){
        _db.Books.Add(book);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id){
        var book = _db.Books.Find(id);
        if(book == null){
            return NotFound();
        }
        _db.Books.Remove(book);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }

    public ActionResult Update(int id){
        var book = _db.Books.Find(id);
        if(book == null){
            return NotFound();
        }
        return View("Create",book);
    }

    public ActionResult UpdateBook(BooksEntity book){
        if(ModelState.IsValid){
            _db.Books.Update(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Create",book);
    }

}