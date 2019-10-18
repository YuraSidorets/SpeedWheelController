using System;
using System.Threading;
using System.Threading.Tasks;
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
            IDeviceToKeyboardHandler keyboardHandler = new DeviceToKeyboardHandler();

            HIDDeviceManager.AddDeviceAttachedHandler(() => Console.WriteLine("Device Attached"));
            HIDDeviceManager.AddDeviceRemovedHandler(() => Console.WriteLine("Device Removed"));
            var processes = ProcessHandler.GetProcessesByName("Code");

            new TaskFactory().StartNew(() =>
            {
                do
                {
                    var data = HIDDeviceManager.ReadDeviceOutput();
                    if (data == null) continue;

                    foreach (var process in processes)
                    {
                        keyboardHandler.AssignTargetProcess(process);

                        keyboardHandler.HandleSteering(SpeedWheelController.GetSteeringValue(data));
                        keyboardHandler.HandlePedals(SpeedWheelController.GetPedalsValue(data));
                        keyboardHandler.HandleButtons(SpeedWheelController.GetButtonsValue(data));
                        keyboardHandler.HandleBackButtons(SpeedWheelController.GetBackButtonsValue(data));
                        keyboardHandler.HandlePowHat(SpeedWheelController.GetPowHatValue(data));
                    }

                    Thread.Sleep(100);
                } while (true);
            });
            Console.ReadKey();

            //Console.WriteLine("Press Enter for some good vibrations?");
            //while (Console.ReadKey().Key == ConsoleKey.Enter)
            //{
            //    HIDDeviceManager.WriteToDevice(new byte[] { 0, 64, 0, 0, 0, 0, 0, 0 });
            //    Thread.Sleep(1000);
            //    HIDDeviceManager.WriteToDevice(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
            //    Thread.Sleep(1000);
            //    HIDDeviceManager.WriteToDevice(new byte[] { 0, 128, 0, 0, 0, 0, 0, 0 });
            //    Thread.Sleep(1000);
            //    HIDDeviceManager.WriteToDevice(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
            //}
            //HIDDeviceManager.WriteToDevice(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
            //HIDDeviceManager.CloseDevice();
        }
    }
}
