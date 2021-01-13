using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Controllers
{
    public class HomeController : Controller
    {
        public string Index()       //Action Method and It is default name conventions for MVC applications.
        {
            return "Tejas";
        }
    }
}
