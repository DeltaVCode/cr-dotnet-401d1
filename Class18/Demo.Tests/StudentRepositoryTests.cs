using System;
using System.Threading.Tasks;
using Demo.Data.Repositories;
using Demo.Models;
using Xunit;

namespace Demo.Tests
{
    public class StudentRepositoryTests : DatabaseTestBase
    {
        private IStudentRepository BuildRepository()
        {
            return new DatabaseStudentRepository(_db);
        }

        [Fact]
        public async Task Can_save_and_get()
        {
            // Arrange
            var student = new Student
            {
                FirstName = "Testing",
                LastName = DateTime.Now.Ticks.ToString(),
            };

            var repository = BuildRepository();

            // Act
            var saved = await repository.SaveNewStudent(student);

            // Assert
            Assert.NotNull(saved);
            Assert.NotEqual(0, student.Id);
            Assert.Equal(student.Id, saved.Id);
            Assert.Equal(student.FirstName, saved.FirstName);
            Assert.Equal(student.LastName, saved.LastName);

            // Act
            var gotOne = await repository.GetOneStudent(saved.Id);

            // Assert
            Assert.NotNull(gotOne);
            Assert.Equal(student.Id, gotOne.Id);
            Assert.Equal(student.FirstName, gotOne.FirstName);
            Assert.Equal(student.LastName, gotOne.LastName);

            // Act
            var gotAll = await repository.GetAllStudents();

            // Assert
            Assert.Contains(gotAll, s => s.Id == student.Id);
        }
    }
}
