﻿using System;

namespace second
{
    class DiskPhone
    {
        public string InputInterface { get; set; }

        public string Connector { get; set; }

        public DiskPhone()
        {
            InputInterface = "Disk buttons";
            Connector = "Wire";
        }

        public virtual void DialNumber()
        {
            Console.WriteLine("Rolling...");
        }
    }

    class ButtonPhone : DiskPhone
    {
        public ButtonPhone()
        {
            InputInterface = "Physical buttons";
            Connector = "Wireless";
        }

        public override void DialNumber()
        {
            Console.WriteLine("Pressing buttons...");
        }

        public virtual void CheckMessages()
        {
            Console.WriteLine("Listen to the voice");
        }
    }

    class MobileBWPhone : ButtonPhone
    {
        public string Screen { get; set; }

        public MobileBWPhone()
        {
            InputInterface = "Physical buttons";
            Connector = "Wireless";
            Screen = "BW screen";
        }

        public override void CheckMessages()
        {
            Console.WriteLine("Read on BW screen");
        }
    }

    class MobileColorPhone : MobileBWPhone
    {
        public MobileColorPhone()
        {
            InputInterface = "Physical buttons";
            Connector = "Wireless";
            Screen = "Color screen";
        }

        public override void CheckMessages()
        {
            Console.WriteLine("Read on color screen");
        }
    }

    class IPhone : MobileColorPhone
    {
        public IPhone()
        {
            InputInterface = "Sensor buttons";
            Connector = "Wireless";
            Screen = "Color screen";
        }

        public override void DialNumber()
        {
            Console.WriteLine("Touching screen...");
        }
    }

    class GGlass : IPhone
    {
        public GGlass()
        {
            InputInterface = "Voice";
            Connector = "Wireless";
            Screen = "Projection on glass";
        }

        public override void DialNumber()
        {
            Console.WriteLine("Talking...");
        }

        public override void CheckMessages()
        {
            Console.WriteLine("Read on projection");
        }
    }
}
