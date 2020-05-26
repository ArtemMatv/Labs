using ProgramThatSavesItsStatus.Inerfaces;
using System;
using System.Drawing;

namespace ProgramThatSavesItsStatus.Savers
{
    public abstract class Saver : ISaver
    {
        public abstract (bool, bool, string, Size, Point) Get();
        public abstract void Save(bool first, bool second, string text, Size size, Point location);

        public static implicit operator Saver(SaveType type)
        {
            switch (type)
            {
                case SaveType.XML:
                    return new SaverXml();
                case SaveType.TXT:
                    return new SaverTxt();
                case SaveType.Binary:
                    return new SaverBinary();
                case SaveType.Register:
                    return new SaverRegister();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
