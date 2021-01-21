using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public int TotalPages { get; set; }
    }
}