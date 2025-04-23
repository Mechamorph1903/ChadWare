using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgrest.Attributes;

namespace ChadWare.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey("userID", false)]
        public long UserID { get; set; }

        [Column("firstName")]
        public string FirstName { get; set; }

        [Column("lastName")]
        public string LastName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("phoneNumber")]
        public long PhoneNumber { get; set; }

        public User() { }
    }
}

