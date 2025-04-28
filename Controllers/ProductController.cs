using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChadWare.Models;
using ChadWare.Services;
using SQLite;

namespace ChadWare.Controllers
{
    internal class ProductController
    {
        private readonly SQLiteAsyncConnection _database;

        public ProductController()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "chadware.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Product>().Wait();
        }

        public async Task<List<Product>> SearchProducts(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return await _database.Table<Product>().ToListAsync();
            }

            searchQuery = searchQuery.ToLower();
            return await _database.Table<Product>()
                .Where(p => p.Name.ToLower().Contains(searchQuery) ||
                           p.Description.ToLower().Contains(searchQuery) ||
                           p.Category.ToLower().Contains(searchQuery))
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _database.Table<Product>().ToListAsync();
        }

        public async Task<Product> GetProductById(long id)
        {
            return await _database.Table<Product>().Where(p => p.ProductID == id).FirstOrDefaultAsync();
        }

        public async Task<int> AddProduct(Product product)
        {
            return await _database.InsertAsync(product);
        }
    }
}
