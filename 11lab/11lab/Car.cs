namespace _11lab
{
    public class Car
    { 
        public Car()
        {
            CamberClimbed = false;
            Painted = false;
            OilChanged = false;
            InspectionDone = false;
            WeelsChanged = false;
            BodyRepaired = false;
        }
        public bool CamberClimbed { get; set; }
        public bool Painted { get; set; }
        public bool OilChanged { get; set; }
        public bool InspectionDone { get; set; }
        public bool WeelsChanged { get; set; }
        public bool BodyRepaired { get; set; }

        public override string ToString()
        {
            return $"CamberClimbed -- {CamberClimbed}\n" +
                $"Painted -- {Painted}\n" +
                $"OilChanged -- {OilChanged}\n" +
                $"InspectionDone -- {InspectionDone}\n" +
                $"WeelsChanged -- {WeelsChanged}\n" +
                $"BodyRepaired -- {BodyRepaired}\n";
        }
    }
}
