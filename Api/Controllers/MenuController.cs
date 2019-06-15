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
    public class MenuController : ControllerBase
    {
        private readonly IGetMenuCommand _getMenu;
        private readonly IGetOneMenuCommand _getOne;
        private readonly IAddMenuCommand _addMenu;
        private readonly IEditMenuCommand _editMenu;
        private readonly IDeleteMenu _deleteMenu;

        public MenuController(IGetMenuCommand getMenu, IGetOneMenuCommand getOne, IAddMenuCommand addMenu, IEditMenuCommand editMenu, IDeleteMenu deleteMenu)
        {
            _getMenu = getMenu;
            _getOne = getOne;
            _addMenu = addMenu;
            _editMenu = editMenu;
            _deleteMenu = deleteMenu;
        }








        // GET: api/Menu
        [HttpGet]
        public IActionResult Get([FromQuery]MenuSearch search)
        {
            return Ok(_getMenu.Execute(search));
        }

        // GET: api/Menu/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
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

        // POST: api/Menu
        [HttpPost]
        public IActionResult Post([FromBody] MenuDto dto)
        {
            try
            {
                _addMenu.Execute(dto);
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

        // PUT: api/Menu/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MenuDto dto)
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
