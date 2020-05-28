using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Models;
using Demo.Models.Api;

namespace Demo.Data.Repositories
{
    public class NotDatabaseStudentRepository : IStudentRepository
    {
        public async Task<StudentDTO> DeleteStudent(long id)
        {
            return null;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudents()
        {
            return new[]
            {
                new StudentDTO { Id=5, FirstName = "Keith", LastName = "Dahlby" },
                new StudentDTO { Id=3,FirstName = "Craig", LastName = "Barkley" },
                new StudentDTO { Id=1,FirstName = "Ian", LastName = "Smith" },
            };
        }

        public async Task<StudentDTO> GetOneStudent(long id)
        {
            return new StudentDTO { Id = id, FirstName = "Test", LastName = "Dummy" };
        }

        public async Task<StudentDTO> SaveNewStudent(Student student)
        {
            return null;
        }

        public async Task<bool> UpdateStudent(long id, Student student)
        {
            return true;
        }
    }
}
