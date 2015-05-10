using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDTBusiness.Registers;
using SDTDomainModel.Entities;
using SDTDomainModel.Enums;
using SDTPresentation.Utils;

namespace SDTPresentation.ViewModel
{
    public class SeparatorOutputViewModel : ViewModelBase
    {
        

        public SeparatorOutputViewModel(SeparatorDesign separatorDesign)
        {
            this.separatorDesign = separatorDesign;
        }

        #region Properties

        private SeparatorDesign separatorDesign;

        private bool _isEnabledTab1 = true;
        private bool _isEnabledTab2 = false;
        private bool _isEnabledTab3 = false;
        private bool _isEnabledTab4 = false;
        private bool _isEnabledTab5 = false;

        #region label
        private string _correlationIndex;
        public string CorrelationIndex
        {
            get { return _correlationIndex;  }
            set
            {
                _correlationIndex = value;
                RaisePropertyChangedEvent("CorrelationIndex");
            }
        }

        private string _inletNozzleEntrainedLabel;
        public string InletNozzleEntrainedLabel
        {
            get { return _inletNozzleEntrainedLabel; }
            set
            {
                _inletNozzleEntrainedLabel = value;
                RaisePropertyChangedEvent("InletNozzleEntrainedLabel");
            }
        }

        private string _inletNozzleEntrainedCorrelationIndex;
        public string InletNozzleEntrainedCorrelationIndex
        {
            get { return _inletNozzleEntrainedCorrelationIndex; }
            set
            {
                _inletNozzleEntrainedCorrelationIndex = value;
                RaisePropertyChangedEvent("InletNozzleEntrainedCorrelationIndex");
            }
        }

        #endregion

        #region Output Units

