using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgrest.Attributes;

namespace ChadWare.Models
{
    [Table("Products")]                    
    public class Product
    {
        [PrimaryKey("productID", false)]   // your PK column
        public long ProductID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("image")]
        public string Image { get; set; }

        [Column("stock")]
        public long Stock { get; set; }

        [Column("inStock")]
        public bool InStock { get; set; }

        [Column("category")]
        public string Category { get; set; }

        public Product() { }

        
        public Product(long productID,
                       string name,
                       string description,
                       decimal price,
                       string image,
                       long stock,
                       bool inStock,
                       string category)
        {
            ProductID = productID;
            Name = name;
            Description = description;
            Price = price;
            Image = image;
            Stock = stock;
            InStock = inStock;
            Category = category;
        }
    }
}
