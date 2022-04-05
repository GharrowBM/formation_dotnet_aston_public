

using System.Collections.Generic;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Services.DTOs;
using ServicesPackage.Interfaces;

namespace ServicesPackage.Services
{
    public class MessageService : IMessageService
    {
        private string connectionString = @"DefaultEndpointsProtocol=https;AccountName=utopiosaston;AccountKey=YinX6bXgRmDmvRq3nN7P+uHAY8kr4RZj9tkvkq/LB6IQ2xGnh6FNoJYlofL/rhflVPfRZ3cLbnlLUuvM44NgXw==;EndpointSuffix=core.windows.net";
        private string queueName = "commande";
        private QueueClient queueClient;
        public MessageService()
        {
            queueClient = new QueueClient(connectionString, queueName);
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