        #region Process Parameter
        public string QhcOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].QhcMeasurementUnit.Symbol(); }
        }

        public string QwOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].QwMeasurementUnit.Symbol(); }
        }

        public string QvOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].QvMeasurementUnit.Symbol(); }
        }

        public string QtOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].QtMeasurementUnit.Symbol(); }
        }

        public string QltOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].QltMeasurementUnit.Symbol(); }
        }

        public string StdVOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].StdVMeasurementUnit.Symbol(); }
        }

        public string PmOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].PmMeasurementUnit.Symbol(); }
        }
        #endregion

        #region Design Geometry Parameters

        public string ViOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].ViMeasurementUnit.Symbol(); }
        }

        public string MiOutputUnit
        {
            get { return (separatorDesign.ProcessInfo.Cases[0].InletNozzleCalculatedMomentum != null) ? separatorDesign.ProcessInfo.Cases[0].InletNozzleCalculatedMomentumMeasurementUnit.Symbol() : ""; }
        }

        public string KHCVesselOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].KHCVesselMeasurementUnit.Symbol(); }
        }

        public string VoutOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].VoutMeasurementUnit.Symbol(); }
        }

        public string MoutOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].VaporOutletNozzleCalculatedMomentumMeasurementUnit.Symbol(); }
        }

        public string DrfOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].LiquidOutletNozzleCalculatedDRFMeasurementUnit.Symbol(); }
        }

        public string VdrfOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].LiquidOutletNozzleVelocityDRFMeasuremetUnit.Symbol(); }
        }

        public static string NrfOutputUnit
        {
            get { return ""; }
        }

        public string KwvesselOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].KWaterVesselMeasurementUnit.Symbol(); }
        }

        public string UactOutputUnit
        {
            get { return separatorDesign.ProcessInfo.Cases[0].UactMeasurementUnit.Symbol(); }
        }
         
         
        #endregion

        #region Separation Efficiency

        public string DmaxOutputUnit{
            get{return separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCDropletSizeMeasurementUnit.Symbol();}
        }

        public string SauterOutputUnit{
            get { return separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCSauterMeasurementUnit.Symbol(); }
        }

        public string MedOutputUnit{
            get { return separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCMedMeasurementUnit.Symbol(); }
        }

        public string CutDiamOutputUnit{
            get { return separatorDesign.ProcessInfo.Cases[0].HCDropletCutDiameterMeasurementUnit.Symbol(); }
        }

        public string EntLOutputUnit{
            get { return separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCAssumedLiquidEntrainedMeasurementUnit.Symbol(); }
        }

        public string MeanOutputUnit{
            get { return separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterMeanMeasurementUnit.Symbol(); }
        }

        public string EntLiqHcOutputUnit{
            get { return separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCTotalLiquidEntrainedMeasurementUnit.Symbol(); }
        }

           
        #endregion

        #endregion

        #region Chart

        #region Case1

        public byte[] HCDropCumulativeDistributionCase1
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCDropCumulativeDistributionChart;
            }
        }

        public byte[] HCDropletDensityDistributionCase1
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCDropletDensityDistributionChart;
            }
        }

        public byte[] WaterDropCumulativeDistributionCase1
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterDropCumulativeDistributionChart;
            }
        }

        public byte[] WaterDropletDensityDistributionCase1
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterDropletDensityDistributionChart;
            }
        }
        #endregion

        #region Case2

        public byte[] HCDropCumulativeDistributionCase2
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCDropCumulativeDistributionChart;
            }
        }

        public byte[] HCDropletDensityDistributionCase2
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCDropletDensityDistributionChart;
            }
        }

        public byte[] WaterDropCumulativeDistributionCase2
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterDropCumulativeDistributionChart;
            }
        }

        public byte[] WaterDropletDensityDistributionCase2
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterDropletDensityDistributionChart;
            }
        }
        #endregion

        #region Case3

        public byte[] HCDropCumulativeDistributionCase3
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCDropCumulativeDistributionChart;
            }
        }

        public byte[] HCDropletDensityDistributionCase3
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCDropletDensityDistributionChart;
            }
        }

        public byte[] WaterDropCumulativeDistributionCase3
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterDropCumulativeDistributionChart;
            }
        }

        public byte[] WaterDropletDensityDistributionCase3
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterDropletDensityDistributionChart;
            }
        }
        #endregion

        #region Case4

        public byte[] HCDropCumulativeDistributionCase4
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCDropCumulativeDistributionChart;
            }
        }

        public byte[] HCDropletDensityDistributionCase4
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCDropletDensityDistributionChart;
            }
        }

        public byte[] WaterDropCumulativeDistributionCase4
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterDropCumulativeDistributionChart;
            }
        }

        public byte[] WaterDropletDensityDistributionCase4
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterDropletDensityDistributionChart;
            }
        }
        #endregion

        #region Case5

        public byte[] HCDropCumulativeDistributionCase5
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCDropCumulativeDistributionChart;
            }
        }

        public byte[] HCDropletDensityDistributionCase5
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCDropletDensityDistributionChart;
            }
        }

        public byte[] WaterDropCumulativeDistributionCase5
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterDropCumulativeDistributionChart;
            }
        }

        public byte[] WaterDropletDensityDistributionCase5
        {
            get
            {
                return separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterDropletDensityDistributionChart;
            }
        }
        #endregion

        #endregion

        #region General Information

        public string Description
        {
            get { return separatorDesign.GeneralInfo.Nome; }
        }

        public string Service
        {
            get { return separatorDesign.GeneralInfo.Nome; }
        }

        public string Project
        {
            get { return separatorDesign.GeneralInfo.Nome; }
        }

        public string Engineer
        {
            get { return separatorDesign.GeneralInfo.Nome; }
        }

        public string VesselTagNumber
        {
            get { return separatorDesign.GeneralInfo.Nome; }
        }
        #endregion

        #region Process Parameters

        #region Case1

        public double? QhcCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].Qhc); }
        }

        public double? QwCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].Qw); }
        }

        public double? QvCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].Qv); }
        }

        public double? QtCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].Qt); }
        }

        public double? QltCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].Qlt); }
        }

        public double? ZCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].CompressibilityFactor); }
        }

        public double? StdVCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].StdV); }
        }

        public double? SgCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].Sg); }
         }

        public double? PmCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].Pm); }
        }

        public double? QvQtCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].PercentageOfVaporByVolume); }
        }

        #endregion

        #region Case2

        public double? QhcCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].Qhc); }
        }

        public double? QwCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].Qw); }
         }

        public double? QvCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].Qv); }
        }

        public double? QtCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].Qt); }
        }

        public double? QltCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].Qlt); }
        }

        public double? ZCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].CompressibilityFactor); }
        }

        public double? StdVCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].StdV); }
        }

        public double? SgCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].Sg); }
        }

        public double? PmCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].Pm); }
        }

        public double? QvQtCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].PercentageOfVaporByVolume); }
        }

        #endregion

        #region Case3

        public double? QhcCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].Qhc); }
        }

        public double? QwCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].Qw); }
        }

        public double? QvCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].Qv); }
        }

        public double? QtCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].Qt); }
        }

        public double? QltCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].Qlt); }
        }

        public double? ZCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].CompressibilityFactor); }
        }

        public double? StdVCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].StdV); }
        }

        public double? SgCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].Sg); }
        }

        public double? PmCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].Pm); }
        }

        public double? QvQtCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].PercentageOfVaporByVolume); }
        }

        #endregion

        #region Case4

        public double? QhcCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].Qhc); }
        }

        public double? QwCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].Qw); }
        }

        public double? QvCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].Qv); }
        }

        public double? QtCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].Qt); }
        }

        public double? QltCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].Qlt); }
        }

        public double? ZCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].CompressibilityFactor); }
        }

        public double? StdVCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].StdV); }
        }

        public double? SgCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].Sg); }
        }

        public double? PmCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].Pm); }
        }

        public double? QvQtCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].PercentageOfVaporByVolume); }

        }

        #endregion

        #region Case5

        public double? QhcCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].Qhc); }
        }

        public double? QwCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].Qw); }

        }

        public double? QvCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].Qv); }
        }

        public double? QtCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].Qt); }
        }

        public double? QltCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].Qlt); }
        }

        public double? ZCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].CompressibilityFactor); }
        }

        public double? StdVCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].StdV); }
        }

        public double? SgCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].Sg); }
        }

        public double? PmCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].Pm); }
        }

        public double? QvQtCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].PercentageOfVaporByVolume); }
        }

        #endregion


        #endregion

        #region Design Geometry Parameters

        #region Case1

        public double? ViCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].Vi); }
        }

        public double? MiCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].InletNozzleCalculatedMomentum); }
        }

        public double? KHCVesselCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].KHCVessel); }
        }

        public double? VoutCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].Vout); }
        }

        public double? MoutCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].VaporOutletNozzleCalculatedMomentum); }
        }

        public double? DrfCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].LiquidOutletNozzleCalculatedDRF); }
        }

        public double? VdrfCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].LiquidOutletNozzleVelocityDRF); }
        }

        public double? NrfCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].FroudeNumber); }
        }

        public double? KwvesselCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].KWaterVessel); }
        }

        public double? UactCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].Uact); }
        }

        #endregion

        #region Case2

        public double? ViCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].Vi); }
        }

        public double? MiCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].InletNozzleCalculatedMomentum); }
        }

        public double? KHCVesselCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].KHCVessel); }
        }

        public double? VoutCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].Vout); }
        }

        public double? MoutCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].VaporOutletNozzleCalculatedMomentum); }
        }

        public double? DrfCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].LiquidOutletNozzleCalculatedDRF); }
        }

        public double? VdrfCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].LiquidOutletNozzleVelocityDRF); }
        }

        public double? NrfCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].FroudeNumber); }
        }

        public double? KwvesselCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].KWaterVessel); }
        }

        public double? UactCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].Uact); }
        }

        #endregion

        #region Case3

        public double? ViCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].Vi); }
        }

        public double? MiCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].InletNozzleCalculatedMomentum); }
        }

        public double? KHCVesselCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].KHCVessel); }
        }

        public double? VoutCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].Vout); }
        }

        public double? MoutCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].VaporOutletNozzleCalculatedMomentum); }
        }

        public double? DrfCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].LiquidOutletNozzleCalculatedDRF); }
        }

        public double? VdrfCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].LiquidOutletNozzleVelocityDRF); }
        }

        public double? NrfCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].FroudeNumber); }
        }

        public double? KwvesselCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].KWaterVessel); }
        }

        public double? UactCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].Uact); }
        }

        #endregion

        #region Case4

        public double? ViCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].Vi); }
        }

        public double? MiCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].InletNozzleCalculatedMomentum); }
        }

        public double? KHCVesselCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].KHCVessel); }
         }

        public double? VoutCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].Vout); }
        }

        public double? MoutCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].VaporOutletNozzleCalculatedMomentum); }
        }

        public double? DrfCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].LiquidOutletNozzleCalculatedDRF); }
           }

        public double? VdrfCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].LiquidOutletNozzleVelocityDRF); }
        }

        public double? NrfCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].FroudeNumber); }
        }

        public double? KwvesselCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].KWaterVessel); }
        }

        public double? UactCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].Uact); }
        }

        #endregion

        #region Case5

        public double? ViCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].Vi); }
        }

        public double? MiCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].InletNozzleCalculatedMomentum); }
        }

        public double? KHCVesselCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].KHCVessel); }
        }

        public double? VoutCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].Vout); }
        }

        public double? MoutCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].VaporOutletNozzleCalculatedMomentum); }
        }

        public double? DrfCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].LiquidOutletNozzleCalculatedDRF); }
        }

        public double? VdrfCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].LiquidOutletNozzleVelocityDRF); }
        }

        public double? NrfCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].FroudeNumber); }
        }

        public double? KwvesselCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].KWaterVessel); }
        }

        public double? UactCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].Uact); }
        }

        #endregion

        #endregion

        #region Separation Efficiency

        #region Case1

        public double? EntHCCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].InletNozzleEntrainedHCFormated); }
        }
        public double? DmaxCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull((CorrelationType.IshiiKataoka == separatorDesign.CorrelationType) ? separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCDropletSize : separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCMax); }
        }

        public double? SauterCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCSauter); }
        }

        public double? MedCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCMed); }
        }

        public double? EfficiencyHCCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCProjectedDrumEfficiency); }
        }

        public double? EntLiqHcCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCTotalLiquidEntrained); }
        }

        public double? CutDiamCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].HCDropletCutDiameter); }
        }

        public double? EntLCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCAssumedLiquidEntrained); }
        }

        public double? MeanCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCMean); }
        }

        public double? EntWCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].InletNozzleEntrainedWaterFormated); }
        }

        public double? DwmaxCase1
        { 
            get { return PresentationUtils.FormatValueNaNInfinityToNull((CorrelationType.IshiiKataoka == separatorDesign.CorrelationType) ? separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterDropletSize : separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterMax); }
        }

        public double? SauterWCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterSauter); }
        }
        public double? MedWCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterMed); }
        }
        public double? EfficiencyWCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterProjectedDrumEfficiency); }
        }

        public double? EntLiqWCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterTotalLiquidEntrained); }
        }
        public double? CutDiamWCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].WaterDropletCutDiameter); }
        }
        public double? EntLwCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterAssumedLiquidEntrained); }
        }
        public double? MeanWCase1
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterMean); }
        }

        #endregion

        #region Case2

        public double? EntHCCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].InletNozzleEntrainedHCFormated); }
        }
        public double? DmaxCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull((CorrelationType.IshiiKataoka == separatorDesign.CorrelationType) ? separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCDropletSize : separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCMax); }
        }

        public double? SauterCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCSauter); }
        }

        public double? MedCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCMed); }
        }

        public double? EfficiencyHCCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCProjectedDrumEfficiency); }
        }
        
        public double? EntLiqHcCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCTotalLiquidEntrained); }
        }

        public double? CutDiamCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].HCDropletCutDiameter); }
        }

        public double? EntLCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCAssumedLiquidEntrained); }
        }

        public double? MeanCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCMean); }
        }

        public double? EntWCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].InletNozzleEntrainedWaterFormated); }
        }

        public double? DwmaxCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull((CorrelationType.IshiiKataoka == separatorDesign.CorrelationType) ? separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterDropletSize : separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterMax); }
        }
        public double? SauterWCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterSauter); }
        }
        public double? MedWCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterMed); }
        }
        public double? EfficiencyWCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterProjectedDrumEfficiency); }
        }

        public double? EntLiqWCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterTotalLiquidEntrained); }
        }
        public double? CutDiamWCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].WaterDropletCutDiameter); }
        }
        public double? EntLwCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterAssumedLiquidEntrained); }
        }
        public double? MeanWCase2
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterMean); }
        }

        #endregion

        #region Case3

        public double? EntHCCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].InletNozzleEntrainedHCFormated); }
        }
        public double? DmaxCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull((CorrelationType.IshiiKataoka == separatorDesign.CorrelationType) ? separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCDropletSize : separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCMax); }
        }

        public double? SauterCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCSauter); }
        }

        public double? MedCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCMed); }
        }

        public double? EfficiencyHCCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCProjectedDrumEfficiency); }
        }

        public double? EntLiqHcCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCTotalLiquidEntrained); }
        }

        public double? CutDiamCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].HCDropletCutDiameter); }
        }

        public double? EntLCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCAssumedLiquidEntrained); }
        }

        public double? MeanCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCMean); }
        }

        public double? EntWCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].InletNozzleEntrainedWaterFormated); }
        }

        public double? DwmaxCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull((CorrelationType.IshiiKataoka == separatorDesign.CorrelationType) ? separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterDropletSize : separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterMax); }
        }

        public double? SauterWCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterSauter); }
        }

        public double? MedWCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterMed); }
        }

        public double? EfficiencyWCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterProjectedDrumEfficiency); }
        }

        public double? EntLiqWCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterTotalLiquidEntrained); }
        }

        public double? CutDiamWCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].WaterDropletCutDiameter); }
        }

        public double? EntLwCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterAssumedLiquidEntrained); }
        }

        public double? MeanWCase3
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterMean); }
        }

        #endregion

        #region Case4

        public double? EntHCCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].InletNozzleEntrainedHCFormated); }
        }
        public double? DmaxCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull((CorrelationType.IshiiKataoka == separatorDesign.CorrelationType) ? separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCDropletSize : separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCMax); }
        }

        public double? SauterCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCSauter); }
        }

        public double? MedCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCMed); }
        }

        public double? EfficiencyHCCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCProjectedDrumEfficiency); }
        }


        public double? EntLiqHcCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCTotalLiquidEntrained); }
        }

        public double? CutDiamCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].HCDropletCutDiameter); }
        }

        public double? EntLCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCAssumedLiquidEntrained); }
        }

        public double? MeanCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCMean); }
        }


        public double? EntWCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].InletNozzleEntrainedWaterFormated); }
        }

        public double? DwmaxCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull((CorrelationType.IshiiKataoka == separatorDesign.CorrelationType) ? separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterDropletSize : separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterMax); }
        }
        public double? SauterWCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterSauter); }
        }
        public double? MedWCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterMed); }
        }
        public double? EfficiencyWCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterProjectedDrumEfficiency); }
        }

        public double? EntLiqWCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterTotalLiquidEntrained); }
        }
        public double? CutDiamWCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].WaterDropletCutDiameter); }
        }
        public double? EntLwCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterAssumedLiquidEntrained); }
        }
        public double? MeanWCase4
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterMean); }
        }

        #endregion

        #region Case5

        public double? EntHCCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].InletNozzleEntrainedHCFormated); }
        }
        public double? DmaxCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull((CorrelationType.IshiiKataoka == separatorDesign.CorrelationType) ? separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCDropletSize : separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCMax); }
         }

        public double? SauterCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCSauter); }
        }

        public double? MedCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCMed); }
        }

        public double? EfficiencyHCCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCProjectedDrumEfficiency); }
        }


        public double? EntLiqHcCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCTotalLiquidEntrained); }
        }

        public double? CutDiamCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].HCDropletCutDiameter); }
        }

        public double? EntLCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCAssumedLiquidEntrained); }
        }

        public double? MeanCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCMean); }
        }


        public double? EntWCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].InletNozzleEntrainedWaterFormated); }
        }

        public double? DwmaxCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull((CorrelationType.IshiiKataoka == separatorDesign.CorrelationType) ? separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterDropletSize : separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterMax); }
         }
        public double? SauterWCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterSauter); }
        }
        public double? MedWCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterMed); }
        }
        public double? EfficiencyWCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterProjectedDrumEfficiency); }
        }

        public double? EntLiqWCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterTotalLiquidEntrained); }
        }
        public double? CutDiamWCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].WaterDropletCutDiameter); }
        }
        public double? EntLwCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterAssumedLiquidEntrained); }
        }
        public double? MeanWCase5
        {
            get { return PresentationUtils.FormatValueNaNInfinityToNull(separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterMean); }
        }

        #endregion

        #endregion

        #region Charts



        #endregion

        #region Tab's IsEnabled
        public bool IsEnabledTab1
        {
            get { return _isEnabledTab1; }
            set
            {
                _isEnabledTab1 = value;
                RaisePropertyChangedEvent("IsEnabledTab1");
            }
        }

        public bool IsEnabledTab2
        {
            get { return _isEnabledTab2; }
            set
            {
                _isEnabledTab2 = value;
                RaisePropertyChangedEvent("IsEnabledTab2");
            }
        }

        public bool IsEnabledTab3
        {
            get { return _isEnabledTab3; }
            set
            {
                _isEnabledTab3 = value;
                RaisePropertyChangedEvent("IsEnabledTab3");
            }
        }

        public bool IsEnabledTab4
        {
            get { return _isEnabledTab4; }
            set
            {
                _isEnabledTab4 = value;
                RaisePropertyChangedEvent("IsEnabledTab4");
            }
        }

        public bool IsEnabledTab5
        {
            get { return _isEnabledTab5; }
            set
            {
                _isEnabledTab5 = value;
                RaisePropertyChangedEvent("IsEnabledTab5");
            }
        }

       
        #endregion
        #endregion

        internal void GenerateAllOutputs(int caseIndex)
        {
            OutputBusinessFacade.GenerateAllOutputs(separatorDesign, caseIndex);

            ShowGeneralInformation();
            ShowProcessParameters();
            ShowDesignGeometryParameters();
            ShowSeparationEfficiency();
            ShowCharts();
            SetCorrelationLabels();
            

        }

        private void SetCorrelationLabels()
        {
            CorrelationIndex = (CorrelationType.IshiiKataoka == separatorDesign.CorrelationType) ? "ik" : "tdh";
            InletNozzleEntrainedLabel = (CorrelationType.IshiiKataoka == separatorDesign.CorrelationType) ? "D" : "MAX";
            InletNozzleEntrainedCorrelationIndex = (CorrelationType.IshiiKataoka == separatorDesign.CorrelationType) ? "max" : "tdh";
        }

        private int _tabSelectedIndex;

        public int TabSelectedIndex
        {
            get { return _tabSelectedIndex; }
            set
            {
                _tabSelectedIndex = value;
                GenerateAllOutputs(value);
                RaisePropertyChangedEvent("TabSelectedIndex");
            }
        }

        private void ShowGeneralInformation()
        {
            RaisePropertyChangedEvent("Description");
            RaisePropertyChangedEvent("Service");
            RaisePropertyChangedEvent("Project");
            RaisePropertyChangedEvent("Engineer");
            RaisePropertyChangedEvent("VesselTagNumber");

        }

        private void ShowProcessParameters()
        {
            #region Output Units
            RaisePropertyChangedEvent("QhcOutputUnit");
            RaisePropertyChangedEvent("QwOutputUnit");
            RaisePropertyChangedEvent("QvOutputUnit");
            RaisePropertyChangedEvent("QtOutputUnit");
            RaisePropertyChangedEvent("QltOutputUnit");
            RaisePropertyChangedEvent("StdVOutputUnit");
            RaisePropertyChangedEvent("PmOutputUnit");
            #endregion

            #region Case1

            RaisePropertyChangedEvent("QhcCase1");
            RaisePropertyChangedEvent("QwCase1");
            RaisePropertyChangedEvent("QvCase1");
            RaisePropertyChangedEvent("QtCase1");
            RaisePropertyChangedEvent("QltCase1");
            RaisePropertyChangedEvent("ZCase1");
            RaisePropertyChangedEvent("StdVCase1");
            RaisePropertyChangedEvent("PmCase1");
            RaisePropertyChangedEvent("QvQtCase1");
            RaisePropertyChangedEvent("SgCase1");

            #endregion

            #region Case2

            RaisePropertyChangedEvent("QhcCase2");
            RaisePropertyChangedEvent("QwCase2");
            RaisePropertyChangedEvent("QvCase2");
            RaisePropertyChangedEvent("QtCase2");
            RaisePropertyChangedEvent("QltCase2");
            RaisePropertyChangedEvent("ZCase2");
            RaisePropertyChangedEvent("StdVCase2");
            RaisePropertyChangedEvent("PmCase2");
            RaisePropertyChangedEvent("QvQtCase2");
            RaisePropertyChangedEvent("SgCase2");

            #endregion

            #region Case3

            RaisePropertyChangedEvent("QhcCase3");
            RaisePropertyChangedEvent("QwCase3");
            RaisePropertyChangedEvent("QvCase3");
            RaisePropertyChangedEvent("QtCase3");
            RaisePropertyChangedEvent("QltCase3");
            RaisePropertyChangedEvent("ZCase3");
            RaisePropertyChangedEvent("StdVCase3");
            RaisePropertyChangedEvent("PmCase3");
            RaisePropertyChangedEvent("QvQtCase3");
            RaisePropertyChangedEvent("SgCase3");

            #endregion

            #region Case4

            RaisePropertyChangedEvent("QhcCase4");
            RaisePropertyChangedEvent("QwCase4");
            RaisePropertyChangedEvent("QvCase4");
            RaisePropertyChangedEvent("QtCase4");
            RaisePropertyChangedEvent("QltCase4");
            RaisePropertyChangedEvent("ZCase4");
            RaisePropertyChangedEvent("StdVCase4");
            RaisePropertyChangedEvent("PmCase4");
            RaisePropertyChangedEvent("QvQtCase4");
            RaisePropertyChangedEvent("SgCase4");

            #endregion 

            #region Case5

            RaisePropertyChangedEvent("QhcCase5");
            RaisePropertyChangedEvent("QwCase5");
            RaisePropertyChangedEvent("QvCase5");
            RaisePropertyChangedEvent("QtCase5");
            RaisePropertyChangedEvent("QltCase5");
            RaisePropertyChangedEvent("ZCase5");
            RaisePropertyChangedEvent("StdVCase5");
            RaisePropertyChangedEvent("PmCase5");
            RaisePropertyChangedEvent("QvQtCase5");
            RaisePropertyChangedEvent("SgCase5");

            #endregion
        }

        private void ShowDesignGeometryParameters()
        {
            #region Output Units

            RaisePropertyChangedEvent("ViOutputUnit");
            RaisePropertyChangedEvent("MiOutputUnit");
            RaisePropertyChangedEvent("KHCVesselOutputUnit");
            RaisePropertyChangedEvent("VoutOutputUnit");
            RaisePropertyChangedEvent("MoutOutputUnit");
            RaisePropertyChangedEvent("DrfOutputUnit");
            RaisePropertyChangedEvent("VdrfOutputUnit");
            RaisePropertyChangedEvent("NrfOutputUnit");
            RaisePropertyChangedEvent("KwvesselOutputUnit");
            RaisePropertyChangedEvent("UactOutputUnit");

            #endregion
            

            #region Case1

            RaisePropertyChangedEvent("ViCase1");
            RaisePropertyChangedEvent("MiCase1");
            RaisePropertyChangedEvent("KHCVesselCase1");
            RaisePropertyChangedEvent("VoutCase1");
            RaisePropertyChangedEvent("MoutCase1");
            RaisePropertyChangedEvent("DrfCase1");
            RaisePropertyChangedEvent("VdrfCase1");
            RaisePropertyChangedEvent("NrfCase1");
            RaisePropertyChangedEvent("KwvesselCase1");
            RaisePropertyChangedEvent("UactCase1");

            #endregion

            #region Case2

            RaisePropertyChangedEvent("ViCase2");
            RaisePropertyChangedEvent("MiCase2");
            RaisePropertyChangedEvent("KHCVesselCase2");
            RaisePropertyChangedEvent("VoutCase2");
            RaisePropertyChangedEvent("MoutCase2");
            RaisePropertyChangedEvent("DrfCase2");
            RaisePropertyChangedEvent("VdrfCase2");
            RaisePropertyChangedEvent("NrfCase2");
            RaisePropertyChangedEvent("KwvesselCase2");
            RaisePropertyChangedEvent("UactCase2");

            #endregion

            #region Case3

            RaisePropertyChangedEvent("ViCase3");
            RaisePropertyChangedEvent("MiCase3");
            RaisePropertyChangedEvent("KHCVesselCase3");
            RaisePropertyChangedEvent("VoutCase3");
            RaisePropertyChangedEvent("MoutCase3");
            RaisePropertyChangedEvent("DrfCase3");
            RaisePropertyChangedEvent("VdrfCase3");
            RaisePropertyChangedEvent("NrfCase3");
            RaisePropertyChangedEvent("KwvesselCase3");
            RaisePropertyChangedEvent("UactCase3");

            #endregion

            #region Case4

            RaisePropertyChangedEvent("ViCase4");
            RaisePropertyChangedEvent("MiCase4");
            RaisePropertyChangedEvent("KHCVesselCase4");
            RaisePropertyChangedEvent("VoutCase4");
            RaisePropertyChangedEvent("MoutCase4");
            RaisePropertyChangedEvent("DrfCase4");
            RaisePropertyChangedEvent("VdrfCase4");
            RaisePropertyChangedEvent("NrfCase4");
            RaisePropertyChangedEvent("KwvesselCase4");
            RaisePropertyChangedEvent("UactCase4");

            #endregion

            #region Case5

            RaisePropertyChangedEvent("ViCase5");
            RaisePropertyChangedEvent("MiCase5");
            RaisePropertyChangedEvent("KHCVesselCase5");
            RaisePropertyChangedEvent("VoutCase5");
            RaisePropertyChangedEvent("MoutCase5");
            RaisePropertyChangedEvent("DrfCase5");
            RaisePropertyChangedEvent("VdrfCase5");
            RaisePropertyChangedEvent("NrfCase5");
            RaisePropertyChangedEvent("KwvesselCase5");
            RaisePropertyChangedEvent("UactCase5");

            #endregion
        }

        private void ShowSeparationEfficiency()
        {
            #region Output Units

            RaisePropertyChangedEvent("DmaxOutputUnit");
            RaisePropertyChangedEvent("SauterOutputUnit");
            RaisePropertyChangedEvent("MedOutputUnit");
            RaisePropertyChangedEvent("CutDiamOutputUnit");
            RaisePropertyChangedEvent("EntLOutputUnit");
            RaisePropertyChangedEvent("MeanOutputUnit");
            RaisePropertyChangedEvent("EntLiqHcOutputUnit");

            #endregion

            #region Case1

            RaisePropertyChangedEvent("EntHCCase1");
            RaisePropertyChangedEvent("DmaxCase1");
            RaisePropertyChangedEvent("SauterCase1");
            RaisePropertyChangedEvent("MedCase1");
            RaisePropertyChangedEvent("EfficiencyHCCase1");

            RaisePropertyChangedEvent("EntLiqHcCase1");
            RaisePropertyChangedEvent("CutDiamCase1");
            RaisePropertyChangedEvent("EntLCase1");
            RaisePropertyChangedEvent("MeanCase1");

            RaisePropertyChangedEvent("EntWCase1");
            RaisePropertyChangedEvent("DwmaxCase1");
            RaisePropertyChangedEvent("SauterWCase1");
            RaisePropertyChangedEvent("MedWCase1");
            RaisePropertyChangedEvent("EfficiencyWCase1");

            RaisePropertyChangedEvent("EntLiqWCase1");
            RaisePropertyChangedEvent("CutDiamWCase1");
            RaisePropertyChangedEvent("EntLwCase1");
            RaisePropertyChangedEvent("MeanWCase1");

            #endregion

            #region Case2

            RaisePropertyChangedEvent("EntHCCase2");
            RaisePropertyChangedEvent("DmaxCase2");
            RaisePropertyChangedEvent("SauterCase2");
            RaisePropertyChangedEvent("MedCase2");
            RaisePropertyChangedEvent("EfficiencyHCCase2");

            RaisePropertyChangedEvent("EntLiqHcCase2");
            RaisePropertyChangedEvent("CutDiamCase2");
            RaisePropertyChangedEvent("EntLCase2");
            RaisePropertyChangedEvent("MeanCase2");

            RaisePropertyChangedEvent("EntWCase2");
            RaisePropertyChangedEvent("DwmaxCase2");
            RaisePropertyChangedEvent("SauterWCase2");
            RaisePropertyChangedEvent("MedWCase2");
            RaisePropertyChangedEvent("EfficiencyWCase2");

            RaisePropertyChangedEvent("EntLiqWCase2");
            RaisePropertyChangedEvent("CutDiamWCase2");
            RaisePropertyChangedEvent("EntLwCase2");
            RaisePropertyChangedEvent("MeanWCase2");

            #endregion

            #region Case3

            RaisePropertyChangedEvent("EntHCCase3");
            RaisePropertyChangedEvent("DmaxCase3");
            RaisePropertyChangedEvent("SauterCase3");
            RaisePropertyChangedEvent("MedCase3");
            RaisePropertyChangedEvent("EfficiencyHCCase3");

            RaisePropertyChangedEvent("EntLiqHcCase3");
            RaisePropertyChangedEvent("CutDiamCase3");
            RaisePropertyChangedEvent("EntLCase3");
            RaisePropertyChangedEvent("MeanCase3");

            RaisePropertyChangedEvent("EntWCase3");
            RaisePropertyChangedEvent("DwmaxCase3");
            RaisePropertyChangedEvent("SauterWCase3");
            RaisePropertyChangedEvent("MedWCase3");
            RaisePropertyChangedEvent("EfficiencyWCase3");

            RaisePropertyChangedEvent("EntLiqWCase3");
            RaisePropertyChangedEvent("CutDiamWCase3");
            RaisePropertyChangedEvent("EntLwCase3");
            RaisePropertyChangedEvent("MeanWCase3");

            #endregion

            #region Case4

            RaisePropertyChangedEvent("EntHCCase4");
            RaisePropertyChangedEvent("DmaxCase4");
            RaisePropertyChangedEvent("SauterCase4");
            RaisePropertyChangedEvent("MedCase4");
            RaisePropertyChangedEvent("EfficiencyHCCase4");

            RaisePropertyChangedEvent("EntLiqHcCase4");
            RaisePropertyChangedEvent("CutDiamCase4");
            RaisePropertyChangedEvent("EntLCase4");
            RaisePropertyChangedEvent("MeanCase4");

            RaisePropertyChangedEvent("EntWCase4");
            RaisePropertyChangedEvent("DwmaxCase4");
            RaisePropertyChangedEvent("SauterWCase4");
            RaisePropertyChangedEvent("MedWCase4");
            RaisePropertyChangedEvent("EfficiencyWCase4");

            RaisePropertyChangedEvent("EntLiqWCase4");
            RaisePropertyChangedEvent("CutDiamWCase4");
            RaisePropertyChangedEvent("EntLwCase4");
            RaisePropertyChangedEvent("MeanWCase4");

            #endregion

            #region Case5

            RaisePropertyChangedEvent("EntHCCase5");
            RaisePropertyChangedEvent("DmaxCase5");
            RaisePropertyChangedEvent("SauterCase5");
            RaisePropertyChangedEvent("MedCase5");
            RaisePropertyChangedEvent("EfficiencyHCCase5");

            RaisePropertyChangedEvent("EntLiqHcCase5");
            RaisePropertyChangedEvent("CutDiamCase5");
            RaisePropertyChangedEvent("EntLCase5");
            RaisePropertyChangedEvent("MeanCase5");

            RaisePropertyChangedEvent("EntWCase5");
            RaisePropertyChangedEvent("DwmaxCase5");
            RaisePropertyChangedEvent("SauterWCase5");
            RaisePropertyChangedEvent("MedWCase5");
            RaisePropertyChangedEvent("EfficiencyWCase5");

            RaisePropertyChangedEvent("EntLiqWCase5");
            RaisePropertyChangedEvent("CutDiamWCase5");
            RaisePropertyChangedEvent("EntLwCase5");
            RaisePropertyChangedEvent("MeanWCase5");

            #endregion

        }

        private void ShowCharts()
        {
            RaisePropertyChangedEvent("HCDropCumulativeDistributionCase1");
            RaisePropertyChangedEvent("HCDropletDensityDistributionCase1");
            RaisePropertyChangedEvent("WaterDropCumulativeDistributionCase1");
            RaisePropertyChangedEvent("WaterDropletDensityDistributionCase1");

            RaisePropertyChangedEvent("HCDropCumulativeDistributionCase2");
            RaisePropertyChangedEvent("HCDropletDensityDistributionCase2");
            RaisePropertyChangedEvent("WaterDropCumulativeDistributionCase2");
            RaisePropertyChangedEvent("WaterDropletDensityDistributionCase2");

            RaisePropertyChangedEvent("HCDropCumulativeDistributionCase3");
            RaisePropertyChangedEvent("HCDropletDensityDistributionCase3");
            RaisePropertyChangedEvent("WaterDropCumulativeDistributionCase3");
            RaisePropertyChangedEvent("WaterDropletDensityDistributionCase3");

            RaisePropertyChangedEvent("HCDropCumulativeDistributionCase4");
            RaisePropertyChangedEvent("HCDropletDensityDistributionCase4");
            RaisePropertyChangedEvent("WaterDropCumulativeDistributionCase4");
            RaisePropertyChangedEvent("WaterDropletDensityDistributionCase4");

            RaisePropertyChangedEvent("HCDropCumulativeDistributionCase5");
            RaisePropertyChangedEvent("HCDropletDensityDistributionCase5");
            RaisePropertyChangedEvent("WaterDropCumulativeDistributionCase5");
            RaisePropertyChangedEvent("WaterDropletDensityDistributionCase5");
        }

        internal void ClearAllOutputs()
        {
            ClearProcessParameters();
            ClearDesignGeometryParameters();
            ClearSeparationEfficiency();
            ClearCharts();
        }

        private void ClearCharts()
        {
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCDropCumulativeDistributionChart = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCDropletDensityDistributionChart = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterDropCumulativeDistributionChart = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterDropletDensityDistributionChart = null;
        }

        private void ClearSeparationEfficiency()
        {
            #region Output Units

            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCDropletSizeMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCSauterMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCMedMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].HCDropletCutDiameterMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCAssumedLiquidEntrainedMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterMeanMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCTotalLiquidEntrainedMeasurementUnit = 0;

            #endregion

            #region Case1

            separatorDesign.ProcessInfo.Cases[0].InletNozzleEntrainedHCFormated = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCDropletSize = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCMax = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCSauter = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCMed = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCProjectedDrumEfficiency = null;

            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCTotalLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[0].HCDropletCutDiameter = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCAssumedLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.HCMean = null;

            separatorDesign.ProcessInfo.Cases[0].InletNozzleEntrainedWaterFormated = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterDropletSize = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterMax = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterSauter = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterMed = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterProjectedDrumEfficiency = null;

            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterTotalLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[0].WaterDropletCutDiameter = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterAssumedLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[0].EfficiencyCase.WaterMean = null;


            #endregion

            #region Case2

            separatorDesign.ProcessInfo.Cases[1].InletNozzleEntrainedHCFormated = null;
            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCDropletSize = null;
            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCMax = null;
            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCSauter = null;
            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCMed = null;
            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCProjectedDrumEfficiency = null;

            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCTotalLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[1].HCDropletCutDiameter = null; 
            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCAssumedLiquidEntrained = null; 
            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.HCMean = null;

            separatorDesign.ProcessInfo.Cases[1].InletNozzleEntrainedWaterFormated = null;
            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterDropletSize = null;
            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterMax = null;
            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterSauter = null;
            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterMed = null;
            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterProjectedDrumEfficiency = null;

            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterTotalLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[1].WaterDropletCutDiameter = null;
            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterAssumedLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[1].EfficiencyCase.WaterMean = null;

            #endregion

            #region Case3
            separatorDesign.ProcessInfo.Cases[2].InletNozzleEntrainedHCFormated = null;
            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCDropletSize = null;
            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCMax = null;
            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCSauter = null;
            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCMed = null;
            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCProjectedDrumEfficiency = null;

            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCTotalLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[2].HCDropletCutDiameter = null;
            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCAssumedLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.HCMean = null;

            separatorDesign.ProcessInfo.Cases[2].InletNozzleEntrainedWaterFormated = null;
            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterDropletSize = null;
            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterMax = null;
            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterSauter = null;
            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterMed = null;
            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterProjectedDrumEfficiency = null;

            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterTotalLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[2].WaterDropletCutDiameter = null;
            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterAssumedLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[2].EfficiencyCase.WaterMean = null;
            #endregion

            #region Case4
            separatorDesign.ProcessInfo.Cases[3].InletNozzleEntrainedHCFormated = null;
            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCDropletSize = null;
            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCMax = null;
            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCSauter = null;
            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCMed = null;
            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCProjectedDrumEfficiency = null;

            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCTotalLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[3].HCDropletCutDiameter = null;
            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCAssumedLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.HCMean = null;

            separatorDesign.ProcessInfo.Cases[3].InletNozzleEntrainedWaterFormated = null;
            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterDropletSize = null;
            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterMax = null;
            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterSauter = null;
            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterMed = null;
            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterProjectedDrumEfficiency = null;

            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterTotalLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[3].WaterDropletCutDiameter = null;
            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterAssumedLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[3].EfficiencyCase.WaterMean = null;
            #endregion

            #region Case5
            separatorDesign.ProcessInfo.Cases[4].InletNozzleEntrainedHCFormated = null;
            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCDropletSize = null;
            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCMax = null;
            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCSauter = null;
            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCMed = null;
            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCProjectedDrumEfficiency = null;

            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCTotalLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[4].HCDropletCutDiameter = null;
            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCAssumedLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.HCMean = null;

            separatorDesign.ProcessInfo.Cases[4].InletNozzleEntrainedWaterFormated = null;
            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterDropletSize = null;
            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterMax = null;
            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterSauter = null;
            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterMed = null;
            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterProjectedDrumEfficiency = null;

            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterTotalLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[4].WaterDropletCutDiameter = null;
            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterAssumedLiquidEntrained = null;
            separatorDesign.ProcessInfo.Cases[4].EfficiencyCase.WaterMean = null;
            #endregion
        }

        private void ClearDesignGeometryParameters()
        {
            #region Output Units
            separatorDesign.ProcessInfo.Cases[0].ViMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].InletNozzleCalculatedMomentumMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].KHCVesselMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].VoutMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].VaporOutletNozzleCalculatedMomentumMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].LiquidOutletNozzleCalculatedDRFMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].LiquidOutletNozzleVelocityDRFMeasuremetUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].KWaterVesselMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].UactMeasurementUnit = 0; 
            #endregion


            #region Case1

            separatorDesign.ProcessInfo.Cases[0].Vi = null;
            separatorDesign.ProcessInfo.Cases[0].InletNozzleCalculatedMomentum = null;
            separatorDesign.ProcessInfo.Cases[0].KHCVessel = null;
            separatorDesign.ProcessInfo.Cases[0].Vout = null;
            separatorDesign.ProcessInfo.Cases[0].VaporOutletNozzleCalculatedMomentum = null;
            separatorDesign.ProcessInfo.Cases[0].LiquidOutletNozzleCalculatedDRF= null;
            separatorDesign.ProcessInfo.Cases[0].LiquidOutletNozzleVelocityDRF = null;
            separatorDesign.ProcessInfo.Cases[0].FroudeNumber = null;
            separatorDesign.ProcessInfo.Cases[0].KWaterVessel = null;
            separatorDesign.ProcessInfo.Cases[0].Uact = null;

            #endregion

            #region Case2

            separatorDesign.ProcessInfo.Cases[1].Vi = null;
            separatorDesign.ProcessInfo.Cases[1].InletNozzleCalculatedMomentum = null;
            separatorDesign.ProcessInfo.Cases[1].KHCVessel = null;
            separatorDesign.ProcessInfo.Cases[1].Vout = null;
            separatorDesign.ProcessInfo.Cases[1].VaporOutletNozzleCalculatedMomentum = null;
            separatorDesign.ProcessInfo.Cases[1].LiquidOutletNozzleCalculatedDRF = null;
            separatorDesign.ProcessInfo.Cases[1].LiquidOutletNozzleVelocityDRF = null;
            separatorDesign.ProcessInfo.Cases[1].FroudeNumber = null;
            separatorDesign.ProcessInfo.Cases[1].KWaterVessel = null;
            separatorDesign.ProcessInfo.Cases[1].Uact = null;

            #endregion

            #region Case3

            separatorDesign.ProcessInfo.Cases[2].Vi = null;
            separatorDesign.ProcessInfo.Cases[2].InletNozzleCalculatedMomentum = null;
            separatorDesign.ProcessInfo.Cases[2].KHCVessel = null;
            separatorDesign.ProcessInfo.Cases[2].Vout = null;
            separatorDesign.ProcessInfo.Cases[2].VaporOutletNozzleCalculatedMomentum = null;
            separatorDesign.ProcessInfo.Cases[2].LiquidOutletNozzleCalculatedDRF = null;
            separatorDesign.ProcessInfo.Cases[2].LiquidOutletNozzleVelocityDRF = null;
            separatorDesign.ProcessInfo.Cases[2].FroudeNumber = null;
            separatorDesign.ProcessInfo.Cases[2].KWaterVessel = null;
            separatorDesign.ProcessInfo.Cases[2].Uact = null;

            #endregion

            #region Case4

            separatorDesign.ProcessInfo.Cases[3].Vi = null;
            separatorDesign.ProcessInfo.Cases[3].InletNozzleCalculatedMomentum = null;
            separatorDesign.ProcessInfo.Cases[3].KHCVessel = null;
            separatorDesign.ProcessInfo.Cases[3].Vout = null;
            separatorDesign.ProcessInfo.Cases[3].VaporOutletNozzleCalculatedMomentum = null;
            separatorDesign.ProcessInfo.Cases[3].LiquidOutletNozzleCalculatedDRF = null;
            separatorDesign.ProcessInfo.Cases[3].LiquidOutletNozzleVelocityDRF = null;
            separatorDesign.ProcessInfo.Cases[3].FroudeNumber = null;
            separatorDesign.ProcessInfo.Cases[3].KWaterVessel = null;
            separatorDesign.ProcessInfo.Cases[3].Uact = null;

            #endregion

            #region Case5

            separatorDesign.ProcessInfo.Cases[4].Vi = null;
            separatorDesign.ProcessInfo.Cases[4].InletNozzleCalculatedMomentum = null;
            separatorDesign.ProcessInfo.Cases[4].KHCVessel = null;
            separatorDesign.ProcessInfo.Cases[4].Vout = null;
            separatorDesign.ProcessInfo.Cases[4].VaporOutletNozzleCalculatedMomentum = null;
            separatorDesign.ProcessInfo.Cases[4].LiquidOutletNozzleCalculatedDRF = null;
            separatorDesign.ProcessInfo.Cases[4].LiquidOutletNozzleVelocityDRF = null;
            separatorDesign.ProcessInfo.Cases[4].FroudeNumber = null;
            separatorDesign.ProcessInfo.Cases[4].KWaterVessel = null;
            separatorDesign.ProcessInfo.Cases[4].Uact = null;

            #endregion
        }

        private void ClearProcessParameters()
        {
            #region Output Units
            separatorDesign.ProcessInfo.Cases[0].QhcMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].QwMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].QvMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].QtMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].QltMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].StdVMeasurementUnit = 0;
            separatorDesign.ProcessInfo.Cases[0].PmMeasurementUnit = 0;
            #endregion

            #region Case1
            separatorDesign.ProcessInfo.Cases[0].Qw = null;
            separatorDesign.ProcessInfo.Cases[0].Qhc = null;
            separatorDesign.ProcessInfo.Cases[0].Qv = null;
            separatorDesign.ProcessInfo.Cases[0].Qt = null;
            separatorDesign.ProcessInfo.Cases[0].Qlt = null;
            separatorDesign.ProcessInfo.Cases[0].CompressibilityFactor = null;
            separatorDesign.ProcessInfo.Cases[0].StdV = null;
            separatorDesign.ProcessInfo.Cases[0].Pm = null;
            separatorDesign.ProcessInfo.Cases[0].PercentageOfVaporByVolume = null;
            separatorDesign.ProcessInfo.Cases[0].Sg = null;
            #endregion

            #region Case2

            separatorDesign.ProcessInfo.Cases[1].Qw = null;
            separatorDesign.ProcessInfo.Cases[1].Qhc = null;
            separatorDesign.ProcessInfo.Cases[1].Qv = null;
            separatorDesign.ProcessInfo.Cases[1].Qt = null;
            separatorDesign.ProcessInfo.Cases[1].Qlt = null;
            separatorDesign.ProcessInfo.Cases[1].CompressibilityFactor = null;
            separatorDesign.ProcessInfo.Cases[1].StdV = null;
            separatorDesign.ProcessInfo.Cases[1].Pm = null;
            separatorDesign.ProcessInfo.Cases[1].PercentageOfVaporByVolume = null;
            separatorDesign.ProcessInfo.Cases[1].Sg = null;

            #endregion

            #region Case3

            separatorDesign.ProcessInfo.Cases[2].Qw = null;
            separatorDesign.ProcessInfo.Cases[2].Qhc = null;
            separatorDesign.ProcessInfo.Cases[2].Qv = null;
            separatorDesign.ProcessInfo.Cases[2].Qt = null;
            separatorDesign.ProcessInfo.Cases[2].Qlt = null;
            separatorDesign.ProcessInfo.Cases[2].CompressibilityFactor = null;
            separatorDesign.ProcessInfo.Cases[2].StdV = null;
            separatorDesign.ProcessInfo.Cases[2].Pm = null;
            separatorDesign.ProcessInfo.Cases[2].PercentageOfVaporByVolume = null;
            separatorDesign.ProcessInfo.Cases[2].Sg = null;
            #endregion

            #region Case4

            separatorDesign.ProcessInfo.Cases[3].Qw = null;
            separatorDesign.ProcessInfo.Cases[3].Qhc = null;
            separatorDesign.ProcessInfo.Cases[3].Qv = null;
            separatorDesign.ProcessInfo.Cases[3].Qt = null;
            separatorDesign.ProcessInfo.Cases[3].Qlt = null;
            separatorDesign.ProcessInfo.Cases[3].CompressibilityFactor = null;
            separatorDesign.ProcessInfo.Cases[3].StdV = null;
            separatorDesign.ProcessInfo.Cases[3].Pm = null;
            separatorDesign.ProcessInfo.Cases[3].PercentageOfVaporByVolume = null;
            separatorDesign.ProcessInfo.Cases[3].Sg = null;

            #endregion

            #region Case5

            separatorDesign.ProcessInfo.Cases[4].Qw = null;
            separatorDesign.ProcessInfo.Cases[4].Qhc = null;
            separatorDesign.ProcessInfo.Cases[4].Qv = null;
            separatorDesign.ProcessInfo.Cases[4].Qt = null;
            separatorDesign.ProcessInfo.Cases[4].Qlt = null;
            separatorDesign.ProcessInfo.Cases[4].CompressibilityFactor = null;
            separatorDesign.ProcessInfo.Cases[4].StdV = null;
            separatorDesign.ProcessInfo.Cases[4].Pm = null;
            separatorDesign.ProcessInfo.Cases[4].PercentageOfVaporByVolume = null;
            separatorDesign.ProcessInfo.Cases[4].Sg = null;

            #endregion
        }
    }
}
