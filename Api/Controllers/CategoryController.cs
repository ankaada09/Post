using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Helpers;
using Aplication;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.ICommand;
using Aplication.Search;
using DataAcess;
using Domen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        

        private readonly IGetCateroryApi _command;
        private readonly IGetOneCategory _oneCategory;
        private readonly IAddCategoryCommand _addCategory;
        private IEditCategoryCommand _editCategory;
        private readonly IDeleteCategoryCommand _deleteCategory;
        private readonly LoggedUser _loggedUser;

        public CategoryController(IGetCateroryApi command, IGetOneCategory oneCategory, IAddCategoryCommand addCategory, IEditCategoryCommand editCategory, IDeleteCategoryCommand deleteCategory, LoggedUser loggedUser)
        {
            _command = command;
            _oneCategory = oneCategory;
            _addCategory = addCategory;
            _editCategory = editCategory;
            _deleteCategory = deleteCategory;
            _loggedUser = loggedUser;
        }












        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Category
        ///     {
        ///        "totalCount":8,
        ///        "pagesCount":4,
        ///        "currentPage":1,
        ///        "data":[
        ///        {
        ///         "id":1,
        ///         "name":"Post"},
        ///         
        ///         {
        ///         "id":1,
        ///         "name":"1.jpg"
        ///         }
        /// ]
        ///        
        ///     }
        ///
        /// </remarks>
        // GET: api/Category
        [LoggedIn("Admin")]
        [HttpGet]
        public ActionResult Get([FromQuery] CategorySearch search)
        {
            return Ok(_command.Execute(search));
        }
        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Category
        ///     {
        ///        "id":8,
        ///        "name":"Travel"
        ///
        ///        
        ///        
        ///        
        ///         
        ///         
        ///         
        ///         
        ///        
        ///         
        ///         
        /// 
        ///        
        ///     }
        ///
        /// </remarks>

        // GET: api/Category/5
        [LoggedIn("Admin")]
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try {
                var categorydto = _oneCategory.Execute(id);
                return Ok(categorydto);
            }
            catch (EntityNoFound) {
                return NotFound();
            }
        }
        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Catrgoty
        ///     {
        ///        
        ///        "name": "Item1",
        ///        
        ///     }
        ///
        /// </remarks>

        // POST: api/Category
        [LoggedIn("Admin")]
        [HttpPost]
        public ActionResult Post([FromBody] CategoryPostDto dto)
        {
           
            try
            {
                _addCategory.Execute(dto);
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
        ///     POST /Category
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        
        ///     }
        ///
        /// </remarks>

        // PUT: api/Category/5
        [LoggedIn("Admin")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CategoryPostDto dto)
        {
           

            try
            {
                _editCategory.Execute(dto);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "An error has occured.");
            }

        }

        // DELETE: api/Category/5
        [LoggedIn("Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           
            try
            {
                _deleteCategory.Execute(id);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
