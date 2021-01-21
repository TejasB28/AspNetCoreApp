using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using BookStore_App.Models;

namespace BookStore_App.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string CustomProperty { get; set; }

        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public BookModel Book { get; set; }

        public ViewResult Index()       //Action Method and It is default name conventions for MVC applications.
        {
            CustomProperty = "Custom value";
            Title = "Home";

            Book = new BookModel() { Id = 1,Title="ASP.Net Core" };
            return View();
        }

        public ViewResult AboutUs()
        {
            Title = "About us";
            return View();
        }

        public ViewResult ContactUs()
        {
            Title = "Contact us";
            return View();
        }
    }
}




// @viewbag

//  ViewBag.Title = "Tejas";

// for annonymous type

//dynamic data = new ExpandoObject();
// data.Id = 1;
// data.name = "Tejas";
// ViewBag.Data = data;

// For object
// ViewBag.Type = new BookModel() { Id = 5, Author = "tejas author" };


//View data
//ViewData["property1"] = "Tejas Bora";

//ViewData["book"] = new BookModel() {Author="Tejas",Id=1 };
