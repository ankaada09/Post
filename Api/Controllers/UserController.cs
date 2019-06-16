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








        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /User
        ///     {
        ///        "totalCount":8,
        ///        "pagesCount":4,
        ///        "currentPage":1,
        ///        "data":[
        ///        {
        ///         "id":1,
        ///         "username":"korisnik",
        ///         "email":"jelena@gmail.com",
        ///         "userType":"Korisnik"
        /// },
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
        [LoggedIn("Admin")]
        [HttpGet]
        public ActionResult Get([FromQuery]UserSearch search)
        {
            return Ok(_getUser.Execute(search));
            
        }
        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /User
        ///     {
        ///        
        ///        "username": "korisnik",
        ///        "email":"jelena@gmail.com",
        ///        "password":"",
        ///        "userType":"korisnik"
        ///        
        ///     }
        ///
        /// </remarks>
        // GET: api/User/5
        [LoggedIn("Admin")]
        [HttpGet("{id}")]
        public ActionResult Get(int id)
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
        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Catrgoty
        ///     {
        ///        
        ///        "username": "korisnik",
        ///        "pasword":"korisnik",
        ///        "email":"jelena@gmai.com",
        ///        "userType":1
        ///        
        ///     }
        ///
        /// </remarks>
        // POST: api/User
        
        [HttpPost]
        public ActionResult Post([FromBody] AddUserDto dto)
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
        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Catrgoty
        ///     {
        ///        "id":1
        ///        "username": "korisnik",
        ///        "pasword":"korisnik",
        ///        "email":"jelena@gmai.com",
        ///        "userType":1
        ///        
        ///     }
        ///
        /// </remarks>

        // PUT: api/User/5
        [LoggedIn("Admin")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UpdateUserDto dto)
        {

            try
            {
                _editUser.Execute(dto);
                return StatusCode(201);
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
