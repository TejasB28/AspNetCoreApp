using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BookStore_App.Enums;

namespace BookStore_App.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100,MinimumLength =5)]
        [Required(ErrorMessage ="Please enter the title of the book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter author name")]
        public string Author { get; set; }
        public int Price { get; set; }
        [StringLength(300)]
        public string description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage ="Please choose the language of book")]
        public int LanguageId { get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage = "Please enter the total pages")]
        [Display(Name = "Total Pages of Book")]
        public int? TotalPages { get; set; }  
    }
}

//Enum for language
//[Required(ErrorMessage = "Please choose the languages of book")]
//public LanguageEnum LanguageEnum { get; set; }