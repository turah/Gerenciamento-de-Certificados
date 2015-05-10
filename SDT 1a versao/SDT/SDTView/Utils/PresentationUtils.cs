using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDTDomainModel.Enums;

namespace SDTPresentation.Utils
{
    public static class PresentationUtils
    {
        public static double? RoundValueWhenInputHavingMoreThanThreeDecimalDigits(double? value)
        {
            if (!value.HasValue) return null;
            return RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value.Value);
        }

        public static double RoundValueWhenInputHavingMoreThanThreeDecimalDigits(double value)
        {
            return Math.Round(value, 3);
        }

        public static LengthUnit ConvertSymbolToNameLengthUnit(string symbol)
        {
            switch (symbol)
            {
                case "m":
                    return LengthUnit.Meter;
                case "km":
                    return LengthUnit.Kilometer;
                case "cm":
                    return LengthUnit.Centimeter;
                case "mm":
                    return LengthUnit.Milimeter;
                case "mi":
                    return LengthUnit.Miles;
                case "yrd":
                    return LengthUnit.Yards;
                case "ft":
                    return LengthUnit.Feet;
                case "in":
                    return LengthUnit.Inches;
                case "µm":
                    return LengthUnit.Micrometer;
                default:
                    return 0;
            }
        }

        public static MassFlowRateUnit ConvertSymbolToNameMassFlowRateUnit(string symbol)
        {
            switch (symbol)
            {
                case "kg/s":
                    return MassFlowRateUnit.KilogramPerSecond;
                case "kg/h":
                    return MassFlowRateUnit.KilogramPerHour;
                case "lb/s":
                    return MassFlowRateUnit.PoundPerSecond;
                case "lb/h":
                    return MassFlowRateUnit.PoundPerHour;
                default:
                    return 0;
            }
        }

        public static MassDensityUnit ConvertSymbolToNameDensityUnity(string symbol)
        {
            switch (symbol)
            {
                case "kg/m³":
                    return MassDensityUnit.KilogramPerCubicMeter;
                case "g/cm³":
                    return MassDensityUnit.GramPerCubicCentimeter;
                case "lb/ft³":
                    return MassDensityUnit.PoundPerCubicFeet;
                default:
                    return 0;
            }
        }

        public static ViscosityUnit ConvertSymbolToNameViscosityUnit(string symbol)
        {
            switch (symbol)
            {
                case "kg/m.s":
                    return ViscosityUnit.KilogramPerMeterSecond;
                case "Pa.s":
                    return ViscosityUnit.PascalSecond;
                case "lb/ft.s":
                    return ViscosityUnit.PoundPerFeetSecond;
                case "cP":
                    return ViscosityUnit.Centipoise;
                default:
                    return 0;
            }
        }

        public static SurfaceTensionUnit ConvertSymbolToNameSurfaceTensionUnit(string symbol)
        {
            switch (symbol)
            {
                case "N/m":
                    return SurfaceTensionUnit.NewtonPerMeter;
                case "dyn/cm":
                    return SurfaceTensionUnit.DynePerCentimeter;
                default:
                    return 0;
            }
        }

        public static PressureUnit ConvertSymbolToNamePressureUnit(string symbol)
        {
            switch (symbol)
            {
                case "Pa":
                    return PressureUnit.Pascal;
                case "psi":
                    return PressureUnit.PoundPerSquareInch;
                case "bar":
                    return PressureUnit.bar;
                default:
                    return 0;
            }
        }

        public static TemperatureUnit ConvertSymbolToNameTemperatureUnit(string symbol)
        {
            switch (symbol)
            {
                case "ºC":
                    return TemperatureUnit.Celsius;
                case "K":
                    return TemperatureUnit.Kelvin;
                case "ºF":
                    return TemperatureUnit.Fahrenheit;
                default:
                    return 0;
            }
        }

        public static MolecularWeightUnit ConvertSymbolToMolecularWeightUnit(string symbol)
        {
            switch (symbol)
            {
                case "g/gmol":
                    return MolecularWeightUnit.GramPerGramMol;
                case "kg/kgmol":
                    return MolecularWeightUnit.KilogramPerKilogramMol;
                case "lb/lbmol":
                    return MolecularWeightUnit.PoundPerPoundMol;
                default:
                    return 0;
            }
        }

        internal static InletDevices ConvertInletDeviceNameToInletDevice(string value)
        {
            switch (value)
            {
                case "Elbow":
                    return InletDevices.Elbow;
                case "Flush Nozzle":
                    return InletDevices.FlushNozzle;
                case "Half Pipe":
                    return InletDevices.HalfPipe;
                case "Inlet Cyclones":
                    return InletDevices.InletCyclones;
                case "Inlet Vane Diffuser":
                    return InletDevices.InletVaneDiffuser;
                case "Slotted Pipe":
                    return InletDevices.SlottedPipe;
                case "Splash Plate":
                    return InletDevices.SplashPlate;
                default:
                    return InletDevices.VBaffle;
            }
        }

        internal static MeasurementUnitSystem ConvertValueToMeasurementUnitSystem(string value)
        {
            if(value=="US")
                return MeasurementUnitSystem.US;
            else
                return MeasurementUnitSystem.SI;
        }

        public static double? FormatValueNaNInfinityToNull(double? value)
        {
   
            if (double.IsNaN(Convert.ToDouble(value)) || double.IsInfinity(Convert.ToDouble(value)))
                return null;
            else
                return value;
        }
    }
}
