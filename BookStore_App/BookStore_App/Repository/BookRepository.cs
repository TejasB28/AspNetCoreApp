using BookStore_App.Data;
using BookStore_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;      //instance of context class for database

        public BookRepository(BookStoreContext context)         // Dependancy Injection, as we are adds the context in startup it will resolve it automatically
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()           //create object of properties that we want to fetch
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                description = model.description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl=model.BookPdfUrl
            };

            newBook.bookGallery = new List<BookGallery>();      // List For Adding Multiple Images

            foreach (var file in model.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery() { 
                    Name=file.Name,
                    URL=file.URL
                });
            }

            await _context.Books.AddAsync(newBook);            // add new data to context
            await _context.SaveChangesAsync();                 // For save all the changes if we use this method then only app hits db.

            return newBook.Id;                      // here we return Id that are associated
        }
        // after execution of the record savechanges() method can create Id for this record and that will be associated with the newBook object.
        
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks =await _context.Books.ToListAsync();
            if (allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    { 
                        Title=book.Title,
                        Author=book.Author,
                        description=book.description,
                        Category=book.Category,
                        TotalPages=book.TotalPages,
                        Id=book.Id,
                        LanguageId=book.LanguageId,
                        Price=book.Price,
                        CoverImageUrl=book.CoverImageUrl
                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Title = book.Title,
                    Author = book.Author,
                    description = book.description,
                    Category = book.Category,
                    TotalPages = book.TotalPages,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Price = book.Price,
                    CoverImageUrl = book.CoverImageUrl,
                    Gallery = book.bookGallery.Select(g => new GalleryModel() {
                        Id=g.Id,
                        Name=g.Name,
                        URL=g.URL
                    }).ToList(),
                    BookPdfUrl=book.BookPdfUrl
                }).FirstOrDefaultAsync();
            //_context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();  for apply some condition
        }

        public List<BookModel> SearchBook(string title,string author)
        {
            return null;
            // return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(author)).ToList();
        }
    }
}






//Dummy DataSource
//public List<BookModel> DataSource()
//{
//    return new List<BookModel>()
//    {
//        new BookModel(){Id = 1,Title = "MVC",Author="tejas",Price=450,description="This is description of MVC Book",Category="Framework",Language="English",TotalPages=890},
//        new BookModel(){Id = 2,Title = "C#",Author="Vijay",Price=500,description="This is description of C# Book",Category="Programming",Language="English",TotalPages=1300},
//        new BookModel(){Id = 3,Title = "Java",Author="James",Price=550,description="This is description of Java Book",Category="Programming",Language="English",TotalPages=730},
//        new BookModel(){Id = 4,Title = ".net",Author="ajay",Price=810,description="This is description of .net Book",Category="Programming",Language="English",TotalPages=550},
//        new BookModel(){Id = 5,Title = "PHP",Author="Korth",Price=350,description="This is description of PHP Book",Category="Programming",Language="English",TotalPages=900},
//        new BookModel(){Id = 6,Title = "Azure Devops",Author="splashgain",Price=740,description="This is description of Azure Devops Book",Category="Cloud",Language="English",TotalPages=1500},
//        new BookModel(){Id = 7,Title = "DBMS",Author="Korth",Price=950,description="This is description of DBMS Book",Category="Database",Language="English",TotalPages=350},
//    };
//}
