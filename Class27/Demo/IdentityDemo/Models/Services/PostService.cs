using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityDemo.Data;
using IdentityDemo.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Models.Services
{
    public class PostService : IPostManager
    {
        private BlogDbContext _context;

        public PostService(BlogDbContext context)
        {
            _context = context;
        }

        public async Task CreatePost(Post post)
        {
            _context.Entry(post).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Entry(post).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return post;
        }

        public async Task<Post> UpdatePost(Post post, int id)
        {
            if (post.Id == id)
            {
                _context.Entry(post).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return post;
        }
    }
}
