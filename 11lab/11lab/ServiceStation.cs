namespace _11lab
{
    class ServiceStation
    {
        public delegate void Do(Car car);

        public Do DoAll;
        public Do DoPartial;

        public ServiceStation()
        {
            DoAll = ClimbeCamber;
            DoAll += PaintCar;
            DoAll += ChangeOil;
            DoAll += DoInspection;
            DoAll += ChangeWeels;
            DoAll += RepaireBody;

            DoPartial = PaintCar;
            DoPartial += ChangeWeels;
            DoPartial += RepaireBody;
        }
        public void ClimbeCamber(Car car)
        {
            car.CamberClimbed = true;
        }
        public void PaintCar(Car car)
        {
            car.Painted = true;
        }
        public void ChangeOil(Car car)
        {
            car.OilChanged = true;
        }
        public void DoInspection(Car car)
        {
            car.InspectionDone = true;
        }
        public void ChangeWeels(Car car)
        {
            car.WeelsChanged = true;
        }
        public void RepaireBody(Car car)
        {
            car.BodyRepaired = true;
        }
    }
}
