using BookStore_App.Data;
using BookStore_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext _context = null;      //instance of context class for database
  
        public LanguageRepository(BookStoreContext context)         // Dependancy Injection, as we are adds the context in startup it will resolve it automatically
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.Language.Select(x => new LanguageModel()
            {
                Id=x.Id,
                Description=x.Description,
                Name=x.Name
            }).ToListAsync();
        }
    }
}
