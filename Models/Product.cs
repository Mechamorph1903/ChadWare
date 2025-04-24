using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ChadWare.Models
{
    [Table("Product")]
    internal class Product
    {
        [PrimaryKey, AutoIncrement]
        public long ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }    

        public Product(int id, string name, string description, string category, decimal price, string imageUrl, int stock)
        {
            ProductID = id;
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
            Stock = stock;
            Category = category;
        }
    }
}
