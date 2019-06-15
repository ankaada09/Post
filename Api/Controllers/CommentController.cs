using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public CommentController(IGetComment getComment, IGetOneComment getOne, IAddCommentCommand addComment, IEditComment editComment, IDeleteComment deleteComment)
        {
            _getComment = getComment;
            _getOne = getOne;
            _addComment = addComment;
            _editComment = editComment;
            _deleteComment = deleteComment;
        }









        // GET: api/Comment
        [HttpGet]
        public IActionResult Get([FromQuery] CommentSearch search)
        {
            return Ok(_getComment.Execute(search));
        }

        // GET: api/Comment/5
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

        // POST: api/Comment
        [HttpPost]
        public IActionResult Post([FromBody] CommentInsertDto dto)
        {
            try
            {
                _addComment.Execute(dto);
                return NoContent();
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

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CommentDto dto)
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
