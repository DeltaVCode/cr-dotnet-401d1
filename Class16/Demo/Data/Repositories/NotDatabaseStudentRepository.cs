using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Models;

namespace Demo.Data.Repositories
{
    public class NotDatabaseStudentRepository : IStudentRepository
    {
        public async Task<Student> DeleteStudent(long id)
        {
            return null;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return new[]
            {
                new Student { Id=5, FirstName = "Keith", LastName = "Dahlby" },
                new Student { Id=3,FirstName = "Craig", LastName = "Barkley" },
                new Student { Id=1,FirstName = "Ian", LastName = "Smith" },
            };
        }

        public async Task<Student> GetOneStudent(long id)
        {
            return new Student { Id = id, FirstName = "Test", LastName = "Dummy" };
        }

        public async Task<Student> SaveNewStudent(Student student)
        {
            return student;
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            return true;
        }
    }
}
