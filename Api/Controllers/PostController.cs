using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.Helpers;
using Aplication.ICommand;
using Aplication.Search;
using DataAcess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        
        private readonly IGetPost _postsCommand;
        private readonly IGetOnePostCommand _getOne;
        private readonly IGetAddPost _addPost;
        private readonly IDeletePost _deletePost;

        

        public PostController(IGetPost postsCommand, IGetOnePostCommand getOne, IGetAddPost addPost, IDeletePost deletePost)
        {
            _postsCommand = postsCommand;
            _getOne = getOne;
            _addPost = addPost;
            _deletePost = deletePost;
        }














        // GET: api/Post
        [HttpGet]
        public IActionResult GetPost([FromQuery] PostSearch search)
        {
            return Ok(_postsCommand.Execute(search));
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var postDto = _getOne.Execute(id);
                return Ok(postDto);
            }
            catch (EntityNoFound)
            {
                return NotFound();
            }
        }
        public class AddPost
        {
            public int Id { get; set; }
            public IFormFile Image { get; set; }

            public string Name { get; set; }
            public string Text { get; set; }
            public int CategoryId { get; set; }
            public int UserId { get; set; }

            
            
        }
       
        // POST: api/Post
        [HttpPost]
        public IActionResult Post([FromForm] AddPost p)
        {
            var ext = Path.GetExtension(p.Image.FileName); //.gif
            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }
             try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + p.Image.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);
                p.Image.CopyTo(new FileStream(filePath, FileMode.Create));

                var post = new InsertPostDto
                {   Name = p.Name,
                    FileName=newFileName,
                    Text = p.Text,
                    CategoryId = p.CategoryId,
                    UserId = p.UserId,
                    
                };
               _addPost.Execute(post);
                return NoContent();

            }

            catch (Exception e)
            {
                return StatusCode(500, "An error has occured.");
            }

        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
               _deletePost.Execute(id);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }



    }
}
