using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LibraryMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryMVCApp.Controllers
{
    [Route("[controller]")]
    public class BookController : Controller
    {
        BookRepo brObj = new BookRepo(new LibraryContext());
        public async Task<IActionResult> Index()
        {
            List<Book> books = await brObj.GetAll();
            return View(books);
        }

        [Route("AddBook")]
        public IActionResult Create()
        {
            Console.Write("hi");
            return View();
        }

        [HttpPost]
        [Route("AddBookForm")]
        public IActionResult Create(Book book)
        {
            bool isAdded = brObj.Add(book);
            if(isAdded)
                return RedirectToAction("Index");
            return Content("Could'nt add book");
        }

        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            bool isRemoved = brObj.Remove(id);
            if(isRemoved)
                return RedirectToAction("Index");
            return Content("Could'nt remove book");
        }

        [Route("EditBook")]
        public async Task<IActionResult> EditBook(int id)
        {
            Book book = await brObj.GetById(id);
            return View(book);
        }

        [HttpPost]
        [Route("EditBookForm")]
        public IActionResult Edit(Book book)
        {
            bool isUpdated = brObj.Update(book.Id,book);
            if(isUpdated)
                return RedirectToAction("Index");
            return Content("Could'nt update book");
        }
    }
}