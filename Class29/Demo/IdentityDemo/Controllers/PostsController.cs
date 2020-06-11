using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityDemo.Models;
using IdentityDemo.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostManager _posts;

        public object ClaimType { get; private set; }

        public PostsController(IPostManager posts)
        {
            _posts = posts;
        }

        [AllowAnonymous]
        [Authorize]
        // GET: api/<PostsController>
        [HttpGet]
        public async Task<List<Post>> Get()
        {
            var user = User;
            return await _posts.GetAllPostsByMe(GetUserId());
        }

        [Authorize]
        [HttpGet("Mine")]
        public async Task<List<Post>> GetMine()
        {
            return await _posts.GetAllPostsByMe(GetUserId());
        }

        [Authorize]
        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> Get(int id)
        {
            var post = await _posts.GetPost(id, GetUserId());
            if (post == null)
                return NotFound();

            return post;
        }

        // POST api/<PostsController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] Post post)
        {
            post.CreatedByUserId = GetUserId();
            post.CreatedByTimestamp = DateTime.UtcNow;

            await _posts.CreatePost(post);

            return Ok("Complete");
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] Post post)
        {
            post.ModifiedByUserId = GetUserId();
            post.ModifiedByTimestamp = DateTime.UtcNow;

            await _posts.UpdatePost(post, id);
            return Ok("Complete");
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _posts.DeletePost(id);

        }

        private string GetUserId()
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            Claim userIdClaim = identity.FindFirst("UserId");
            return userIdClaim?.Value;
        }
    }
}
