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
    public class TypeController : ControllerBase
    {
        private readonly IGEtTypeCommand _gEtType;
        private readonly IGetOneType _oneType;
        private readonly IAddType _addType;
        private readonly IEditType _editType;
        private IDeleteType _deleteType;

        public TypeController(IGEtTypeCommand gEtType, IGetOneType oneType, IAddType addType, IEditType editType, IDeleteType deleteType)
        {
            _gEtType = gEtType;
            _oneType = oneType;
            _addType = addType;
            _editType = editType;
            _deleteType = deleteType;
        }







        // GET: api/Type
        [HttpGet]
        public IActionResult Get([FromQuery]TypeSearch search)
        {
            return Ok(_gEtType.Execute(search));
        }

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

        // POST: api/Type
        [HttpPost]
        public IActionResult Post([FromBody] TypeDto dto)
        {
            try
            {
                _addType.Execute(dto);
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

        // PUT: api/Type/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]  TypeDto dto)
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
