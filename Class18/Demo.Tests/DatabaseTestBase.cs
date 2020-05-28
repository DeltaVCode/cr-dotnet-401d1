using System;
using System.Threading.Tasks;
using Demo.Data;
using Demo.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Demo.Tests
{
    public abstract class DatabaseTestBase : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly SchoolDbContext _db;

        public DatabaseTestBase()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new SchoolDbContext(
                new DbContextOptionsBuilder<SchoolDbContext>()
                    .UseSqlite((System.Data.Common.DbConnection)_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        protected async Task<Student> CreateAndSaveTestStudent()
        {
            var student = new Student { FirstName = "Test", LastName = "Whatever" };
            _db.Student.Add(student);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, student.Id); // Sanity check
            return student;
        }
    }
}
