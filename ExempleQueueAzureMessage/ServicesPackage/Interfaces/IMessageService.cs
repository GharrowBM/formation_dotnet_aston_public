using System.Collections.Generic;
using Azure.Storage.Queues.Models;
using Services.DTOs;

namespace ServicesPackage.Interfaces
{
    public interface IMessageService
    {
        bool SendMessage(MessageDT0 message);
        bool DeleteMessage(QueueMessage message);

        List<string> GetMessages();
    }
}