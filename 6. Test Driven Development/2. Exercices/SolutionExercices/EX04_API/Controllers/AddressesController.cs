using EX04_API.Datas;
using EX04_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EX04_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly ILogger<AddressesController> _logger;
        private readonly IRepository<Address> _addressRepository;

        public AddressesController(ILogger<AddressesController> logger, IRepository<Address> addressRepository)
        {
            _logger = logger;
            _addressRepository = addressRepository;
        }

        [HttpPost("/address")]
        public IActionResult AddAddress(Address newAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(newAddress);
            }

            Address addedAddress = _addressRepository.Add(newAddress);
            if (addedAddress == null)
            {
                return BadRequest(new
                {
                    Message = "There was an issue adding your address in the database"
                });
            }
            else
            {
                return Ok(new
                {
                    Message = "Your address has successfully been added to the database",
                    Address = addedAddress
                });
            }
        }

        [HttpGet("/addresses")]
        public IActionResult GetAllAddresses()
        {
            var addresses = _addressRepository.GetAll().ToList();
            if (addresses.Count > 0)
            {
                return Ok(new
                {
                    Message = "Here are all the addresses",
                    Addresses = addresses
                });
            }
            else
            {
                return NotFound(new
                {
                    Message = "There are no addresses in the database"
                });
            }
        }

        [HttpGet("/address/{id}")]
        public IActionResult GetAddress(int id)
        {
            var address = _addressRepository.GetById(id);
            if (address != null)
            {
                return Ok(new
                {
                    Message = "Here is your address",
                    Address = address
                });
            }
            else
            {
                return NotFound(new
                {
                    Message = "There is no address in the database with this ID"
                });
            }
        }

        [HttpPatch("/address/{id}")]
        public IActionResult UpdateAddress(int id, Address newValues)
        {
            var found = _addressRepository.GetById(id);
            if (found != null)
            {
                var updatedValue = _addressRepository.Update(id, newValues);
                if (updatedValue != null)
                {
                    return Ok(new
                    {
                        Message = "Your address has successfully been edited in the database",
                        Address = updatedValue
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = "An error occured when editing your address in the database"
                    });
                }
            }
            else
            {
                return NotFound(new
                {
                    Message = "There is no address in the database with this ID"
                });
            }
        }

        [HttpDelete("/address/{id}")]
        public IActionResult DeleteAddress(int id)
        {
            var found = _addressRepository.GetById(id);
            if (found != null)
            {
                if (_addressRepository.Delete(id))
                {
                    return Ok(new
                    {
                        Message = "Your address has successfully been deleted in the database"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = "An error occured when deleting your address in the database"
                    });
                }
            }
            else
            {
                return NotFound(new
                {
                    Message = "There is no address in the database with this ID"
                });
            }
        }
    }
}
