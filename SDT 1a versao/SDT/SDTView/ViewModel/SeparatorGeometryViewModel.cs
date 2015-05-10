using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDTDomainModel.Enums;
using SDTBusiness.Registers;
using System.Windows;
using SDTPresentation.Utils;
using SDTDomainModel.Entities;

namespace SDTPresentation.ViewModel
{
    public class SeparatorGeometryViewModel : ViewModelBase
    {
        public SeparatorGeometryViewModel(SeparatorDesignViewModel separatorDesignViewModel, SeparatorDesign separatorDesign)
        {
            this.separatorDesign = separatorDesign;
            _separatorDesignViewModel = separatorDesignViewModel;
            
            SetDefaultValues();
        }

        public void SetDefaultValues()
        {
            //Always 1 inlet nozzles in sprint 1
            separatorDesign.Geometry.NumberOfInletNozzles = NumberOfInletNozzles.One;
            separatorDesign.Geometry.HCInitialGuessForDropletSizeMeasurementUnit = LengthUnit.Micrometer;
            separatorDesign.Geometry.WaterInitialGuessForDropletSizeMeasurementUnit = LengthUnit.Micrometer;

            separatorDesign.Geometry.DrumInsideDiameterMeasurementUnit = LengthUnit.Milimeter;
            separatorDesign.Geometry.InletNozzleInsideDiameterMeasurementUnit = LengthUnit.Milimeter;
            separatorDesign.Geometry.VaporOutletNozzleInsideDiameterMeasurementUnit = LengthUnit.Milimeter;
            separatorDesign.Geometry.LiquidOutletNozzleInsideDiameterMeasurementUnit = LengthUnit.Milimeter;

            separatorDesign.Geometry.InletDevice = InletDevices.InletVaneDiffuser;
            InletDevicesCbx = InletDevices.InletVaneDiffuser.Name();

            separatorDesign.Geometry.HCInitialGuessForDropletSize = initialGuessForDropletSize300;
            separatorDesign.Geometry.WaterInitialGuessForDropletSize = initialGuessForDropletSize300;
            separatorDesign.Geometry.InletNozzleMaxMomentum = initialMomentum;
            separatorDesign.ProcessInfo.Cases[0].InletNozzleCalculatedMomentumMeasurementUnit = MomentumUnit.KilogramPerMeterSquaredSecond;
            DropletSizeHCWarning = "";
            DropletSizeWaterWarning = "";

            RaisePropertyChangedEvent("DropletSizeHCWarning");
            RaisePropertyChangedEvent("DropletSizeWaterWarning");
            RaisePropertyChangedEvent("HCInitialGuessForDropletSize");
            RaisePropertyChangedEvent("WaterInitialGuessForDropletSize");
            RaisePropertyChangedEvent("MaxCalculatedMomentum");

        }

        private SeparatorDesign separatorDesign;
        private SeparatorDesignViewModel _separatorDesignViewModel;
        

        private string _inletNozzleEntrainedOutputUnit;

        #region Const

        const double initialGuessForDropletSize300 = 300;
        const double initialMomentum = 8000;
        const string redColor = "#CD5C5C";
        const string darkGrayColor = "#B3000000";
        const string VISIBLE = "Visible";
        const string HIDDEN = "Hidden";
        #endregion

        private string _visibilityCase1 = VISIBLE;
        private string _visibilityCase2 = HIDDEN;
        private string _visibilityCase3 = HIDDEN;
        private string _visibilityCase4 = HIDDEN;
        private string _visibilityCase5 = HIDDEN;

        private string _calculatedMomentumColor1 = darkGrayColor;
        private string _calculatedMomentumColor2 = darkGrayColor;
        private string _calculatedMomentumColor3 = darkGrayColor;
        private string _calculatedMomentumColor4 = darkGrayColor;
        private string _calculatedMomentumColor5 = darkGrayColor;

        private string _calculatedMomentumOutNoColor1 = darkGrayColor;
        private string _calculatedMomentumOutNoColor2 = darkGrayColor;
        private string _calculatedMomentumOutNoColor3 = darkGrayColor;
        private string _calculatedMomentumOutNoColor4 = darkGrayColor;
        private string _calculatedMomentumOutNoColor5 = darkGrayColor;

        public string  audit { get; set; }

        #region Properties
        public double? DrumInsideDiameter
        {
            get { return  separatorDesign.Geometry.DrumInsideDiameter; }
            set
            {
                separatorDesign.Geometry.DrumInsideDiameter = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                if (value != null) GenerateKVesselOutputs();
                if (value != null && HCInitialGuessForDropletSize != null)
                {
                    DropletSizeHCWarning = "";
                    GenerateHCSmallestDropletDiameter();
                }
                if (value != null && WaterInitialGuessForDropletSize != null)
                {
                    DropletSizeWaterWarning = "";
                    GenerateWaterSmallestDropletDiameter();
                }
                RaisePropertyChangedEvent("DrumInsideDiameter");
            }
        }

