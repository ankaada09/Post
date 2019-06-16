using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Aplication;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.ICommand;
using Aplication.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IGetComment _getComment;
        private readonly IGetOneComment _getOne;
        private readonly IAddCommentCommand _addComment;
        private readonly IEditComment _editComment;
        private readonly IDeleteComment _deleteComment;
        private readonly LoggedUser _loggedUser;

        public CommentController(IGetComment getComment, IGetOneComment getOne, IAddCommentCommand addComment, IEditComment editComment, IDeleteComment deleteComment, LoggedUser loggedUser)
        {
            _getComment = getComment;
            _getOne = getOne;
            _addComment = addComment;
            _editComment = editComment;
            _deleteComment = deleteComment;
            _loggedUser = loggedUser;
        }










        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Comment
        ///     {
        ///        "totalCount":8,
        ///        "pagesCount":4,
        ///        "currentPage":1,
        ///        "data":[
        ///        {
        ///         "id":14,
        ///         "name":"Comment"}
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
        // GET: api/Comment
        [LoggedIn("Korisnik")]
        [HttpGet]
        public ActionResult Get([FromQuery] CommentSearch search)
        {
            return Ok(_getComment.Execute(search));
        }
        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Comment
        ///     {
        ///        
        ///        "id":1
        ///        "comment":"Admin"
        ///        
        ///     }
        ///
        /// </remarks>
        // GET: api/Comment/5
        [LoggedIn("Korisnik")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var commdto = _getOne.Execute(id);
                return Ok(commdto);
            }
            catch (EntityNoFound)
            {
                return NotFound();
            }
        }
        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Type
        ///     {
        ///        
        ///        "comment":"I love this"
        ///        "userId":1,
        ///        "postId":1
        ///        
        ///     }
        ///
        /// </remarks>

        // POST: api/Comment
        [LoggedIn("Korisnik")]
        [HttpPost]
        public ActionResult Post([FromBody] CommentInsertDto dto)
        {
            try
            {
                _addComment.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityAlreadyExists)
            {
                return NotFound();

            }
            catch (Exception)
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
        ///     POST /Type
        ///     {
        ///        
        ///        "id":"1"
        ///        "comment":"I love this"
        ///       
        ///        
        ///     }
        ///
        /// </remarks>

        // PUT: api/Comment/5
        [LoggedIn("Korisnik")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CommentDto dto)
        {
            try
            {
                _editComment.Execute(dto);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured.");
            }
        }

        // DELETE: api/ApiWithActions/5
        [LoggedIn("Korisnik")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteComment.Execute(id);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
    }
}
