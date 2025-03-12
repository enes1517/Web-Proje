using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webgiris2.Models;
using webgiris2.repositories;

namespace webgiris2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class denesController : ControllerBase
    {
         private readonly RepositoriyContext _Context;
        public denesController(RepositoriyContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IActionResult GetAllPerson()
        {
           var persons=_Context.Denes.ToList();
            return(Ok(persons));

        }
        [HttpGet("{id:int}")]
        public IActionResult GetOnePerson([FromRoute] int id)
        {
            try
            {
                var person = _Context.Denes.Where(b => b.Id.Equals(id)).SingleOrDefault();

                if (person is null)
                    return NotFound();

                return Ok(person);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           

        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneperson([FromRoute] int id, [FromBody] dene person)
        {
         
            try
            {
                var entity = _Context.Denes.Where(b => b.Id.Equals(id)).SingleOrDefault();

                if (entity is null)
                    return NotFound();

                if (id != person.Id)
                    return BadRequest();

                entity.Name = person.Name;
                entity.age = person.age;
                _Context.SaveChanges();
                return Ok(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
          


        }
        [HttpPost]
        public IActionResult CreateOneperson([FromBody] dene person)
        {

            try
            {
                if (person is null)
                    return BadRequest();

                _Context.Denes.Add(person);
                _Context.SaveChanges();

                return StatusCode(201, person);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public ActionResult DeleteOneBook([FromRoute] int id)
        {

            try
            {
                var entity = _Context.Denes.Where(b => b.Id.Equals(id)).SingleOrDefault();

                if (entity is null)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = $"Book with id:{id} could not found. "

                    });

                _Context.Denes.Remove(entity);
                _Context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            

        }
    }
}
