using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Web.Models;

namespace Demo.Web.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();
        Task<Student> GetOne(int id);
    }
}
