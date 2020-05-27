using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Models.Api;

namespace Demo.Data.Repositories
{
    public interface ICourseRepository
    {
        // TODO: Add GET/POST/PUT/DELETE

        Task<IEnumerable<StudentDTO>> GetStudents(int courseId);
        Task EnrollStudent(int courseId, long studentId);
        Task RemoveStudent(int courseId, long studentId);
    }
}
