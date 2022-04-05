using System;
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
            try
            {
                return Ok(new {Result = _messageService.SendMessage(message)});
            }
            catch (Exception ex)
            {
                return Ok(new {Message = ex.Message});
            }
        }
    }

    
}