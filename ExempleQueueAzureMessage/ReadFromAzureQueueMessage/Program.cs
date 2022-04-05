using System;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace ReadFromAzureQueueMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=utopiosaston;AccountKey=YinX6bXgRmDmvRq3nN7P+uHAY8kr4RZj9tkvkq/LB6IQ2xGnh6FNoJYlofL/rhflVPfRZ3cLbnlLUuvM44NgXw==;EndpointSuffix=core.windows.net";
            string queueName = "commande";
            QueueClient queueClient = new QueueClient(connectionString,queueName);
            if (queueClient.Exists())
            {
                QueueMessage[] messages = queueClient.ReceiveMessages();
                foreach (var message in messages)
                {
                    Console.WriteLine(message.Body);
                }
            }
        }
    }
}