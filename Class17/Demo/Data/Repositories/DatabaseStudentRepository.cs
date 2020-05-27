using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data.Repositories
{
    public class DatabaseStudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public DatabaseStudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Student> DeleteStudent(long id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return null;
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Student.ToListAsync();
        }

        public async Task<Student> GetOneStudent(long id)
        {
            return await _context.Student.FindAsync(id);
        }

        public async Task<Student> SaveNewStudent(Student student)
        {
            _context.Student.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> UpdateStudent(long id, Student student)
        {
            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool StudentExists(long id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
