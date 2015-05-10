using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDTDomainModel.Enums
{
    public enum EquipmentType
    {
        VerticalSeparator = 0,
        HorizontalSeparator = 1
    }

    public enum PhaseType 
    { 
        Biphase = 0, 
        Threephase = 1 
    }

    public enum NumberOfInletNozzles 
    { 
        One = 1,
        Two = 2
    }

    public enum InletDevices
    {
        HalfPipe = 0,
        SplashPlate = 1,
        Elbow = 2,
        FlushNozzle = 3,
        VBaffle = 4,
        SlottedPipe = 5,
        InletVaneDiffuser = 6, //default value
        InletCyclones = 7
    }

    public enum MeasurementUnitSystem 
    {
        SI = 1,
        US = 2
    }

    public enum CorrelationType
    {
        IshiiKataoka = 0,
        TattersonDallmanHanratty = 1
    }

}
