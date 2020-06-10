using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityDemo.Models.Interfaces
{
    public interface IPostManager
    {
        Task CreatePost(Post post);
        Task<Post> GetPost(int id);
        Task<List<Post>> GetAllPosts();
        Task<Post> UpdatePost(Post post, int id);
        Task DeletePost(int id);

    }
}
