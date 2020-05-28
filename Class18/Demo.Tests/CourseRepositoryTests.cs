using System.Threading.Tasks;
using Demo.Data.Repositories;
using Demo.Models;
using Xunit;

namespace Demo.Tests
{
    public class CourseRepositoryTests : DatabaseTestBase
    {
        private ICourseRepository BuildRepository()
        {
            return new DatabaseCourseRepository(_db);
        }

        [Fact]
        public async Task Can_enroll_and_unenroll_a_studentAsync()
        {
            // Arrange
            var studentRepository = new DatabaseStudentRepository(_db);
            var student = new Student { FirstName = "Test", LastName = "Whatever" };
            await studentRepository.SaveNewStudent(student);
            Assert.NotEqual(0, student.Id); // Sanity check

            var repository = BuildRepository();
            const int courseId = 1;

            // Act
            await repository.EnrollStudent(courseId, student.Id);

            // Assert
            var actualStudents = await repository.GetStudents(1);

            Assert.Contains(actualStudents, s => s.Id == student.Id);

            // Act
            await repository.RemoveStudent(courseId, student.Id);

            // assert
            actualStudents = await repository.GetStudents(1);

            Assert.NotEmpty(actualStudents);
            Assert.DoesNotContain(actualStudents, s => s.Id == student.Id);
        }
    }
}
