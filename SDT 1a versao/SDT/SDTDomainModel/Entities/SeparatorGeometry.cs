using SDTDomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDTDomainModel.Entities
{
    public class SeparatorGeometry
    {
        public double? DrumInsideDiameter { get; set; }

        public LengthUnit DrumInsideDiameterMeasurementUnit { get; set; }
        
        public double DrumInsideDiameterInMeters { get; set; } 

        #region InletNozzle

        public double? InletNozzleInsideDiameter { get; set; }
        public LengthUnit InletNozzleInsideDiameterMeasurementUnit { get; set; }
        public double InletNozzleInsideDiameterInMeter { get; set; } 

        public double? InletNozzleMaxMomentum { get; set; }
        public MomentumUnit InletNozzleMaxMomentumMeasurementUnit { get; set; }
        
        public NumberOfInletNozzles NumberOfInletNozzles { get; set; }

        public InletDevices InletDevice { get; set; }

        #endregion

        #region Efficiency of Gravity Separation Sector

        public double? HCInitialGuessForDropletSize { get; set; }
        public LengthUnit HCInitialGuessForDropletSizeMeasurementUnit { get; set; }
        public double HCInitialGuessForDropletSizeInMeter { get; set; }

        public double? WaterInitialGuessForDropletSize { get; set; }
        public LengthUnit WaterInitialGuessForDropletSizeMeasurementUnit { get; set; }
        public double WaterInitialGuessForDropletSizeInMeter { get; set; }
        
        #endregion

        #region OutletNozzle

        public double? VaporOutletNozzleInsideDiameter { get; set; }
        public LengthUnit VaporOutletNozzleInsideDiameterMeasurementUnit { get; set; }
        public double VaporOutletNozzleInsideDiameterInMeter { get; set; } 

        public double? VaporOutletNozzleMaxMomentum { get; set; }
        public MomentumUnit VaporOutletNozzleMaxMomentumMeasurementUnit { get; set; }

        public double? LiquidOutletNozzleInsideDiameter { get; set; }
        public LengthUnit LiquidOutletNozzleInsideDiameterMeasurementUnit { get; set; }
        public double LiquidOutletNozzleInsideDiameterInMeter { get; set; } 

        #endregion
    }
}
