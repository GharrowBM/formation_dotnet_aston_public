

using System;
using System.Collections.Generic;
using Azure.Identity;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Services.DTOs;
using ServicesPackage.Interfaces;

namespace ServicesPackage.Services
{
    public class MessageService : IMessageService
    {
        private string queueName = "commande";
        private QueueClient queueClient;
        public MessageService()
        {
            queueClient = new QueueClient(new Uri($"https://utopiosaston.queue.core.windows.net/{queueName}"), new DefaultAzureCredential());
        }
        public bool SendMessage(MessageDT0 message)
        {
            if (queueClient.Exists())
            {
                return queueClient.SendMessage(message.Message) != null;
            }

            return false;
        }

        public bool DeleteMessage(QueueMessage message)
        {
            if (queueClient.Exists())
            {
                return queueClient.DeleteMessage(message.MessageId, message.PopReceipt) != null;
            }
            return false;
        }

        public List<string> GetMessages()
        {
            List<string> messages = new List<string>();
            if (queueClient.Exists())
            {
                QueueMessage[] queueMessages = queueClient.ReceiveMessages();
                foreach (var message in queueMessages)
                {
                    messages.Add(message.Body.ToString());
                    DeleteMessage(message);
                }
            }
            return messages;
        }
    }
}