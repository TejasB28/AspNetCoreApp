using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)   // connect with base constructor
            :base(options)
        {

        }

        public DbSet<Books> Books { get; set; }  // Entity class and name that we specify here that will be a table name.

        public DbSet<Language> Language { get; set; }
        // configuaration database
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.;Database=BookStore;Integrated Security=True;"); //connection string
        //    base.OnConfiguring(optionsBuilder);     
        //}
        // If we are written our connection string in startup file there is no need to define it here or VICE VERSA
    }
}
