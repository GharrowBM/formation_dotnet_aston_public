using C03_WebAPI.Datas;
using C03_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C03_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(PolicyName = "allConnections")]
    public class DogsController : ControllerBase
    {
        private readonly FakeDb _db;

        public DogsController(FakeDb db)
        {
            _db = db;
        }

        [HttpGet("/dogs")]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                Dogs = _db.GetAllDogs(),
            });
        }

        [HttpGet("/dog/{id}")] // Ici, il n'y a pas d'autorisation
        public IActionResult GetById(int dogId)
        {
            Dog found = _db.GetDogById(dogId);

            if (found == null) return NotFound(new
            {
                Message = "There is no dog with this Id."
            });

            return Ok(new
            {
                Message = "We found your dog",
                Dog = found
            });
        }

        [HttpPost("/dog")]
        [Authorize(Roles ="Admin")] // Ici l'autorisation est basée sur les rôles
        public IActionResult Add([FromBody] Dog newDog)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_db.AddDog(newDog) != null)
            {
                return Ok(new
                {
                    Message = "Dog successfully added to the database."
                });
            }
            else
            {
                ModelState.AddModelError("Adding Dog", "Something went wrong when adding the dog to the database.");
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("/dog/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Remove(int dogId)
        {
            Dog found = _db.GetDogById(dogId);

            if (found == null) return NotFound(new
            {
                Message = "There is no dog with this Id."
            });

            if(_db.RemoveDog(dogId)) return Ok(new
            {
                Message = "We successfully removed your dog"
            });
            else
            {
                return BadRequest(new
                {
                    Message = "Something went wrong during the deletion."
                });
            }
        }

        [HttpPatch("/dog/{id}")]
        [Authorize(Policy ="AdminOnly")] // Ici l'autorisation est basée sur les règles
        public IActionResult Edit(int dogId, [FromBody] Dog newDog)
        {
            Dog found = _db.GetDogById(dogId);

            if (found == null) return NotFound(new
            {
                Message = "There is no dog with this Id."
            });

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_db.EditDog(dogId, newDog) != null)
            {
                return Ok(new
                {
                    Message = "Dog successfully edited in the database.",
                    Dog = _db.GetDogById(dogId)
                });
            }
            else
            {
                ModelState.AddModelError("Editing Dog", "Something went wrong when editing the dog to the database.");
                return BadRequest(ModelState);
            }
        }

    }
}