        public double? InletNozzleInsideDiameter
        {
            get { return separatorDesign.Geometry.InletNozzleInsideDiameter; }
            set
            {
                separatorDesign.Geometry.InletNozzleInsideDiameter = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                if (value != null) GenerateInletNozzleOutputs();
                RaisePropertyChangedEvent("InletNozzleInsideDiameter");
            }
        }

        public double? HCInitialGuessForDropletSize
        {
            get { return separatorDesign.Geometry.HCInitialGuessForDropletSize; }
            set
            {
                DropletSizeHCWarning = "";
                separatorDesign.Geometry.HCInitialGuessForDropletSize = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                if (value == 0)
                {
                    DropletSizeHCWarning = WarningMessage.BADESTIMATEFORDROPLETSIZE;
                    return;
                }
                if (DrumInsideDiameter != null && value != null)
                    GenerateHCSmallestDropletDiameter();
                else if (DrumInsideDiameter == null)
                    EnterDrumInsideDiameterWarningHC();
                RaisePropertyChangedEvent("HCInitialGuessForDropletSize");
            }
        }

        public double? WaterInitialGuessForDropletSize
        {
            get { return separatorDesign.Geometry.WaterInitialGuessForDropletSize; }
            set
            {
                DropletSizeWaterWarning = "";
                separatorDesign.Geometry.WaterInitialGuessForDropletSize = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                if (value == 0)
                {
                    DropletSizeWaterWarning = WarningMessage.BADESTIMATEFORDROPLETSIZE;
                    return;
                }
                if (DrumInsideDiameter != null && value != null)
                    GenerateWaterSmallestDropletDiameter();
                else if (DrumInsideDiameter == null)
                    EnterDrumInsideDiameterWarning();
                RaisePropertyChangedEvent("WaterInitialGuessForDropletSize");
            }
        }

        public double? InsideDiameterVaporOutletNozzle
        {
            get { return separatorDesign.Geometry.VaporOutletNozzleInsideDiameter; }
            set
            {
                separatorDesign.Geometry.VaporOutletNozzleInsideDiameter = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                if (value != null) GenerateVaporOutletOutputs();
                RaisePropertyChangedEvent("InsideDiameterVaporOutletNozzle");
            }
        }
        public double? InsideDiameterLiquidOutletNozzle
        {
            get { return separatorDesign.Geometry.LiquidOutletNozzleInsideDiameter; }
            set
            {
                separatorDesign.Geometry.LiquidOutletNozzleInsideDiameter = PresentationUtils.RoundValueWhenInputHavingMoreThanThreeDecimalDigits(value);
                //if (value != null) GenerateLiquidOutletOutputs();
                GenerateLiquidOutletOutputs();
                RaisePropertyChangedEvent("InsideDiameterLiquidOutletNozzle");
            }
        }

        public string DrumInsideDiameterMeasurementUnit
        {
            get { return separatorDesign.Geometry.DrumInsideDiameterMeasurementUnit.Symbol(); }
            set
            {
                var previousUnit = (int)separatorDesign.Geometry.DrumInsideDiameterMeasurementUnit;
                separatorDesign.Geometry.DrumInsideDiameterMeasurementUnit = PresentationUtils.ConvertSymbolToNameLengthUnit(value);
                DrumInsideDiameter = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(DrumInsideDiameter, previousUnit, (int)PresentationUtils.ConvertSymbolToNameLengthUnit(value), ConversionUnitType.LengthUnit);
                RaisePropertyChangedEvent("DrumInsideDiameterMeasurementUnit");
            }
        }

        public string InletDevicesCbx
        {
            get { return separatorDesign.Geometry.InletDevice.Name(); }
            set
            {
                separatorDesign.Geometry.InletDevice = PresentationUtils.ConvertInletDeviceNameToInletDevice(value);
                SelectionOfInletDeviceWarning(value);
                if (value != null) GenerateInletNozzleOutputs();

                RaisePropertyChangedEvent("InletDevicesCbx");
            }
        }

        public string InletNozzleInsideDiameterMeasurementUnit
        {
            get { return separatorDesign.Geometry.InletNozzleInsideDiameterMeasurementUnit.Symbol(); }
            set
            {
                var previousUnit = (int)separatorDesign.Geometry.InletNozzleInsideDiameterMeasurementUnit;
                separatorDesign.Geometry.InletNozzleInsideDiameterMeasurementUnit = PresentationUtils.ConvertSymbolToNameLengthUnit(value);
                InletNozzleInsideDiameter = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(InletNozzleInsideDiameter, previousUnit, (int)PresentationUtils.ConvertSymbolToNameLengthUnit(value), ConversionUnitType.LengthUnit);
                RaisePropertyChangedEvent("InletNozzleInsideDiameterMeasurementUnit");
            }
        }

        public string InsideDiameterVaporOutletNozzleUnit
        {
            get { return separatorDesign.Geometry.VaporOutletNozzleInsideDiameterMeasurementUnit.Symbol(); }
            set
            {
                var previousUnit = (int)separatorDesign.Geometry.VaporOutletNozzleInsideDiameterMeasurementUnit;
                separatorDesign.Geometry.VaporOutletNozzleInsideDiameterMeasurementUnit = PresentationUtils.ConvertSymbolToNameLengthUnit(value);
                InsideDiameterVaporOutletNozzle = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(InsideDiameterVaporOutletNozzle, previousUnit, (int)PresentationUtils.ConvertSymbolToNameLengthUnit(value), ConversionUnitType.LengthUnit);
                RaisePropertyChangedEvent("InsideDiameterVaporOutletNozzleUnit");
            }
        }

