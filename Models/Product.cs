using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ChadWare.Models
{
    [Table("Product")]
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public long ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public int Stock { get; set; }

        public bool InStock { get; set; }
        public string Category { get; set; } = string.Empty;  

        public Product() { }

        public Product(int id, string name, string description, string category, decimal price, string imageUrl, int stock)
        {
            ProductID = id;
            Name = name;
            Description = description;
            Price = price;
            Image = imageUrl;
            Stock = stock;
            Category = category;
            InStock = true;
        }
    }
}
