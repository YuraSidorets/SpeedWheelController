# SpeedWheelController
Project to control Genius Speed Wheel 3 MT device from code

Typical Genius Speed Wheel 3 MT device:
<img src="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fc.dns-shop.ru%2Fthumb%2Fst1%2Ffit%2F1000%2F809%2F8c3fc70f562c0cce44baead9c0b0e2aa%2F2612d4390cb29fc282bf3f61b278e98688d54606345fe84ee4ec7c4cd1394ecc.jpg&f=1&nofb=1" height="500" >

**Device Capabilities:**    
    
    No input byte sequence [128 128 8 0 0 255 255 255]
    Steering wheel [1st byte]:
       Right: From 128 [center] to 255 [full right]
       Left: From 128 [center] to 0 [full left]

    Pedals [2nd byte]:
       Right: From 128 [up] to 0 [down]
       Left: From 128 [up] to 255 [down]
    POW Hat [3rd byte]:
        Up: 0
        Right Up: 1
        Right: 2
        Right Down: 3
        Down: 4
        Left Down: 5
        Left: 6  
        Left Up: 7
    
    Buttons:
        No input: 0

    [4th byte]
        Transmission Stick/Buttons:
            (1) Down: 1
            (2) Up: 2

        Center:
            (3) Left Up: 4
            (4) Right Up: 8
            (5) Left Down: 16
            (6) Right Down: 32
            (7) Left Lower: 64
            (8) Right Lower: 128
    [5th byte]
        Back:
            (9) Left Up: 1
            (10) Left Down: 2
            (11) Right Up: 4
            (12) Right Down: 8

    Vibration [Write 2nd byte]:
         Disabled: [0 0 0 0 0 0 0 0]
         Enabled [Max]: [0 255 0 0 0 0 0 0] 
