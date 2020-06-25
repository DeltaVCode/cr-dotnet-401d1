using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoApi.Models.Api;

namespace TodoApi.Services
{
    public interface IUserService
    {
        Task<User> Register(RegisterData data, ModelStateDictionary modelState);
    }
}
