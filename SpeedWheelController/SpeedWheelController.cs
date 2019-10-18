namespace SpeedWheelController
{
    public static class SpeedWheelController
    {
        public static byte GetSteeringValue(byte[] deviceOutput)
        {
            return deviceOutput[(int)SpeedWheelOutputBytesMapping.SteeringWheel];
        }

        public static byte GetPedalsValue(byte[] deviceOutput)
        {
            return deviceOutput[(int)SpeedWheelOutputBytesMapping.Pedals];
        }

        public static byte GetButtonsValue(byte[] deviceOutput)
        {
            return deviceOutput[(int)SpeedWheelOutputBytesMapping.Buttons];
        }

        public static byte GetBackButtonsValue(byte[] deviceOutput)
        {
            return deviceOutput[(int)SpeedWheelOutputBytesMapping.BackButtons];
        }

        public static byte GetPowHatValue(byte[] deviceOutput)
        {
            return deviceOutput[(int)SpeedWheelOutputBytesMapping.PowHat];
        }

        public static bool IsDefaultData(byte[] deviceOutput)
        {
            return deviceOutput[(int)SpeedWheelOutputBytesMapping.Pedals] == (int) SpeedWheelKey.PedalUp &&
                   deviceOutput[(int)SpeedWheelOutputBytesMapping.Buttons] == (int) SpeedWheelKey.TransmissionCenter &&
                   deviceOutput[(int)SpeedWheelOutputBytesMapping.PowHat] == 8 &&
                   deviceOutput[(int)SpeedWheelOutputBytesMapping.BackButtons] == 0;
        }
    }
}
