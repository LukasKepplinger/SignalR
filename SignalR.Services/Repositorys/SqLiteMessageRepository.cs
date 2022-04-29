

using SignalR.Models;
using Test.Services;

namespace SignalR.Services.Repositorys
{
    public class SqLiteMessageRepository : IMessageRepository
    {
        public SqLiteMessageRepository(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; }

        public Message Add(Message message)
        {
            Context.Message.Add(message);
            return message;
        }

        public Message Delete(int id)
        {
            var message = Context.Message.Find(id);
            Context.Message.Remove(message);
            return message;
        }

        public IEnumerable<Message> GetAll()
        {
            return Context.Message;
        }

        public IEnumerable<Message> GetAllByName(string name)
        {
            return Context.Message.Where(message => message.Text.Contains(name));
        }

        public Message GetById(int id)
        {
            return Context.Message.Find(id);
        }

        public Message GetByName(string name)
        {
            return Context.Message.FirstOrDefault(message => message.Text == name);
        }

        public Message Update(Message message)
        {
            var contextChange = Context.Message.Update(message);
            contextChange.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return message;
        }
    }
}
