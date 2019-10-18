using System;
using System.Linq;
using HidLibrary;

namespace SpeedWheelController
{
    class Program
    {
        //HID\VID_0583&PID_B003
        

        private static readonly int VendorId = 0x0583;

        private static readonly int ProductId = 0xB003;

        private static HidDevice _device;

        private static bool _attached;

        private static ushort _message;

        private readonly byte _buttonsPressed;
        static void Main(string[] args)
        {
            _device = HidDevices.Enumerate(VendorId, ProductId).Last();

            if (_device == null)
            {
                Console.WriteLine("Device not found");
                return;
            }

            _device.OpenDevice();

            _device.Inserted += DeviceAttachedHandler;
            _device.Removed += DeviceRemovedHandler;

            _device.MonitorDeviceEvents = true;

            Console.WriteLine(_device.Description);

            _device.ReadReport(OnReport);
            
            Console.WriteLine("Gamepad found, press any key to exit.");
            Console.ReadKey();

            _device.CloseDevice();
        }

        private static void OnReport(HidReport report)
        {
            if (_attached == false) { return; }

            if (report.Data.Length >= 0)
            {
                GetMessage(report.Data);
            }
            _device.ReadReport(OnReport);
        }

        public static void GetMessage(byte[] message)
        {
            for (var i = 0; i < message.Length; i++)
            {
               Console.Write(message[i]);
               Console.Write(" ");
            }
            Console.WriteLine();
            Console.ReadKey();
            //Console.WriteLine(BitConverter.ToString(message).Replace("-", ""));
            //if (message != null && message.Length > 0)
            //{
            //    var value = new byte[2];
            //    Array.Copy(message, 4, value, 0, 2);
            //    _message = BitConverter.ToUInt16(value, 0);
            //}
            //else throw new InvalidCastException("Cannot convert gamepad message to 32 bit integer.");
            //_buttonsPressed = GetButtonsPressed(this);
        }

        private static void KeyPressed(int value)
        {
            Console.WriteLine("Button {0} pressed.", value);
        }

        private static void KeyDepressed()
        {
            Console.WriteLine("Button depressed.");
        }

        private static void DeviceAttachedHandler()
        {
            _attached = true;
            Console.WriteLine("Gamepad attached.");
            _device.ReadReport(OnReport);
        }

        private static void DeviceRemovedHandler()
        {
            _attached = false;
            Console.WriteLine("Gamepad removed.");
        }
    }
}
