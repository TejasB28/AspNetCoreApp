using BookStore_App.Models;
using BookStore_App.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        [ViewData]
        public string Title { get; set; }

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;       //dependancy injection and it is resolved from StartUp.cs file
        }

        public async Task<ViewResult> GetAllBooks()
        {
            Title = "All Books";
            var data =await _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("book-details/{id}",Name ="BookdetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data =await _bookRepository.GetBookById(id);
            Title = "Book Detail - " +data.Title;
            return View(data);
        }

        public ViewResult SearchBook(string bookname, string authorname)
        {
            var data = _bookRepository.SearchBook(bookname, authorname);
            return View();
        }

        public ViewResult AddNewBook(bool isSuccess = false,int bookId=0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            Title = "Add Book";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            int id =await _bookRepository.AddNewBook(bookModel);
            if(id>0)
            {
                return RedirectToAction(nameof(AddNewBook),new { isSuccess=true , bookId = id});
            }
            return View();
        }
    }
}


//dynamic views
//dynamic data = new ExpandoObject();
//data.book = _bookRepository.GetBookById(id);
//data.name = "Tejas";
