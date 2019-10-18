using System.Diagnostics;

namespace SpeedWheelController
{
    public class DeviceToKeyboardHandler : IDeviceToKeyboardHandler
    {
        private Process TargetProcess { get; set; }

        public void HandleSteering(byte steeringValue)
        {
            //var steeringRightTreshold = ((int)SpeedWheelKey.SteeringRight +
            //                             (int)SpeedWheelKey.SteeringCenter / 2) / 2;

            //var steeringLeftTreshold = (int)SpeedWheelKey.SteeringCenter / 2;

            var treshold = GetPedalsSteeringTreshold((int)SpeedWheelKey.SteeringCenter, (int)SpeedWheelKey.SteeringRight);

            if (steeringValue > (int)SpeedWheelKey.SteeringCenter && steeringValue >= treshold.right)
            {
                KeyboardHandleUtility.SendKey(TargetProcess, (int)VirtualKeycodes.RightArrow);
            }

            if (steeringValue < (int)SpeedWheelKey.SteeringCenter && steeringValue <= treshold.left)
            {
                KeyboardHandleUtility.SendKey(TargetProcess, (int)VirtualKeycodes.LeftArrow);
            }
        }

        public void HandlePedals(byte pedalsValue)
        {
            //var rightPedalTreshold = (int) SpeedWheelKey.PedalUp / 2;
            //var leftPedalTreshold = ((int) SpeedWheelKey.PedalRight + (int) SpeedWheelKey.PedalUp / 2) / 2;

            var treshold = GetPedalsSteeringTreshold((int)SpeedWheelKey.PedalUp, (int)SpeedWheelKey.PedalRight);

            if (pedalsValue > (int)SpeedWheelKey.PedalUp && pedalsValue >= treshold.right)
            {
                KeyboardHandleUtility.SendKey(TargetProcess, (int)VirtualKeycodes.UpArrow);
            }

            if (pedalsValue < (int)SpeedWheelKey.PedalUp && pedalsValue <= treshold.left)
            {
                KeyboardHandleUtility.SendKey(TargetProcess, (int)VirtualKeycodes.DownArrow);
            }
        }

        public void HandleButtons(byte buttonsValue)
        {
            switch (buttonsValue)
            {
                case (int)SpeedWheelKey.TransmissionDown:
                    KeyboardHandleUtility.SendKey(TargetProcess, (int)VirtualKeycodes.Enter);
                    break;
                case (int)SpeedWheelKey.TransmissionUp:
                    KeyboardHandleUtility.SendKey(TargetProcess, (int)VirtualKeycodes.Backspace);
                    break;
                //Add other buttons there 
                default: break;
            }
        }

        public void HandleBackButtons(byte backButtonsValue)
        {
            switch (backButtonsValue)
            {
                case (int)SpeedWheelKey.BackLeftUp:
                    break;
                case (int)SpeedWheelKey.BackRightUp:
                    break;
                //Add other buttons there 
                default: break;
            }
        }

        public void HandlePowHat(byte powHatValue)
        {
            switch (powHatValue)
            {
                case (int)SpeedWheelKey.PowUp:
                    break;
                case (int)SpeedWheelKey.PowDown:
                    break;
                //Add other buttons there 
                default: break;
            }
        }

        private (int left, int right) GetPedalsSteeringTreshold(int centerValue, int maxValue)
        {
            var right = (maxValue + centerValue / 2) / 2;
            var left = maxValue / 2;
            return (left, right);
        }

        public void AssignTargetProcess(Process process)
        {
            TargetProcess = process;
        }
    }
}
