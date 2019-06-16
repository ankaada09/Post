using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Aplication;
using Aplication.DTO;
using Aplication.ICommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Encryption _enc;
        private readonly IAuthCommand _auth;

        public AuthController(Encryption enc, IAuthCommand auth)
        {
            _enc = enc;
            _auth = auth;
        }


        /// <summary>
        /// Returns all orders that match provided query
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Auth
        ///     {
        ///        "username":"jelena",
        ///        "password":"123456"
        ///        
        ///        
        ///        
        ///        
        ///     }
        ///
        /// </remarks>
        // POST: api/Auth
        [HttpPost]
        public ActionResult Post(AuthDto dto)
        {
            var user= _auth.Execute(dto);

            var stringObjekat = JsonConvert.SerializeObject(user);

            var encrypted = _enc.EncryptString(stringObjekat);

            return Ok(new { token = encrypted });
        }

        [HttpGet("decode")]
        public IActionResult Decode(string value)
        {
            var decodedString = _enc.DecryptString(value);

            decodedString = decodedString.Replace("\f", "");

            var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);

            return null;
        }


    }
}
