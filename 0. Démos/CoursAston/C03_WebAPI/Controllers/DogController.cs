using C03_WebAPI.Datas;
using C03_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C03_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly FakeDb _db;

        public DogController(FakeDb db)
        {
            _db = db;
        }

        [HttpGet("/dogs")]
        public IActionResult GetAllDogs()
        {
            var dogList = _db.GetAll();

            if (dogList.Count == 0) return NotFound(new
            {
                Message = "There are no dog in the database."
            });

            return Ok(new
            {
                Message = "Here are all the dogs.",
                Dogs = dogList
            });
        }

        [HttpGet("/dog/{id}")]
        public IActionResult GetADog(int id)
        {
            var dogFound = _db.GetById(id);

            if (dogFound == null) return NotFound(new
            {
                Message = "There is no dog with this Id."
            });

            return Ok(new
            {
                Message = "Here is your dog",
                Dog = dogFound
            });
        }

        [HttpPost("/dog")]
        public IActionResult AddADog([FromForm] Dog dog)
        {
            Dog dogAdded = _db.AddDog(dog);

            if (dogAdded != null) return Ok(new
            {
                Message = "Dog successfully added to the database.",
                Dog = dogAdded
            });

            return BadRequest(new
            {
                Message = "Something went wrong when adding your dog."
            });
        }

        [HttpDelete("/dog/{id}")]
        public IActionResult RemoveDog(int id)
        {
            var found = _db.GetById(id);

            if (found == null) return NotFound(new
            {
                Message = "There is no dog with this Id."
            });

            if (_db.DeleteDog(id)) return Ok(new
            {
                Message = "Dog successfully deleted."
            });

            return BadRequest(new
            {
                Message = "Something went wrong when deleting your dog."
            });
        }

        [HttpPatch("/dog/{id}")]
        public IActionResult EditDog(int id, Dog newDog)
        {
            var found = _db.GetById(id);

            if (found == null) return NotFound(new
            {
                Message = "There is no dog with this Id."
            });

            if (_db.EditDog(id, newDog) != null) return Ok(new
            {
                Message = "Dog successfully edited."
            });

            return BadRequest(new
            {
                Message = "Something went wrong when updating your dog."
            });
        }
    }
}
