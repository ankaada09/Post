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
    public class MenuController : ControllerBase
    {
        private readonly IGetMenuCommand _getMenu;
        private readonly IGetOneMenuCommand _getOne;
        private readonly IAddMenuCommand _addMenu;
        private readonly IEditMenuCommand _editMenu;
        private readonly IDeleteMenu _deleteMenu;
        private readonly LoggedUser _loggedUser;

        public MenuController(IGetMenuCommand getMenu, IGetOneMenuCommand getOne, IAddMenuCommand addMenu, IEditMenuCommand editMenu, IDeleteMenu deleteMenu, LoggedUser loggedUser)
        {
            _getMenu = getMenu;
            _getOne = getOne;
            _addMenu = addMenu;
            _editMenu = editMenu;
            _deleteMenu = deleteMenu;
            _loggedUser = loggedUser;
        }








        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Menu
        ///     {
        ///        "id":1,
        ///        "menuName":"Pocetna"
        ///        "link":""
        ///        
        ///     }
        ///
        /// </remarks>
        // GET: api/Menu
        [LoggedIn("Admin")]
        [HttpGet]
        public ActionResult Get([FromQuery]MenuSearch search)
        {
            return Ok(_getMenu.Execute(search));
        }
        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Menu
        ///     {
        ///        
        ///        "menuName":"Pocetna"
        ///        "link":""
        ///        
        ///     }
        ///
        /// </remarks>
        // GET: api/Menu/5
        [LoggedIn("Admin")]
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var menudto= _getOne.Execute(id);
                return Ok(menudto);
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
        ///     POST /Menu
        ///     {
        ///        
        ///        "menuName":"Pocetna"
        ///        "link":""
        ///        
        ///     }
        ///
        /// </remarks>
        // POST: api/Menu
        [LoggedIn("Admin")]
        [HttpPost]
        public ActionResult Post([FromBody] MenuDto dto)
        {
            try
            {
                _addMenu.Execute(dto);
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
        ///     POST /Menu
        ///     {
        ///        "id":1,
        ///        "menuName":"Pocetna"
        ///        "link":""
        ///        
        ///     }
        ///
        /// </remarks>

        // PUT: api/Menu/5
        [LoggedIn("Admin")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MenuDto dto)
        {
            try
            {
                _editMenu.Execute(dto);
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
                _deleteMenu.Execute(id);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
    }
}