        public string InsideDiameterLiquidOutletNozzleUnit
        {
            get { return separatorDesign.Geometry.LiquidOutletNozzleInsideDiameterMeasurementUnit.Symbol(); }
            set
            {
                var previousUnit = (int)separatorDesign.Geometry.LiquidOutletNozzleInsideDiameterMeasurementUnit;
                separatorDesign.Geometry.LiquidOutletNozzleInsideDiameterMeasurementUnit = PresentationUtils.ConvertSymbolToNameLengthUnit(value);
                InsideDiameterLiquidOutletNozzle = MeasurementUnitBusinessFacade.ConvertInputWhenUnitIsChanged(InsideDiameterLiquidOutletNozzle, previousUnit, (int)PresentationUtils.ConvertSymbolToNameLengthUnit(value), ConversionUnitType.LengthUnit);
                RaisePropertyChangedEvent("InsideDiameterLiquidOutletNozzleUnit");
            }
        }

        #endregion

        #region Combobox

        public static string[] DrumInsideDiameterUnitCombobox
        {
            get { return new string[] { LengthUnit.Meter.Symbol(), LengthUnit.Milimeter.Symbol(), LengthUnit.Centimeter.Symbol(), LengthUnit.Inches.Symbol(), LengthUnit.Feet.Symbol()}; }
        }

        public static string[] InsideDiameterInletNozzleUnitCombobox
        {
            get { return new string[] { LengthUnit.Milimeter.Symbol(), LengthUnit.Centimeter.Symbol(), LengthUnit.Inches.Symbol() }; }
        }

        public static string[] InsideDiameterVaporOutletNozzleUnitCombobox
        {
            get { return new string[] { LengthUnit.Milimeter.Symbol(), LengthUnit.Centimeter.Symbol(), LengthUnit.Inches.Symbol() }; }
        }

        public static string[] InsideDiameterLiquidOutletNozzleUnitCombobox
        {
            get { return new string[] { LengthUnit.Milimeter.Symbol(), LengthUnit.Centimeter.Symbol(), LengthUnit.Inches.Symbol() }; }
        }

        public static string[] InletDevicesCombobox
        {
            get { return new string[] { InletDevices.InletVaneDiffuser.Name(), InletDevices.Elbow.Name(), InletDevices.FlushNozzle.Name(), InletDevices.HalfPipe.Name(), InletDevices.InletCyclones.Name(), InletDevices.SlottedPipe.Name(), InletDevices.SplashPlate.Name(), InletDevices.VBaffle.Name()}; }
        }

        #endregion

        #region Cases

        #region Output units

        public string kVesselOutputUnit
        {
            get {return separatorDesign.ProcessInfo.Cases[0].KWaterVesselMeasurementUnit.Symbol();}
        }

