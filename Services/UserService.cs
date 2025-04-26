using System;
using System.IO;
using SQLite;
using ChadWare.Models;
using BCrypt.Net;

namespace ChadWare.Services
{
    public class UserService
    {
        private readonly SQLiteAsyncConnection _database;

        public UserService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "chadware.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public async Task<bool> AddUserAsync(User user)
        {
            if (await GetUserByEmailAsync(user.Email) != null)
            {
                return false; // User already exists
            }

            // Hash the password before saving
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await _database.InsertAsync(user);
            return true;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _database.Table<User>()
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null) return false;

            // Verify the password hash
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

        public async Task<bool> UpdateLastLoginAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null) return false;

            user.LastLoginAt = DateTime.UtcNow;
            await _database.UpdateAsync(user);
            return true;
        }

        // Add some test users for development
        public async Task AddTestUsersAsync()
        {
            var testUsers = new[]
            {
                new User("John", "Doe", "john@example.com", "Password123!", "1234567890"),
                new User("Jane", "Smith", "jane@example.com", "Password456!", "0987654321")
            };

            foreach (var user in testUsers)
            {
                if (await GetUserByEmailAsync(user.Email) == null)
                {
                    await AddUserAsync(user);
                }
            }
        }
    }
}
