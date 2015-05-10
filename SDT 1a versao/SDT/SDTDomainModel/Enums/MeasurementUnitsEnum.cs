using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDTDomainModel.Enums
{
    public enum ConversionUnitType
    {
        LengthUnit = 0,
        WeightUnit = 1,
        VelocityUnit = 2,
        TemperatureUnit = 3,
        PressureUnit = 4,
        MassFlowRateUnit = 5,
        MassDensityUnit = 6,
        ViscosityUnit = 7,
        MolecularWeightUnit = 8,
        SurfaceTensionUnit = 9,
        VolumeFlowRateUnit = 10,
        MomentumUnit = 11
    }

    public enum LengthUnit
    {
        Meter = 1, //m - default unit for all calculations
        Kilometer = 2, //km
        Centimeter = 3, //cm
        Milimeter = 4, //mm
        Miles = 5, //mi
        Yards = 6, //yrd
        Feet = 7, //ft
        Inches = 8, //in
        Micrometer = 9 // µm
    }

    public enum WeightUnit
    {
        Kilogram = 1, //kg - default unit for all calculations
        Gram = 2, //g
        Miligram = 3, //mg
        Pound = 4, //lb
        Ounce = 5 //oz
    }

    public enum VelocityUnit
    {
        MeterPerSecond = 1, //m/s - default unit for all calculations
        FeetPerSecond = 2 //ft/s
    }

    public enum TemperatureUnit
    {
        Celsius = 1, //Cº 
        Kelvin = 2, //Kº 
        Fahrenheit = 3 //Fº - default unit for all calculations
    }

    public enum PressureUnit
    {
        Pascal = 1, //Pa - default unit for all calculations
        PoundPerSquareInch = 2, //Psi
        bar = 3 //Bar
    }

    public enum MassFlowRateUnit 
    {
        KilogramPerSecond = 1, //kg/s - default unit for all calculations
        KilogramPerHour = 2, //kg/h
        PoundPerSecond = 3, //lb/s
        PoundPerHour = 4 //lb/h
    }
    
    public enum MassDensityUnit 
    {
        KilogramPerCubicMeter = 1, //kg/m3 - default unit for all calculations
        GramPerCubicCentimeter = 2, //g/cm3
        PoundPerCubicFeet = 3 //lb/ft3
    }

    public enum ViscosityUnit
    {
        KilogramPerMeterSecond = 1, // kg/(m.s) - default unit for all calculations  
        PascalSecond = 2, //Pa*s
        PoundPerFeetSecond = 3, //lb/(ft.s)
        Centipoise = 4, //cP 
    }

    public enum MolecularWeightUnit
    {
        KilogramPerKilogramMol = 1, // kg/kgmol - default unit for all calculations   
        GramPerGramMol = 2, //g/gmol 
        PoundPerPoundMol = 3 //lb/lbmol 
    }

    public enum SurfaceTensionUnit  
    {
        NewtonPerMeter = 1, //N/m - default unit for all calculations
        DynePerCentimeter = 2 //dyn/cm 
    }

    public enum VolumeFlowRateUnit
    {
        CubicMeterPerSecond = 1, //m3/s - default unit for all calculations
        CubicFeetPerSecond = 2, //ft3/s 
        CubicMeterPerHour = 3, //m3/h
        GallonPerMinute = 4 //gpm
    }

    public enum MomentumUnit
    {
        KilogramPerMeterSquaredSecond = 1, //kg/m*s²
        PoundPerFeetSquaredSecond =2 //lb/ft*s²
    }
}
