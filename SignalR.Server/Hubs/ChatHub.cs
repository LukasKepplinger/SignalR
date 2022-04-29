using Microsoft.AspNetCore.SignalR;
using SignalR.Models;
using SignalR.Services.Repositorys;

namespace SignalR.Server.Hubs
{
    public class ChatHub : Hub
    {
        public ChatHub(IMessageRepository messageRepository)
        {
            MessageRepository = messageRepository;
        }

        public IMessageRepository MessageRepository { get; }

        public async Task SendMessage(string message)
        {
            Console.WriteLine("Message '{0}' received", message);

            try
            {
                Message dbMessage = new Message();
                dbMessage.Text = message;
                dbMessage.ReceivingDate = DateTime.Now;

                MessageRepository.Add(dbMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message '{0} could not be saved to DB: {1}", message, ex.Message);
            }
            Console.WriteLine("Message '{0} saved to DB");
        }

        public async Task PrinMessage(string message)
        {
            Console.WriteLine("Message '{0}' received", message);

            try
            {
                Message dbMessage = new Message();
                dbMessage.Text = message;
                dbMessage.ReceivingDate = DateTime.Now;

                MessageRepository.Add(dbMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message '{0} could not be saved to DB: {1}", message, ex.Message);
            }
            Console.WriteLine("Message '{0} saved to DB");
        }
    }
}
