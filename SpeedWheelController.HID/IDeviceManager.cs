using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedWheelController.HID
{
    public interface IDeviceManager
    {
        void CloseDevice();

        byte[] ReadDeviceOutput();

        void WriteToDevice(byte[] message);

        void AddDeviceAttachedHandler(Action handler);

        void AddDeviceRemovedHandler(Action handler);
    }
}
