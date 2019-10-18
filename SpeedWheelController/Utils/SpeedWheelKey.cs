namespace SpeedWheelController
{
   public enum SpeedWheelKey
   {
        SteeringRight = 255,
        SteeringLeft = 0,
        SteeringCenter = 128,

        PedalRight = 0,
        PedalLeft = 255,
        PedalUp = 128,

        PowUp = 0,
        PowRightUp = 1,
        PowRight = 2,
        PowRightDown = 3,
        PowDown = 4,
        PowLeftDown = 5,
        PowLeft = 6,
        PowLeftUp = 7,

        TransmissionCenter = 0,
        TransmissionDown = 1,
        TransmissionUp = 2,

        ButtonLeftUp = 4,
        ButtonRightUp = 8,
        ButtonLeftDown = 16,
        ButtonRightDown = 32,
        ButtonLeftLower = 64,
        ButtonRightLower = 128,

        BackLeftUp = 1,
        BackLeftDown = 2,
        BackRightUp = 4,
        BackRightDown = 8
   }
}
