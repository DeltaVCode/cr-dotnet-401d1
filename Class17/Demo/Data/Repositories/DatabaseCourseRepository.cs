using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.Api;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data.Repositories
{
    public class DatabaseCourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext dbContext;

        public DatabaseCourseRepository(SchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<StudentDTO>> GetStudents(int courseId)
        {
            var students = await dbContext.Enrollments
                .Where(e => e.CourseId == courseId)
                .Select(e => new StudentDTO
                {
                    Id = e.Student.Id,
                    FirstName = e.Student.FirstName,
                    LastName = e.Student.LastName,
                })
                .ToListAsync();

            return students;
        }
    }
}
