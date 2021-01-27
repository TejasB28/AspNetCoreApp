using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Enums
{
    public enum LanguageEnum
    {
        [Display(Name ="Hindi Language")]
        Hindi = 10,
        [Display(Name = "Marathi Language")]
        Marathi = 11,
        [Display(Name = "English Language")]
        Engilsh = 12,
        [Display(Name = "French Language")]
        French = 13,
        [Display(Name = "Chinese Language")]
        Chinese = 14,
        [Display(Name = "Tamil Language")]
        Tamil = 15,
        [Display(Name = "Janapanese Language")]
        Janapanese = 16
    }
}
