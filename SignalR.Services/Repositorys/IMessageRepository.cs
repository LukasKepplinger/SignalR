using SignalR.Models;

namespace SignalR.Services.Repositorys
{
    public interface IMessageRepository
    {
        Message GetById(int id);
        Message GetByName(string name);

        IEnumerable<Message> GetAll();
        IEnumerable<Message> GetAllByName(string name);

        Message Add(Message message);
        Message Delete(int id);
        Message Update(Message message);
    }
}
