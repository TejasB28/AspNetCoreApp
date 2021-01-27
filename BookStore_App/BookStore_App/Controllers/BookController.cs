using BookStore_App.Models;
using BookStore_App.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public ViewResult AddNewBook(bool isSuccess = false,int bookId = 0)
        {
            var model = new BookModel()
            {
                // Language = "2"
            };

            // var group1 = new SelectListGroup() { Name="Group 1"};           // Create instance of SelectListGroup
          

            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text="Hindi",Value="1"},
            //    new SelectListItem(){Text="Marathi ",Value="2"},
            //    new SelectListItem(){Text="English",Value="3"},
            //    new SelectListItem(){Text="French",Value="4"},
            //    new SelectListItem(){Text="Chinese",Value="5"},
            //    new SelectListItem(){Text="Tamil",Value="6"},
            //    new SelectListItem(){Text="Janapanese",Value="7"},
            //};

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            Title = "Add Book";
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }

            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text="Hindi",Value="1"},
            //    new SelectListItem(){Text="Marathi ",Value="2"},
            //    new SelectListItem(){Text="English",Value="3"},
            //    new SelectListItem(){Text="French",Value="4"},
            //    new SelectListItem(){Text="Chinese",Value="5"},
            //    new SelectListItem(){Text="Tamil",Value="6"},
            //    new SelectListItem(){Text="Janapanese",Value="7"},
            //};

            ModelState.AddModelError("", "This is My Custom Error Messages");
            ModelState.AddModelError("", "This is My second Custom Error Messages");
            return View();
        }

        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel() { Id = 1, Text = "Hindi"},
                new LanguageModel() { Id = 2, Text = "Marathi"},
                new LanguageModel() { Id = 3, Text = "English"}
            };
        }
    }
}


//dynamic views
//dynamic data = new ExpandoObject();
//data.book = _bookRepository.GetBookById(id);
//data.name = "Tejas";

//Using SelectListItem 
//ViewBag.Language = GetLanguage().Select(x => new SelectListItem()
//{
//    Text = x.Text,
//    Value=x.Id.ToString()
//}).ToList();
