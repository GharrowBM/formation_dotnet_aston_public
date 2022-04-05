using System;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using ServicesPackage.Services;

namespace ReadFromAzureQueueMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            new MessageService().GetMessages().ForEach(m =>
            {
                Console.WriteLine(m);
            });
        }
    }
}