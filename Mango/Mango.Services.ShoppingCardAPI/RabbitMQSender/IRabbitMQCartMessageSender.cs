namespace Mango.Services.ShoppingCardAPI.RabbitMQSender
{
    public interface IRabbitMQCartMessageSender
    {
        void SendMessage(Object message, string queueName);

    }
}
