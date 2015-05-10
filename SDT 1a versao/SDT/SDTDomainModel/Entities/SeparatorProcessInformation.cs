using SDTDomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDTDomainModel.Entities
{
    public class SeparatorProcessInformation
    {
        public SeparatorProcessInformation() 
        {
            this.Cases = new List<SeparatorProcessDesignCase>();
        }

        public double? Pressure { get; set; }
        public PressureUnit PressureUnit { get; set; }
        public double PressureInPascal { get; set; }

        public double? Temperature { get; set; }
        public TemperatureUnit TemperatureUnit { get; set; }
        public double TemperatureInFahrenheit { get; set; }

        public List<SeparatorProcessDesignCase> Cases { get; set; }

        public int NumberOfCasesCreatedBeyondCaseOne { get; set; }

    }
}
