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
    public class UserController : ControllerBase
    {
        private readonly IGetUserCommand _getUser;
        private readonly IGetOneUser _oneUser;
        private readonly IAddUser _addUser;
        private readonly IEditUser _editUser;
        private readonly IdeleteUser _deleteUser;

        private readonly LoggedUser _loggedUser;

        public UserController(IGetUserCommand getUser, IGetOneUser oneUser, IAddUser addUser, IEditUser editUser, IdeleteUser deleteUser, LoggedUser loggedUser)
        {
            _getUser = getUser;
            _oneUser = oneUser;
            _addUser = addUser;
            _editUser = editUser;
            _deleteUser = deleteUser;
            _loggedUser = loggedUser;
        }








        [LoggedIn]
        [HttpGet]
        public IActionResult Get([FromQuery]UserSearch search)
        {
            return Ok(_getUser.Execute(search));
            
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var commdto = _oneUser.Execute(id);
                return Ok(commdto);
            }
            catch (EntityNoFound)
            {
                return NotFound();
            }
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] AddUserDto dto)
        {
            try
            {
                _addUser.Execute(dto);
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

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserDto dto)
        {

            try
            {
                _editUser.Execute(dto);
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
                _deleteUser.Execute(id);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
