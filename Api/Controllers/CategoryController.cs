using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        

        private readonly IGetCategory _command;
        private readonly IGetOneCategory _oneCategory;
        private readonly IAddCategoryCommand _addCategory;
        private IEditCategoryCommand _editCategory;
        private readonly IDeleteCategoryCommand _deleteCategory;

        public CategoryController(IGetCategory command, IGetOneCategory oneCategory, IAddCategoryCommand addCategory, IEditCategoryCommand editCategory, IDeleteCategoryCommand deleteCategory)
        {
            _command = command;
            _oneCategory = oneCategory;
            _addCategory = addCategory;
            _editCategory = editCategory;
            _deleteCategory = deleteCategory;
        }








        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        // GET: api/Category
        [HttpGet]
        public IActionResult Get([FromQuery] CategorySearch search)
        {
            return Ok(_command.Execute(search));
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try {
                var categorydto = _oneCategory.Execute(id);
                return Ok(categorydto);
            }
            catch (EntityNoFound) {
                return NotFound();
            }
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody] CategoryPostDto dto)
        {
           
            try
            {
                _addCategory.Execute(dto);
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

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryPostDto dto)
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
