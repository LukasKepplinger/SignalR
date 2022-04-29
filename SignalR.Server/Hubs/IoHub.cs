using Microsoft.AspNetCore.SignalR;

namespace SignalR.Server.Hubs
{
    public class IoHub : Hub
    {
        public IoHub(SignalR.Server.Controller.Controller controller)
        {
            Controller = controller;
        }

        public Controller.Controller Controller { get; }

        public async Task SetIo(int pin, bool setTo)
        {
            if (setTo)
            {
                Console.WriteLine("PinsetRequest to Output for Pin {0} received", pin);               
            }
            else
            {
                Console.WriteLine("PinsetRequest to Input for Pin {0} received", pin);
            }
            Controller.SetPin(pin, setTo);
        }

        public async Task WriteIo(int pin, bool setTo)
        {
            if (setTo)
            {
                Console.WriteLine("PinwriteRequest to High for Pin {0} received", pin);
            }
            else
            {
                Console.WriteLine("PinwriteRequest to Low for Pin {0} received", pin);
            }
            Controller.WritePin(pin, setTo);
        }
    }
}