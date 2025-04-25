using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ChadWare.Models
{
    [Table("Address")]
    public class Address
    {
        [PrimaryKey, AutoIncrement]
        public long AddressID { get; set; }

        public long OrderID { get; set; } 
        public string Street { get; set; } = string.Empty;
        public string City { get; set; }   = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

        public Address() { }

        public Address(long orderId, string street, string city, string state, string zipCode)
        {
            OrderID = orderId;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}
