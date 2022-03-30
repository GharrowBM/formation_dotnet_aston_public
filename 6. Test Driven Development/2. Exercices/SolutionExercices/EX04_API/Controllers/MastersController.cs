using EX04_API.Datas;
using EX04_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EX04_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastersController : ControllerBase
    {
        private readonly ILogger<AddressesController> _logger;
        private readonly IRepository<Master> _mastersRepository;

        public MastersController(ILogger<AddressesController> logger, IRepository<Master> mastersRepository)
        {
            _logger = logger;
            _mastersRepository = mastersRepository;
        }

        [HttpPost("/master")]
        public IActionResult AddAddress(Master newMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(newMaster);
            }

            var addedMaster = _mastersRepository.Add(newMaster);
            if (addedMaster == null)
            {
                return BadRequest(new
                {
                    Message = "There was an issue adding your master in the database"
                });
            }
            else
            {
                return Ok(new
                {
                    Message = "Your master has successfully been added to the database",
                    Master = addedMaster
                });
            }
        }

        [HttpGet("/masters")]
        public IActionResult GetAllAddresses()
        {
            var masters = _mastersRepository.GetAll().ToList();
            if (masters.Count > 0)
            {
                return Ok(new
                {
                    Message = "Here are all the masters",
                    Masters = masters
                });
            }
            else
            {
                return NotFound(new
                {
                    Message = "There are no masters in the database"
                });
            }
        }

        [HttpGet("/master/{id}")]
        public IActionResult GetAddress(int id)
        {
            var found = _mastersRepository.GetById(id);
            if (found != null)
            {
                return Ok(new
                {
                    Message = "Here is your master",
                    Master = found
                });
            }
            else
            {
                return NotFound(new
                {
                    Message = "There is no master in the database with this ID"
                });
            }
        }

        [HttpPatch("/master/{id}")]
        public IActionResult UpdateAddress(int id, Master newValues)
        {
            var found = _mastersRepository.GetById(id);
            if (found != null)
            {
                var updatedValue = _mastersRepository.Update(id, newValues);
                if (updatedValue != null)
                {
                    return Ok(new
                    {
                        Message = "Your master has successfully been edited in the database",
                        Master = updatedValue
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = "An error occured when editing your master in the database"
                    });
                }
            }
            else
            {
                return NotFound(new
                {
                    Message = "There is no master in the database with this ID"
                });
            }
        }

        [HttpDelete("/master/{id}")]
        public IActionResult DeleteAddress(int id)
        {
            var found = _mastersRepository.GetById(id);
            if (found != null)
            {
                if (_mastersRepository.Delete(id))
                {
                    return Ok(new
                    {
                        Message = "Your master has successfully been deleted in the database"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = "An error occured when deleting your master in the database"
                    });
                }
            }
            else
            {
                return NotFound(new
                {
                    Message = "There is no master in the database with this ID"
                });
            }
        }
    }
}
