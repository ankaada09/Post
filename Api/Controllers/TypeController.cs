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
    public class TypeController : ControllerBase
    {
        private readonly IGEtTypeCommand _gEtType;
        private readonly IGetOneType _oneType;
        private readonly IAddType _addType;
        private readonly IEditType _editType;
        private IDeleteType _deleteType;
         private readonly LoggedUser _loggedUser;

        public TypeController(IGEtTypeCommand gEtType, IGetOneType oneType, IAddType addType, IEditType editType, IDeleteType deleteType, LoggedUser loggedUser)
        {
            _gEtType = gEtType;
            _oneType = oneType;
            _addType = addType;
            _editType = editType;
            _deleteType = deleteType;
            _loggedUser = loggedUser;
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
        ///        "id": 1,
        ///        "name":"Admin"
        ///        
        ///     }
        ///
        /// </remarks>
        // GET: api/Type
        [LoggedIn("Admin")]
        [HttpGet]
        public ActionResult Get([FromQuery]TypeSearch search)
        {
            return Ok(_gEtType.Execute(search));
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
        ///        
        ///        "name":"Admin"
        ///        
        ///     }
        ///
        /// </remarks>
        // GET: api/Type/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var commdto = _oneType.Execute(id);
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
        ///        
        ///        "name":"Admin"
        ///        
        ///     }
        ///
        /// </remarks>

        // POST: api/Type
        [LoggedIn("Admin")]
        [HttpPost]
        public ActionResult Post([FromBody] TypeDto dto)
        {
            try
            {
                _addType.Execute(dto);
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
        ///        "id":1
        ///        "name":"Admin"
        ///        
        ///     }
        ///
        /// </remarks>

        // PUT: api/Type/5
        [LoggedIn("Admin")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]  TypeDto dto)
        {
            try
            {
                _editType.Execute(dto);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured.");
            }
        }

        // DELETE: api/ApiWithActions/5
        [LoggedIn("Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteType.Execute(id);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
