using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgrest.Attributes;

namespace ChadWare.Models
{
    [Table("Addresses")]
    public class Address
    {
        [PrimaryKey("addressID", false)]
        public long AddressID { get; set; }

        [Column("orderID")]
        public long OrderID { get; set; }

        [Column("street")]
        public string Street { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("state")]
        public string State { get; set; }

        [Column("zipCode")]
        public string ZipCode { get; set; }

        public Address() { }
    }
}

