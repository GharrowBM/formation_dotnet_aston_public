using EX04_API.Datas;
using EX04_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EX04_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly ILogger<AddressesController> _logger;
        private readonly IRepository<Dog> _dogsRepository;

        public DogsController(ILogger<AddressesController> logger, IRepository<Dog> dogsRepository)
        {
            _logger = logger;
            _dogsRepository = dogsRepository;
        }

        [HttpPost("/dog")]
        public IActionResult AddAddress(Dog newDog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(newDog);
            }

            var addedDog = _dogsRepository.Add(newDog);
            if (addedDog == null)
            {
                return BadRequest(new
                {
                    Message = "There was an issue adding your dog in the database"
                });
            }
            else
            {
                return Ok(new
                {
                    Message = "Your dog has successfully been added to the database",
                    Dog = addedDog
                });
            }
        }

        [HttpGet("/dogs")]
        public IActionResult GetAllAddresses()
        {
            var dogs = _dogsRepository.GetAll().ToList();
            if (dogs.Count > 0)
            {
                return Ok(new
                {
                    Message = "Here are all the dogs",
                    Dogs = dogs
                });
            }
            else
            {
                return NotFound(new
                {
                    Message = "There are no dogs in the database"
                });
            }
        }

        [HttpGet("/dog/{id}")]
        public IActionResult GetAddress(int id)
        {
            var found = _dogsRepository.GetById(id);
            if (found != null)
            {
                return Ok(new
                {
                    Message = "Here is your dog",
                    Dog = found
                });
            }
            else
            {
                return NotFound(new
                {
                    Message = "There is no dog in the database with this ID"
                });
            }
        }

        [HttpPatch("/dog/{id}")]
        public IActionResult UpdateAddress(int id, Dog newValues)
        {
            var found = _dogsRepository.GetById(id);
            if (found != null)
            {
                var updatedValue = _dogsRepository.Update(id, newValues);
                if (updatedValue != null)
                {
                    return Ok(new
                    {
                        Message = "Your dog has successfully been edited in the database",
                        Dog = updatedValue
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = "An error occured when editing your dog in the database"
                    });
                }
            }
            else
            {
                return NotFound(new
                {
                    Message = "There is no dog in the database with this ID"
                });
            }
        }

        [HttpDelete("/dog/{id}")]
        public IActionResult DeleteAddress(int id)
        {
            var found = _dogsRepository.GetById(id);
            if (found != null)
            {
                if (_dogsRepository.Delete(id))
                {
                    return Ok(new
                    {
                        Message = "Your dog has successfully been deleted in the database"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = "An error occured when deleting your dog in the database"
                    });
                }
            }
            else
            {
                return NotFound(new
                {
                    Message = "There is no dog in the database with this ID"
                });
            }
        }
    }
}
