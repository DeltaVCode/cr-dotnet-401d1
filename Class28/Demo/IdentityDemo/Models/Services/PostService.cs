using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityDemo.Data;
using IdentityDemo.Models.Identity;
using IdentityDemo.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Models.Services
{
    public class PostService : IPostManager
    {
        private BlogDbContext _context;
        private readonly UserManager<BlogUser> userManager;

        public PostService(BlogDbContext context, UserManager<BlogUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
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

        public async Task<PostDTO> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return null;

            var user = await userManager.FindByIdAsync(post.CreatedByUserId);

            return new PostDTO
            {
                Id = post.Id,
                Title = post.Title,
                Contents = post.Contents,
                CreatedBy = user == null ? null : $"{user.FirstName} {user.LastName}",
            };
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

        public Task<List<Post>> GetAllPostsByMe(string userId)
        {
            return _context.Posts
                .Where(p => p.CreatedByUserId != null && p.CreatedByUserId == userId)
                .ToListAsync();
        }
    }
}
