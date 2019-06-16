using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Aplication;
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
        private readonly IEditPostCommand _editPost;
        private readonly LoggedUser _loggedUser;

        public PostController(IGetPost postsCommand, IGetOnePostCommand getOne, IGetAddPost addPost, IDeletePost deletePost, IEditPostCommand editPost, LoggedUser loggedUser)
        {
            _postsCommand = postsCommand;
            _getOne = getOne;
            _addPost = addPost;
            _deletePost = deletePost;
            _editPost = editPost;
            _loggedUser = loggedUser;
        }

















        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Post
        ///     {
        ///        "totalCount":8,
        ///        "pagesCount":4,
        ///        "currentPage":1,
        ///        "data":[
        ///        {
        ///         "id":1,
        ///         "pictureDto":[
        ///         {
        ///            "id":4,
        ///            "name":"1.jpg"
        ///            
        /// } ,
        ///  {         "id":5,
        ///             "name":"2.jpg"
        /// 
        /// }
        /// ],
        ///       "name":"Post",
        ///       "text":"Jlena",
        ///       "createdAt":"2018.5.6",
        ///       "categoryName":"Travel",
        ///       "userId":1
        ///         
        /// 
        ///         
        ///         
        ///        
        ///         
        ///        
        /// ]
        ///        
        ///     }
        ///
        /// </remarks>


        // GET: api/Post
        [HttpGet]
        public ActionResult GetPost([FromQuery] PostSearch search)
        {
            return Ok(_postsCommand.Execute(search));
        }

        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Post
        ///     {
        ///        "totalCount":8,
        ///        "pagesCount":4,
        ///        "currentPage":1,
        ///        "data":[
        ///        {
        ///         "id":1,
        ///         "pictureDto":[
        ///         {
        ///            "id":4,
        ///            "name":"1.jpg"
        ///            
        /// } 
        ///        
        ///            
        /// 
        /// }
        /// ],
        ///       "name":"Post",
        ///       "text":"Jlena",
        ///       "createdAt":"2018.5.6",
        ///       "categoryName":"Travel",
        ///       "commentDto":[
        ///       {
        ///          "id":1,
        ///          "comment":"I love this"
        /// }      
        /// ]
        ///         
        /// 
        ///         
        ///         
        ///        
        ///         
        ///        
        /// ]
        ///        
        ///     }
        ///
        /// </remarks>

        // GET: api/Post/5
        [LoggedIn("Korisnik")]
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

        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Post
        ///     {
        ///        
        ///        "name": "Post",
        ///        "text":"Text",
        ///        "userId":1,
        ///        "categoryid":1,
        ///        "image":"1.jpg"
        ///        
        ///     }
        ///
        /// </remarks>

        // POST: api/Post
        [LoggedIn("Korisnik")]
        [HttpPost]
        public ActionResult Post([FromForm] AddPost p)
        {
            var ext = Path.GetExtension(p.Image.FileName); 
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
                {
                    Name = p.Name,
                    FileName = newFileName,
                    Text = p.Text,
                    CategoryId = p.CategoryId,
                    UserId = p.UserId,

                };
                _addPost.Execute(post);
                return StatusCode(201);

            }

            catch (EntityAlreadyExists) {
              return  NotFound();
            }

            catch (Exception e)
            {
                return StatusCode(500, "An error has occured.");
            }

        }

        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Post
        ///     {
        ///        "id":1
        ///        "name": "Post",
        ///        "text":"Text",
        ///       
        ///        
        ///        "image":"1.jpg"
        ///        
        ///     }
        ///
        /// </remarks>

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromForm] AddPost p)
        {
            var ext = Path.GetExtension(p.Image.FileName);
            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }
            try {
                var newFileName = Guid.NewGuid().ToString() + "_" + p.Image.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);
                p.Image.CopyTo(new FileStream(filePath, FileMode.Create));


                

                var post = new UpdatePostDto
                {Id=p.Id,
                    Name = p.Name,
                    Text = p.Text,
                    Pictures=newFileName       

                };
                _editPost.Execute(post);
                return StatusCode(201);

            }
            catch (EntityNoFound n)
            {
                return NotFound();
            }

            catch (Exception e)
            {
                return StatusCode(500, "An error has occured.");
            }

        }

        // DELETE: api/ApiWithActions/5
        [LoggedIn("Admin")]
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
