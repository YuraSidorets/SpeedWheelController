using System;
using System.Threading;
using SpeedWheelController.HID;

namespace SpeedWheelController
{
    class Program
    {
        private static readonly int VendorId = 0x0583;

        private static readonly int ProductId = 0xB003;

        private static void Main(string[] args)
        {
            IDeviceManager HIDDeviceManager = new DeviceManager(VendorId, ProductId);
            
            HIDDeviceManager.AddDeviceAttachedHandler(() => Console.WriteLine("Device Attached"));
            HIDDeviceManager.AddDeviceRemovedHandler(() =>  Console.WriteLine("Device Removed"));

            do
            {
                var data = HIDDeviceManager.ReadDeviceOutput();
                if (data == null) continue;

                foreach (var bte in data)
                {
                    Console.Write(bte);
                    Console.Write(" ");
                }
                Console.WriteLine();
            } while (Console.ReadKey().Key != ConsoleKey.Enter);

            Console.WriteLine("Press Enter for some good vibrations?");
            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                HIDDeviceManager.WriteToDevice(new byte[] { 0, 64, 0, 0, 0, 0, 0, 0 });
                Thread.Sleep(1000);
                HIDDeviceManager.WriteToDevice(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
                Thread.Sleep(1000);
                HIDDeviceManager.WriteToDevice(new byte[] { 0, 128, 0, 0, 0, 0, 0, 0 });
                Thread.Sleep(1000);
                HIDDeviceManager.WriteToDevice(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
            }
            HIDDeviceManager.WriteToDevice(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
            HIDDeviceManager.CloseDevice();
        }
    }
}
