using Azure.Messaging.ServiceBus;

namespace conti.sb;

public class ServiceBusListener : IServiceBusListener
{
    private readonly string connectionString;
    private readonly string queueName;

    public ServiceBusListener(string connectionString, string queueName)
    {
        this.connectionString = connectionString;
        this.queueName = queueName;
    }

    public async Task Listen(CancellationToken cancellationToken)
    {
        await using var client = new ServiceBusClient(connectionString);
        var receiver = client.CreateReceiver(queueName);

        while (!cancellationToken.IsCancellationRequested)
        {
            await foreach (var message in receiver.ReceiveMessagesAsync(cancellationToken)) 
            {
                // Process the received message
                Console.WriteLine($"Received message: {message.Body}");

                // Complete the message to remove it from the queue
                await receiver.CompleteMessageAsync(message);
            }
        }
    }
}