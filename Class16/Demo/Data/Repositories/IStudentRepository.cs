using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Models;

namespace Demo.Data.Repositories
{

    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();

        Task<Student> GetOneStudent(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        /// <returns>student exists or not</returns>
        Task<bool> UpdateStudent(long id, Student student);

        Task<Student> SaveNewStudent(Student student);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>student that was deleted</returns>
        Task<Student> DeleteStudent(long id);
    }
}
