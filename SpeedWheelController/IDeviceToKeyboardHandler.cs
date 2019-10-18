using System.Diagnostics;

namespace SpeedWheelController
{
    public interface IDeviceToKeyboardHandler
    {
        void HandleSteering(byte steeringValue);

        void HandlePedals(byte pedalsValue);

        void HandleButtons(byte buttonsValue);

        void HandleBackButtons(byte buttonsValue);

        void HandlePowHat(byte buttonsValue);

        void AssignTargetProcess(Process process);
    }
}