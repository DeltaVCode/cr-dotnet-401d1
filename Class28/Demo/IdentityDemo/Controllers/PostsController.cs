using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityDemo.Models;
using IdentityDemo.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostManager _posts;

        public PostsController(IPostManager posts)
        {
            _posts = posts;
        }
        // GET: api/<PostsController>
        [HttpGet]
        public async Task<List<Post>> Get()
        {
            return await _posts.GetAllPosts();
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public async Task<Post> Get(int id)
        {
            return await _posts.GetPost(id);
        }

        // POST api/<PostsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Post post)
        {
            await _posts.CreatePost(post);

            return Ok("Complete");
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Post post)
        {
            await _posts.UpdatePost(post, id);
            return Ok("Complete");
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _posts.DeletePost(id);

        }
    }
}
