using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ChadWare.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public long UserID { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        // Notification Preferences
        public bool EmailNotifications { get; set; }
        public bool SmsNotifications { get; set; }
        public bool MailNotifications { get; set; }

        // Additional user information
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
        public bool IsVerified { get; set; }

        public User() { }

        public User(string firstName, string lastName, string email, string password, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
        }
    }
}