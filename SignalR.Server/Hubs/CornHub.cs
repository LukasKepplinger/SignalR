using Microsoft.AspNetCore.SignalR;

namespace SignalR.Server.Hubs
{
    public class CornHub : Hub
    {
        public CornHub(SignalR.Server.Controller.Controller controller)
        {
            Controller = controller;
        }

        public Controller.Controller Controller { get; }

        public async Task DoPCA()
        {
            Controller.DoPca9685();
        }
    }
}