        public string CalculatedMomentumOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].InletNozzleCalculatedMomentumMeasurementUnit.Symbol(); }
        }

        public string VaporOutletNozzleCalculatedMomentumUnitOutput
        {
            get { return separatorDesign.ProcessInfo.Cases[0].VaporOutletNozzleCalculatedMomentumMeasurementUnit.Symbol(); }
        }

        public string LiquidOutletNozzleCalculatedDRFOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].LiquidOutletNozzleCalculatedDRFMeasurementUnit.Symbol(); }
        }

        public string LiquidOutletNozzleVelocityDRFOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].LiquidOutletNozzleVelocityDRFMeasuremetUnit.Symbol(); }
        }

        public string HCSmallestDropletDiameterOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].HCDropletCutDiameterMeasurementUnit.Symbol(); }
        }

        public string WaterSmallestDropletDiameterOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].WaterDropletCutDiameterMeasurementUnit.Symbol(); }
        }

        public string InletNozzleEntrainedOutputUnit
        {
            get { return _inletNozzleEntrainedOutputUnit; }
            set
            {
                _inletNozzleEntrainedOutputUnit = value;
            }
        }

        #endregion

        #region KhcVessel
        public double? KhcVessel0
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].KHCVessel); }
        }
        public double? KhcVessel1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].KHCVessel); }
        }
        public double? KhcVessel2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].KHCVessel); }
        }
        public double? KhcVessel3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].KHCVessel); }
        }
        public double? KhcVessel4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].KHCVessel); }
        }
        #endregion

        #region KWaterVessel
        public double? KWaterVessel0
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].KWaterVessel); }
        }

        public double? KWaterVessel1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].KWaterVessel); }
        }

        public double? KWaterVessel2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].KWaterVessel); }
        }

        public double? KWaterVessel3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].KWaterVessel); }
        }

        public double? KWaterVessel4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].KWaterVessel); }
        }

        #endregion

        #region Inlet Nozzle Entrained HC

        public double? InletNozzleEntrainedHC0
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].InletNozzleEntrainedHCFormated); }
        }

        public double? InletNozzleEntrainedHC1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].InletNozzleEntrainedHCFormated); }
        }

        public double? InletNozzleEntrainedHC2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].InletNozzleEntrainedHCFormated); }
        }

        public double? InletNozzleEntrainedHC3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].InletNozzleEntrainedHCFormated); }
        }

        public double? InletNozzleEntrainedHC4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].InletNozzleEntrainedHCFormated); }
        }

        #endregion

        #region Inlet Nozzle Entrained Water

        public double? InletNozzleEntrainedWater0
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].InletNozzleEntrainedWaterFormated); }
        }

        public double? InletNozzleEntrainedWater1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].InletNozzleEntrainedWaterFormated); }
        }

        public double? InletNozzleEntrainedWater2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].InletNozzleEntrainedWaterFormated); }
        }

        public double? InletNozzleEntrainedWater3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].InletNozzleEntrainedWaterFormated); }
        }

        public double? InletNozzleEntrainedWater4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].InletNozzleEntrainedWaterFormated); }
        }

        #endregion

        #region Calculated Momentum

        public double? CalculatedMomentum0
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].InletNozzleCalculatedMomentum); }
        }

        public double? CalculatedMomentum1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].InletNozzleCalculatedMomentum); }
        }

        public double? CalculatedMomentum2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].InletNozzleCalculatedMomentum); }
        }

        public double? CalculatedMomentum3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].InletNozzleCalculatedMomentum); }
        }

        public double? CalculatedMomentum4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].InletNozzleCalculatedMomentum); }
        }

        public double? MaxCalculatedMomentum
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.Geometry.InletNozzleMaxMomentum); }
        }

        #endregion

        #region Vapor Outlet Nozzle Calculated Momentum

        public double? VaporOutletNozzleCalculatedMomentum0
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].VaporOutletNozzleCalculatedMomentum); }
        }

        public double? VaporOutletNozzleCalculatedMomentum1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].VaporOutletNozzleCalculatedMomentum); }
        }

        public double? VaporOutletNozzleCalculatedMomentum2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].VaporOutletNozzleCalculatedMomentum); }
        }

        public double? VaporOutletNozzleCalculatedMomentum3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].VaporOutletNozzleCalculatedMomentum); }
        }

        public double? VaporOutletNozzleCalculatedMomentum4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].VaporOutletNozzleCalculatedMomentum); }
        }

        public double? VaporOutletNozzleMaxMomentum
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.Geometry.VaporOutletNozzleMaxMomentum); }
        }

        #endregion

        #region Liquid Outlet Nozzle Calculated DRF

        public double? LiquidOutletNozzleCalculatedDRF0
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].LiquidOutletNozzleCalculatedDRF); }
        }

        public double? LiquidOutletNozzleCalculatedDRF1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].LiquidOutletNozzleCalculatedDRF); }
        }

        public double? LiquidOutletNozzleCalculatedDRF2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].LiquidOutletNozzleCalculatedDRF); }
        }

        public double? LiquidOutletNozzleCalculatedDRF3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].LiquidOutletNozzleCalculatedDRF); }
        }

        public double? LiquidOutletNozzleCalculatedDRF4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].LiquidOutletNozzleCalculatedDRF); }
        }

        #endregion

        #region Liquid Outlet Nozzle Velocity DRF

        public double? LiquidOutletNozzleVelocityDRF0
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].LiquidOutletNozzleVelocityDRF); }
        }

        public double? LiquidOutletNozzleVelocityDRF1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].LiquidOutletNozzleVelocityDRF); }
        }

        public double? LiquidOutletNozzleVelocityDRF2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].LiquidOutletNozzleVelocityDRF); }
        }

        public double? LiquidOutletNozzleVelocityDRF3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].LiquidOutletNozzleVelocityDRF); }
        }

        public double? LiquidOutletNozzleVelocityDRF4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].LiquidOutletNozzleVelocityDRF); }

        }

        #endregion

        #region HC Smallest Droplet Diameter

        public double? HCSmallestDropletDiameter0
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].HCDropletCutDiameter); }
        }

        public double? HCSmallestDropletDiameter1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].HCDropletCutDiameter); }
        }

        public double? HCSmallestDropletDiameter2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].HCDropletCutDiameter); }
        }

        public double? HCSmallestDropletDiameter3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].HCDropletCutDiameter); }
        }

        public double? HCSmallestDropletDiameter4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].HCDropletCutDiameter); }
        }

        #endregion

        #region Water Smallest Droplet Diameter

        public double? WaterSmallestDropletDiameter0
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].WaterDropletCutDiameter); }
        }

        public double? WaterSmallestDropletDiameter1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].WaterDropletCutDiameter); }
        }

        public double? WaterSmallestDropletDiameter2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].WaterDropletCutDiameter); }
        }

        public double? WaterSmallestDropletDiameter3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].WaterDropletCutDiameter); }
        }

        public double? WaterSmallestDropletDiameter4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].WaterDropletCutDiameter); }
        }

        #endregion

        #region Visibility

        public string VisibilityCase1
        {
            get { return _visibilityCase1; }
            set
            {
                _visibilityCase1 = value;
                RaisePropertyChangedEvent("VisibilityCase1");
            }
        }

        public string VisibilityCase2
        {
            get { return _visibilityCase2; }
            set
            {
                _visibilityCase2 = value;
                RaisePropertyChangedEvent("VisibilityCase2");
            }
        }

        public string VisibilityCase3
        {
            get { return _visibilityCase3; }
            set
            {
                _visibilityCase3 = value;
                RaisePropertyChangedEvent("VisibilityCase3");
            }
        }

        public string VisibilityCase4
        {
            get { return _visibilityCase4; }
            set
            {
                _visibilityCase4 = value;
                RaisePropertyChangedEvent("VisibilityCase4");
            }
        }

        public string VisibilityCase5
        {
            get { return _visibilityCase5; }
            set
            {
                _visibilityCase5 = value;
                RaisePropertyChangedEvent("VisibilityCase5");
            }
        }
        #endregion

        #region CalculatedMomentumColor

        public string CalculatedMomentumColor1
        {
            get { return _calculatedMomentumColor1; }
            set
            {
                _calculatedMomentumColor1 = value;
                RaisePropertyChangedEvent("CalculatedMomentumColor1");
            }
        }

        public string CalculatedMomentumColor2
        {
            get { return _calculatedMomentumColor2; }
            set
            {
                _calculatedMomentumColor2 = value;
                RaisePropertyChangedEvent("CalculatedMomentumColor2");
            }
        }

        public string CalculatedMomentumColor3
        {
            get { return _calculatedMomentumColor3; }
            set
            {
                _calculatedMomentumColor3 = value;
                RaisePropertyChangedEvent("CalculatedMomentumColor3");
            }
        }

        public string CalculatedMomentumColor4
        {
            get { return _calculatedMomentumColor4; }
            set
            {
                _calculatedMomentumColor4 = value;
                RaisePropertyChangedEvent("CalculatedMomentumColor4");
            }
        }

        public string CalculatedMomentumColor5
        {
            get { return _calculatedMomentumColor5; }
            set
            {
                _calculatedMomentumColor5 = value;
                RaisePropertyChangedEvent("CalculatedMomentumColor5");
            }
        }
        #endregion

        #region CalculatedMomentumOutNoColor

        public string CalculatedMomentumOutNoColor1
        {
            get { return _calculatedMomentumOutNoColor1; }
            set
            {
                _calculatedMomentumOutNoColor1 = value;
                RaisePropertyChangedEvent("CalculatedMomentumOutNoColor1");
            }
        }
        public string CalculatedMomentumOutNoColor2
        {
            get { return _calculatedMomentumOutNoColor2; }
            set
            {
                _calculatedMomentumOutNoColor2 = value;
                RaisePropertyChangedEvent("CalculatedMomentumOutNoColor2");
            }
        }
        public string CalculatedMomentumOutNoColor3
        {
            get { return _calculatedMomentumOutNoColor3; }
            set
            {
                _calculatedMomentumOutNoColor3 = value;
                RaisePropertyChangedEvent("CalculatedMomentumOutNoColor3");
            }
        }
        public string CalculatedMomentumOutNoColor4
        {
            get { return _calculatedMomentumOutNoColor4; }
            set
            {
                _calculatedMomentumOutNoColor4 = value;
                RaisePropertyChangedEvent("CalculatedMomentumOutNoColor4");
            }
        }
        public string CalculatedMomentumOutNoColor5
        {
            get { return _calculatedMomentumOutNoColor5; }
            set
            {
                _calculatedMomentumOutNoColor5 = value;
                RaisePropertyChangedEvent("CalculatedMomentumOutNoColor5");
            }
        }
        #endregion

        #endregion

        #region Warnings

        public void SelectionOfInletDeviceWarning(string inletDeviceSelected)
        {
            if (inletDeviceSelected == InletDevices.HalfPipe.Name() || inletDeviceSelected == InletDevices.SplashPlate.Name())
                InletDesignWarning = WarningMessage.NOTRECOMMENDEDFORNEWDESIGNS;
             else if (inletDeviceSelected == InletDevices.Elbow.Name() || inletDeviceSelected == InletDevices.FlushNozzle.Name())
                InletDesignWarning = WarningMessage.NOTRECOMMENDEDFORMOSTNEWSERVICES;
            else InletDesignWarning = "";
        }

        public void EnterDrumInsideDiameterWarning()
        {
            DropletSizeWaterWarning = WarningMessage.ENTERDRUMINSIDEDIAMETER;
        }

        public void EnterDrumInsideDiameterWarningHC()
        {
            DropletSizeHCWarning = WarningMessage.ENTERDRUMINSIDEDIAMETER;
        }

        public void EnterInsideDiameterLiquidOutletNozzleWarning()
        {
            int i;
            string cases = "";
            InsideDiameterLiquidOutletNozzleIsNotAcceptableWarning = "";

            for (i = 0; i < 5; i++)
                if (separatorDesign.ProcessInfo.Cases[i].LiquidOutletNozzleInsideDiameterNOTAcceptable && separatorDesign.ProcessInfo.Cases[i].isChecked)
                {
                    cases = cases + " " + (i+1);
                }
            if (!String.IsNullOrEmpty(cases))
                InsideDiameterLiquidOutletNozzleIsNotAcceptableWarning = WarningMessage.INSIDEDIAMETERLIQUIDOUTLETNOZZLEISNOTACCEPTABLE + " for case(s): " + cases;
        }

        #endregion

        #region Warnings Properties

        private string _dropletSizeHCWarning;
        private string _dropletSizeWaterWarning;
        private string _insideDiameterLiquidOutletNozzleIsNotAcceptableWarning;
        private string _inletDesignWarning;

        public string InletDesignWarningVisibility
        {
            get
            {
                return String.IsNullOrEmpty(InletDesignWarning) ? "Collapsed" : "Visible"; 
            }
        }

        public string DropletSizeHCWarningVisibility
        {
            get
            {
                return String.IsNullOrEmpty(DropletSizeHCWarning) ? "Collapsed" : "Visible"; 
            }
        }

        public string DropletSizeWaterWarningVisibility
        {
            get
            {
                return String.IsNullOrEmpty(DropletSizeWaterWarning) ? "Collapsed" : "Visible"; 
            }
        }

        public string InsideDiameterLiquidOutletNozzleIsNotAcceptableWarningVisibility
        {
            get
            {
                return String.IsNullOrEmpty(InsideDiameterLiquidOutletNozzleIsNotAcceptableWarning) ? "Collapsed" : "Visible"; 
            }
        }

        public string InletDesignWarning
        {
            get { return _inletDesignWarning; }
            set
            {
                _inletDesignWarning = value;
                RaisePropertyChangedEvent("InletDesignWarning");
                RaisePropertyChangedEvent("InletDesignWarningVisibility");
            }
        }

        public string DropletSizeHCWarning
        {
            get { return _dropletSizeHCWarning; }
            set {
                _dropletSizeHCWarning = value;
                RaisePropertyChangedEvent("DropletSizeHCWarning");
                RaisePropertyChangedEvent("DropletSizeHCWarningVisibility"); 
            }
        }

        public string DropletSizeWaterWarning
        {
            get { return _dropletSizeWaterWarning; }
            set {
                _dropletSizeWaterWarning = value;
                RaisePropertyChangedEvent("DropletSizeWaterWarning");
                RaisePropertyChangedEvent("DropletSizeWaterWarningVisibility"); 
            }
        }

        public string InsideDiameterLiquidOutletNozzleIsNotAcceptableWarning
        {
            get { return _insideDiameterLiquidOutletNozzleIsNotAcceptableWarning; }
            set {
                _insideDiameterLiquidOutletNozzleIsNotAcceptableWarning = value;
                RaisePropertyChangedEvent("InsideDiameterLiquidOutletNozzleIsNotAcceptableWarning");
                RaisePropertyChangedEvent("InsideDiameterLiquidOutletNozzleIsNotAcceptableWarningVisibility"); 
            }
        }

        #endregion

        #region Generate Outputs

        private void GenerateKVesselOutputs()
        {
            //OutputBusinessFacade.GenerateKVesselOutputs(separatorDesign.Geometry, separatorDesign.ProcessInfo.Cases, separatorDesign.GeneralInfo.OutputUnitSet);

            ShowKhcVessel();

            ShowKWaterVessel();
        }

        private void GenerateInletNozzleOutputs()
        {
            //OutputBusinessFacade.GenerateInletNozzleOutputs(separatorDesign.Geometry, separatorDesign.ProcessInfo.Cases, separatorDesign.GeneralInfo.OutputUnitSet);

            ShowInletNozzleEntrainedHC();

            ShowInletNozzleEntrainedWater();

            ShowCalculatedMomentum();
        }

        private void GenerateVaporOutletOutputs()
        {
            //OutputBusinessFacade.GenerateVaporOutletOutputs(separatorDesign.Geometry, separatorDesign.ProcessInfo.Cases, separatorDesign.GeneralInfo.OutputUnitSet);

            ShowVaporOutletNozzleCalculatedMomentum();
        }

        private void GenerateLiquidOutletOutputs(){
            //OutputBusinessFacade.GenerateLiquidOutletOutputs(separatorDesign.Geometry, separatorDesign.ProcessInfo.Cases, separatorDesign.GeneralInfo.OutputUnitSet);

            ShowLiquidOutletNozzleCalculatedDRF();

            ShowLiquidOutletNozzleVelocityDRF();
        }

        private void GenerateHCSmallestDropletDiameter()
        {
            //OutputBusinessFacade.GenerateHCSmallestDropletDiameter(separatorDesign.Geometry, separatorDesign.ProcessInfo.Cases, separatorDesign.GeneralInfo.OutputUnitSet);
            ShowHCSmallestDropletDiameter();
            CheckHCBadEstimateValue();
        }

        private void CheckHCBadEstimateValue()
        {
            for (int i = 0; i < 5; i++ )
            {
                if (separatorDesign.ProcessInfo.Cases[i].HCDropletCutDiameterBadEstimateValue)
                {
                    ClearHCSmallestDropletDiameter(i);
                    DropletSizeHCWarning = WarningMessage.BADESTIMATEFORDROPLETSIZE;
                }
            }
        }

        private void ClearHCSmallestDropletDiameter(int index)
        {
            
            separatorDesign.ProcessInfo.Cases[index].HCDropletCutDiameter = null;
            
            ShowHCSmallestDropletDiameter();
        }

        private void GenerateWaterSmallestDropletDiameter()
        {
            //OutputBusinessFacade.GenerateWaterSmallestDropletDiameter(separatorDesign.Geometry, separatorDesign.ProcessInfo.Cases, separatorDesign.GeneralInfo.OutputUnitSet);
            ShowWaterSmallestDropletDiameter();
            CheckWaterBadEstimateValue();
        }

        private void CheckWaterBadEstimateValue()
        {
            for (int i = 0; i < 5; i++)
            {
                if (separatorDesign.ProcessInfo.Cases[i].WaterDropletCutDiameterBadEstimateValue)
                {
                    ClearWaterSmallestDropletDiameter(i);
                    DropletSizeWaterWarning = WarningMessage.BADESTIMATEFORDROPLETSIZE;
                }
            }
        }

        private void ClearWaterSmallestDropletDiameter(int index)
        {
            separatorDesign.ProcessInfo.Cases[index].WaterDropletCutDiameter = null;
            
            ShowWaterSmallestDropletDiameter();
        }

        public void GenerateAllGeometryOutput()
        {
            OutputBusinessFacade.GenerateAllGeometryOutputs(separatorDesign);

            ShowKhcVessel();

            ShowKWaterVessel();

            ShowInletNozzleEntrainedHC();

            ShowInletNozzleEntrainedWater();

            ShowCalculatedMomentum();

            ShowVaporOutletNozzleCalculatedMomentum();

            ShowLiquidOutletNozzleCalculatedDRF();

            ShowLiquidOutletNozzleVelocityDRF();

            ShowHCSmallestDropletDiameter();

            ShowWaterSmallestDropletDiameter();
        }

        #region Screen Exhibition

        private void ShowWaterSmallestDropletDiameter()
        {
            RaisePropertyChangedEvent("WaterSmallestDropletDiameter0");
            RaisePropertyChangedEvent("WaterSmallestDropletDiameter1");
            RaisePropertyChangedEvent("WaterSmallestDropletDiameter2");
            RaisePropertyChangedEvent("WaterSmallestDropletDiameter3");
            RaisePropertyChangedEvent("WaterSmallestDropletDiameter4");

            RaisePropertyChangedEvent("WaterSmallestDropletDiameterOutputUnit");
        }

        private void ShowHCSmallestDropletDiameter()
        {
            RaisePropertyChangedEvent("HCSmallestDropletDiameter0");
            RaisePropertyChangedEvent("HCSmallestDropletDiameter1");
            RaisePropertyChangedEvent("HCSmallestDropletDiameter2");
            RaisePropertyChangedEvent("HCSmallestDropletDiameter3");
            RaisePropertyChangedEvent("HCSmallestDropletDiameter4");
            RaisePropertyChangedEvent("HCSmallestDropletDiameterOutputUnit");
        }

        private void ShowLiquidOutletNozzleVelocityDRF()
        {
            RaisePropertyChangedEvent("LiquidOutletNozzleVelocityDRF0");
            RaisePropertyChangedEvent("LiquidOutletNozzleVelocityDRF1");
            RaisePropertyChangedEvent("LiquidOutletNozzleVelocityDRF2");
            RaisePropertyChangedEvent("LiquidOutletNozzleVelocityDRF3");
            RaisePropertyChangedEvent("LiquidOutletNozzleVelocityDRF4");
            RaisePropertyChangedEvent("LiquidOutletNozzleVelocityDRFOutputUnit");

            EnterInsideDiameterLiquidOutletNozzleWarning();
        }

        private void ShowLiquidOutletNozzleCalculatedDRF()
        {
            RaisePropertyChangedEvent("LiquidOutletNozzleCalculatedDRF0");
            RaisePropertyChangedEvent("LiquidOutletNozzleCalculatedDRF1");
            RaisePropertyChangedEvent("LiquidOutletNozzleCalculatedDRF2");
            RaisePropertyChangedEvent("LiquidOutletNozzleCalculatedDRF3");
            RaisePropertyChangedEvent("LiquidOutletNozzleCalculatedDRF4");

            RaisePropertyChangedEvent("LiquidOutletNozzleCalculatedDRFOutputUnit");
        }

        private void ShowVaporOutletNozzleCalculatedMomentum()
        {
            RaisePropertyChangedEvent("VaporOutletNozzleCalculatedMomentum0");
            RaisePropertyChangedEvent("VaporOutletNozzleCalculatedMomentum1");
            RaisePropertyChangedEvent("VaporOutletNozzleCalculatedMomentum2");
            RaisePropertyChangedEvent("VaporOutletNozzleCalculatedMomentum3");
            RaisePropertyChangedEvent("VaporOutletNozzleCalculatedMomentum4");
            RaisePropertyChangedEvent("VaporOutletNozzleMaxMomentum");
            
            RaisePropertyChangedEvent("VaporOutletNozzleCalculatedMomentumUnitOutput");

            CompareVaporOutletNozzleCalculatedMomentum();
        }

        private void ShowKhcVessel()
        {
            RaisePropertyChangedEvent("kVesselOutputUnit"); 
            
            RaisePropertyChangedEvent("KhcVessel0");
            RaisePropertyChangedEvent("KhcVessel1");
            RaisePropertyChangedEvent("KhcVessel2");
            RaisePropertyChangedEvent("KhcVessel3");
            RaisePropertyChangedEvent("KhcVessel4");

        }

        private void ShowKWaterVessel()
        {
            RaisePropertyChangedEvent("kVesselOutputUni");
            RaisePropertyChangedEvent("KWaterVessel0");
            RaisePropertyChangedEvent("KWaterVessel1");
            RaisePropertyChangedEvent("KWaterVessel2");
            RaisePropertyChangedEvent("KWaterVessel3");
            RaisePropertyChangedEvent("KWaterVessel4");
        }

        private void ShowInletNozzleEntrainedHC()
        {
            RaisePropertyChangedEvent("InletNozzleEntrainedHC0");
            RaisePropertyChangedEvent("InletNozzleEntrainedHC1");
            RaisePropertyChangedEvent("InletNozzleEntrainedHC2");
            RaisePropertyChangedEvent("InletNozzleEntrainedHC3");
            RaisePropertyChangedEvent("InletNozzleEntrainedHC4");

            InletNozzleEntrainedOutputUnit = "%";
            RaisePropertyChangedEvent("InletNozzleEntrainedOutputUnit");
        }

        private void ShowInletNozzleEntrainedWater()
        {
            RaisePropertyChangedEvent("InletNozzleEntrainedWater0");
            RaisePropertyChangedEvent("InletNozzleEntrainedWater1");
            RaisePropertyChangedEvent("InletNozzleEntrainedWater2");
            RaisePropertyChangedEvent("InletNozzleEntrainedWater3");
            RaisePropertyChangedEvent("InletNozzleEntrainedWater4");

            InletNozzleEntrainedOutputUnit = "%";
        }

        private void ShowCalculatedMomentum()
        {
            RaisePropertyChangedEvent("CalculatedMomentum0");
            RaisePropertyChangedEvent("CalculatedMomentum1");
            RaisePropertyChangedEvent("CalculatedMomentum2");
            RaisePropertyChangedEvent("CalculatedMomentum3");
            RaisePropertyChangedEvent("CalculatedMomentum4");

            RaisePropertyChangedEvent("MaxCalculatedMomentum");

            RaisePropertyChangedEvent("CalculatedMomentumOutputUnit");

            CompareCalculatedMomentum();

        }

        #endregion

        #endregion

        #region CompareCalculatedMomentum

        private void CompareCalculatedMomentum()
        {
            if (CalculatedMomentum0 >= MaxCalculatedMomentum) CalculatedMomentumColor1 = redColor;
            else CalculatedMomentumColor1 = darkGrayColor;
            if (CalculatedMomentum1 >= MaxCalculatedMomentum) CalculatedMomentumColor2 = redColor;
            else CalculatedMomentumColor2 = darkGrayColor;
            if (CalculatedMomentum2 >= MaxCalculatedMomentum) CalculatedMomentumColor3 = redColor;
            else CalculatedMomentumColor3 = darkGrayColor;
            if (CalculatedMomentum3 >= MaxCalculatedMomentum) CalculatedMomentumColor4 = redColor;
            else CalculatedMomentumColor4 = darkGrayColor;
            if (CalculatedMomentum4 >= MaxCalculatedMomentum) CalculatedMomentumColor5 = redColor;
            else CalculatedMomentumColor5 = darkGrayColor;
        }

        private void CompareVaporOutletNozzleCalculatedMomentum()
        {
            if (VaporOutletNozzleCalculatedMomentum0 >= MaxCalculatedMomentum) CalculatedMomentumOutNoColor1 = redColor;
            else CalculatedMomentumOutNoColor1 = darkGrayColor;
            if (VaporOutletNozzleCalculatedMomentum1 >= MaxCalculatedMomentum) CalculatedMomentumOutNoColor2 = redColor;
            else CalculatedMomentumOutNoColor2 = darkGrayColor;
            if (VaporOutletNozzleCalculatedMomentum2 >= MaxCalculatedMomentum) CalculatedMomentumOutNoColor3 = redColor;
            else CalculatedMomentumOutNoColor3 = darkGrayColor;
            if (VaporOutletNozzleCalculatedMomentum3 >= MaxCalculatedMomentum) CalculatedMomentumOutNoColor4 = redColor;
            else CalculatedMomentumOutNoColor4 = darkGrayColor;
            if (VaporOutletNozzleCalculatedMomentum4 >= MaxCalculatedMomentum) CalculatedMomentumOutNoColor5 = redColor;
            else CalculatedMomentumOutNoColor5 = darkGrayColor;
        }

        #endregion
    }
}
