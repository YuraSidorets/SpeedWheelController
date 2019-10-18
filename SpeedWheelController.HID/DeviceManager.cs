using System;
using System.Linq;
using HidLibrary;

namespace SpeedWheelController.HID
{
    public class DeviceManager : IDeviceManager, IDisposable
    {
        private HidDevice _device;

        private bool _attached;

        private byte[] _message;

        public DeviceManager(int vendorId, int productId)
        {
            _device = HidDevices.Enumerate(vendorId, productId).FirstOrDefault();
            if (_device == null)
            {
                throw new Exception("Device not found");
            }
            _device.OpenDevice();
            _device.MonitorDeviceEvents = true;
            _attached = true;
        }

        public void CloseDevice()
        {
            _attached = false;
            _device?.CloseDevice();
        }

        public byte[] ReadDeviceOutput()
        {
            CheckDeviceIntialized();

            _device.ReadReport(OnReport);
            return GetMessage();
        }

        public void WriteToDevice(byte[] message)
        {
            if (_attached == false)
            {
                return;
            }

            CheckDeviceIntialized();
            _device.WriteFeatureData(message);
        }

        private void OnReport(HidReport report)
        {
            if (_attached == false)
            {
                return;
            }

            if (report.Data.Length >= 0)
            {
                _message = report.Data;
            }

            _device.ReadReport(OnReport);
        }

        private byte[] GetMessage()
        {
            return _message;
        }

        public void AddDeviceAttachedHandler(Action handler)
        {
            CheckDeviceIntialized();

            _device.Inserted += new InsertedEventHandler(handler);
        }

        public void AddDeviceRemovedHandler(Action handler)
        {
            CheckDeviceIntialized();

            _device.Removed += new RemovedEventHandler(handler);
        }

        private void CheckDeviceIntialized()
        {
            if (_device == null)
            {
                throw new Exception("Device not initialized");
            }
        }

        public void Dispose()
        {
            CloseDevice();
            _device?.Dispose();
        }
    }
}
