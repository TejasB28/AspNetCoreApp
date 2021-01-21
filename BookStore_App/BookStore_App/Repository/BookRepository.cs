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
                new BookModel(){Id = 1,Title = "MVC",Author="tejas",Price=450,description="This is description of MVC Book",Category="Framework",Language="English",TotalPages=890},
                new BookModel(){Id = 2,Title = "C#",Author="Vijay",Price=500,description="This is description of C# Book",Category="Programming",Language="English",TotalPages=1300},
                new BookModel(){Id = 3,Title = "Java",Author="James",Price=550,description="This is description of Java Book",Category="Programming",Language="English",TotalPages=730},
                new BookModel(){Id = 4,Title = ".net",Author="ajay",Price=810,description="This is description of .net Book",Category="Programming",Language="English",TotalPages=550},
                new BookModel(){Id = 5,Title = "PHP",Author="Korth",Price=350,description="This is description of PHP Book",Category="Programming",Language="English",TotalPages=900},
                new BookModel(){Id = 6,Title = "Azure Devops",Author="splashgain",Price=740,description="This is description of Azure Devops Book",Category="Cloud",Language="English",TotalPages=1500},
                new BookModel(){Id = 7,Title = "DBMS",Author="Korth",Price=950,description="This is description of DBMS Book",Category="Database",Language="English",TotalPages=350},
            };
        }
    }
}
