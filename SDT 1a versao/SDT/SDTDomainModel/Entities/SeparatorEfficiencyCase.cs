using SDTDomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDTDomainModel.Entities
{
    public class SeparatorEfficiencyCase
    {

        public double? HCTotalLiquidEntrained { get; set; }
        public MassFlowRateUnit HCTotalLiquidEntrainedMeasurementUnit { get; set; }
        public double HCTotalLiquidEntrainedInKilogramPerSecond { get; set; }

        public double? WaterTotalLiquidEntrained { get; set; }
        public MassFlowRateUnit WaterTotalLiquidEntrainedMeasurementUnit { get; set; }
        public double WaterTotalLiquidEntrainedInKilogramPerSecond { get; set; }

        public double? WaterDropletSize { get; set; }
        public LengthUnit WaterDropletSizeMeasurementUnit { get; set; }
        public double WaterDropletSizeInMeter { get; set; }

        public double? HCDropletSize { get; set; }
        public LengthUnit HCDropletSizeMeasurementUnit { get; set; }
        public double HCDropletSizeInMeter { get; set; }

        public double? WaterSauter { get; set; }
        public LengthUnit WaterSauterMeasurementUnit { get; set; }
        public double WaterSauterInMeter { get; set; }

        public double? HCSauter { get; set; }
        public LengthUnit HCSauterMeasurementUnit { get; set; }
        public double HCSauterInMeter { get; set; }

        public double? WaterMed { get; set; }
        public LengthUnit WaterMedMeasurementUnit { get; set; }
        public double WaterMedInMeter { get; set; }

        public double? HCMed { get; set; }
        public LengthUnit HCMedMeasurementUnit { get; set; }
        public double HCMedInMeter { get; set; }

        public double? WaterMean { get; set; }
        public LengthUnit WaterMeanMeasurementUnit { get; set; }
        public double WaterMeanInMeter { get; set; }

        public double? HCMean { get; set; }
        public LengthUnit HCMeanMeasurementUnit { get; set; }
        public double HCMeanInMeter { get; set; }

        public double? WaterMax { get; set; }
        public LengthUnit WaterMaxMeasurementUnit { get; set; }
        public double WaterMaxInMeter { get; set; }

        public double? HCMax { get; set; }
        public LengthUnit HCMaxMeasurementUnit { get; set; }
        public double HCMaxInMeter { get; set; }

        public double? HCProjectedDrumEfficiency { get; set; }

        public double? WaterProjectedDrumEfficiency { get; set; }

        public double? HCAssumedLiquidEntrained { get; set; }
        public VolumeFlowRateUnit HCAssumedLiquidEntrainedMeasurementUnit { get; set; }
        public double HCAssumedLiquidEntrainedInCubicMeterPerSecond { get; set; }

        public double? WaterAssumedLiquidEntrained { get; set; }
        public VolumeFlowRateUnit WaterAssumedLiquidEntrainedMeasurementUnit { get; set; }
        public double WaterAssumedLiquidEntrainedInCubicMeterPerSecond { get; set; }

        public byte[] HCDropCumulativeDistributionChart { get; set; }
        public byte[] WaterDropCumulativeDistributionChart { get; set; }
        public byte[] HCDropletDensityDistributionChart { get; set; }
        public byte[] WaterDropletDensityDistributionChart { get; set; }

    }
}
