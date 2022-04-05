using Microsoft.AspNetCore.Mvc;

using Services.DTOs;
using ServicesPackage.Interfaces;

namespace SendMessageProject.Controllers
{
    [ApiController]
    [Route("messages")]
    public class SendMessageController : ControllerBase
    {
        private IMessageService _messageService;

        public SendMessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] MessageDT0 message)
        {
            
            return Ok(new {Result = _messageService.SendMessage(message)});
        }
    }

    
}