using BookStore_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title,string author)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(author)).ToList();
        }

        public List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id = 1,Title = "MVC",Author="tejas",Price=450},
                new BookModel(){Id = 2,Title = "C#",Author="Vijay",Price=500},
                new BookModel(){Id = 3,Title = "Java",Author="James",Price=550},
                new BookModel(){Id = 4,Title = ".net",Author="ajay",Price=810},
                new BookModel(){Id = 5,Title = "PHP",Author="Korth",Price=350},
            };
        }
    }
}
