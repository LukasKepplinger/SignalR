﻿using System.Device.Gpio;

namespace SignalR.Server.Controller
{
    public class Controller
    {
        public Controller()
        {
            GpioController = new GpioController();
            Meadow.Hardware.II2cBus i2CBus = new II2cBusImp();
            Pca9685 = new Meadow.Foundation.ICs.IOExpanders.Pca9685(i2CBus);
        }

        public GpioController GpioController { get; }
        Meadow.Foundation.ICs.IOExpanders.Pca9685 Pca9685 { get; set; }

        public bool SetPin(int pin, bool setTo)
        {
            try
            {
                if (setTo)
                {
                    GpioController.OpenPin(pin, PinMode.Output);
                    Console.WriteLine("pin {0} is set to Output", pin);
                }
                else
                {
                    GpioController.OpenPin(pin, PinMode.Input);
                    Console.WriteLine("pin {0} is set to Input", pin);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("pin {0} could not be opened: {1}", pin, ex.Message);
            }
            return true;           
        }

        public bool WritePin(int pin, bool setTo)
        {
            try
            {
                if (setTo)
                {
                    //Test
                    GpioController.OpenPin(pin, PinMode.Output);
                    Console.WriteLine("pin {0} is set to Output", pin);

                    GpioController.Write(pin, PinValue.High);
                    Console.WriteLine("pin {0} is high now", pin);
                }
                else
                {
                    GpioController.OpenPin(pin, PinMode.Output);
                    Console.WriteLine("pin {0} is set to Output", pin);

                    GpioController.Write(pin, PinValue.Low);
                    Console.WriteLine("pin {0} is low now", pin);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("pin {0} could not be written: {1}", pin, ex.Message);
            }
            return false;
        }

        public void DoPca9685()
        {
            Pca9685.Initialize();
            Pca9685.CreatePwmPort(0);
            Pca9685.CreatePwmPort(1);
            Pca9685.SetPin(0, true);
            Pca9685.SetPin(1, false);
        }


    }
}
