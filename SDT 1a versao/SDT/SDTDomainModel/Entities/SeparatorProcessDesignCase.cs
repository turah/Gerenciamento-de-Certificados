using SDTDomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDTDomainModel.Entities
{
    public class SeparatorProcessDesignCase
    {
        public SeparatorProcessDesignCase()  {
            this.EfficiencyCase = new SeparatorEfficiencyCase();
        }

        #region Vapor

        public double? VaporMassFlowRate { get; set; }
        public MassFlowRateUnit VaporMassFlowRateMeasurementUnit { get; set; }
        public double VaporMassFlowRateInKilogramPerSecond { get; set; }

        public double? VaporMassDensity { get; set; }
        public MassDensityUnit VaporMassDensityMeasurementUnit { get; set; }
        public double VaporMassDensityInKilogramPerCubicMeter { get; set; }

        public double? VaporViscosity { get; set; }
        public ViscosityUnit VaporViscosityMeasurementUnit { get; set; }
        public double VaporViscosityInKilogramPerMeterSecond { get; set; }


        public double? VaporMolecularWeight { get; set; }
        public MolecularWeightUnit VaporMolecularWeightMeasurementUnit { get; set; }
        public double VaporMolecularWeightInKilogramPerKilogramMol { get; set; }

        #endregion

        #region Hydrocarbon
        
        public double? KHCVessel { get; set; }
        public VelocityUnit KHCVesselMeasurementUnit { get; set; }
        public double KHCVesselInMeterPerSecond { get; set; }

        public double? HCMassFlowRate { get; set; }
        public MassFlowRateUnit HCMassFlowRateMeasurementUnit { get; set; }
        public double HCMassFlowRateInKilogramPerSecond { get; set; }

        public double? HCMassDensity { get; set; }
        public MassDensityUnit HCMassDensityMeasurementUnit { get; set; }
        public double HCMassDensityInKilogramPerCubicMeter { get; set; }

        public double? HCViscosity { get; set; }
        public ViscosityUnit HCViscosityMeasurementUnit { get; set; }
        public double HCViscosityInKilogramPerMeterSecond { get; set; }
        
        public double? HCSurfaceTension { get; set; }
        public SurfaceTensionUnit HCSurfaceTensionMeasurementUnit { get; set; }
        public double HCSurfaceTensionInNewtonPerMeter { get; set; }

        #endregion

        #region Water

        public double? KWaterVessel { get; set; }
        public VelocityUnit KWaterVesselMeasurementUnit { get; set; }
        public double KWaterVesselInMeterPerSecond { get; set; }

        public double? WaterMassFlowRate { get; set; }
        public MassFlowRateUnit WaterMassFlowRateMeasurementUnit { get; set; }
        public double WaterMassFlowRateInKilogramPerSecond { get; set; }

        public double? WaterMassDensity { get; set; }
        public MassDensityUnit WaterMassDensityMeasurementUnit { get; set; }
        public double WaterMassDensityInKilogramPerCubicMeter { get; set; }

        public double? WaterViscosity { get; set; }
        public ViscosityUnit WaterViscosityMeasurementUnit { get; set; }
        public double WaterViscosityInKilogramPerMeterSecond { get; set; }

        public double? WaterSurfaceTension { get; set; }
        public SurfaceTensionUnit WaterSurfaceTensionMeasurementUnit { get; set; }
        public double WaterSurfaceTensionInNewtonPerMeter { get; set; }

        #endregion

        #region GeometryOutputs

        public double? InletNozzleCalculatedMomentum { get; set; }
        public MomentumUnit InletNozzleCalculatedMomentumMeasurementUnit { get; set; }
        public double MiInKilogramPerMeterSquareSecond { get; set; } // Inlet Nozzle Calculated Momentum

        public double? VaporOutletNozzleCalculatedMomentum { get; set; }
        public MomentumUnit VaporOutletNozzleCalculatedMomentumMeasurementUnit { get; set; }
        public double MoutInKilogramPerMeterSquareSecond { get; set; } // Outlet Nozzle Calculated Momentum

        public double? InletNozzleEntrainedHC { get; set; }
        public double? InletNozzleEntrainedHCFormated { get; set; }
        public double? InletNozzleEntrainedWater { get; set; }
        public double? InletNozzleEntrainedWaterFormated { get; set; }
                
        public double? HCDropletCutDiameter { get; set; }
        public LengthUnit HCDropletCutDiameterMeasurementUnit { get; set; }
        public double HCDropletCutDiameterInMeter { get; set; }

        public double? WaterDropletCutDiameter { get; set; }
        public LengthUnit WaterDropletCutDiameterMeasurementUnit { get; set; }
        public double WaterDropletCutDiameterInMeter { get; set; }

        public bool HCDropletCutDiameterBadEstimateValue { get; set; }
        public bool WaterDropletCutDiameterBadEstimateValue { get; set; }

        public double? LiquidOutletNozzleVelocityDRF { get; set; }
        public VelocityUnit LiquidOutletNozzleVelocityDRFMeasuremetUnit { get; set; }
        public double LiquidOutletNozzleVelocityDRFInMeterPerSecond { get; set; }
        public bool LiquidOutletNozzleInsideDiameterNOTAcceptable { get; set; }

        public double? LiquidOutletNozzleCalculatedDRF { get; set; }
        public LengthUnit LiquidOutletNozzleCalculatedDRFMeasurementUnit { get; set; }
        public double LiquidOutletNozzleCalculatedDRFInMilimeter { get; set; }

        public double? Qhc { get; set; }
        public VolumeFlowRateUnit QhcMeasurementUnit { get; set; }
        public double QhcInCubicMeterPerSecond { get; set; } //Hydrocarbon Volumetric Flow Rate At Inlet Conditions

        public double? Qw { get; set; }
        public VolumeFlowRateUnit QwMeasurementUnit { get; set; }
        public double QwInCubicMeterPerSecond { get; set; } //Water Volumetric Flow Rate At Inlet Conditions

        public double? Qv{ get; set; }
        public VolumeFlowRateUnit QvMeasurementUnit { get; set; }
        public double QvInCubicMeterPerSecond { get; set; } //Vapor Volumetric Flow Rate At Inlet Conditions

        public double? Qt { get; set; }
        public VolumeFlowRateUnit QtMeasurementUnit { get; set; }
        public double QtInCubicMeterPerSecond { get; set; } // Total Flow Rate

        public double? Qlt { get; set; }
        public VolumeFlowRateUnit QltMeasurementUnit { get; set; }
        public double QltInCubicMeterPerSecond { get; set; } // Total Liquid Flow Rate

        public double? Pm { get; set; }
        public MassDensityUnit PmMeasurementUnit { get; set; }
        public double PmInKilogramPerCubicMeter { get; set; } //Medium Mass Density

        public double AiInSquareMeter { get; set; } // Inlet nozzle area

        public double? Vi { get; set; }
        public VelocityUnit ViMeasurementUnit { get; set; }
        public double ViInMeterPerSecond { get; set; } // Velocity through Inlet nozzle 

        public double AoutInSquareMeter { get; set; } // Outlet nozzle area

        public double? Vout { get; set; }
        public VelocityUnit VoutMeasurementUnit { get; set; }
        public double VoutInMeterPerSecond { get; set; } // Velocity through Outlet nozzle 

        public double AtInSquareMeter { get; set; }

        public double? CompressibilityFactor { get; set; }
        public double? Sg { get; set; } // Vapor Specific Gravity
        public double? FroudeNumber { get; set; }


        public double? StdV { get; set; } //Standard Volumetric Flow Rate
        public VolumeFlowRateUnit StdVMeasurementUnit { get; set; }
        public double StdVInCubicMeterPerSecond { get; set; }

        public double? PercentageOfVaporByVolume { get; set; }

        public double? Uact { get; set; } // Actual Vapor Superficial Velocity
        public VelocityUnit UactMeasurementUnit { get; set; }
        public double UactInMeterPerSecond { get; set; }

        public SeparatorEfficiencyCase EfficiencyCase { get; set; }

        #endregion

        #region temporário

        public bool isChecked { get; set; }
        
        #endregion
    }
}

