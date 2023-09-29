using System;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared;

namespace Company.Function
{
    public class ServiceBusTopicTrigger1
    {
        private readonly ILogger<ServiceBusTopicTrigger1> _logger;

        public ServiceBusTopicTrigger1(ILogger<ServiceBusTopicTrigger1> logger)
        {
            _logger = logger;
        }

        [Function(nameof(ServiceBusTopicTrigger1))]
        public void Run([ServiceBusTrigger("mytopic", "mysubscription", Connection = "ServiceBusConnectionString")] 
            ServiceBusReceivedMessage message)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var myMessageType = JsonConvert.DeserializeObject<MyMessageBase>(message.Body.ToString(), settings);

            if (myMessageType.MessageType == 1)
            {
                var myMessageType1 = (MyMessageType1) myMessageType;

                _logger.LogInformation($"Message Type 1, MessageContent{myMessageType1.MyString1}");
            }
            else if (myMessageType.MessageType == 2)
            {
                var myMessageType2 = (MyMessageType2) myMessageType;

                _logger.LogInformation($"Message Type 2, MessageContent{myMessageType2.MyInt2}");
            }
        }
    }
}
