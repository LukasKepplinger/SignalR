using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Server.Services
{
    public class ImRunningService
    {
        public void ImRunning()
        {
            while (true)
            {
                Console.WriteLine("im running");
                Thread.Sleep(3000);
            }
        }
    }
}
