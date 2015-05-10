using SDTDomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDTDomainModel.Entities
{
    public class SeparatorDesign
    {
        public SeparatorDesign()
        {
            Aluno = new Aluno();
            //ProcessInfo = new SeparatorProcessInformation();
            //Geometry = new SeparatorGeometry();
        }

        public Aluno Aluno { get; set; }

        //public SeparatorProcessInformation ProcessInfo { get; set; }

        //public SeparatorGeometry Geometry { get; set; }

        //public MeasurementUnitSystem MeasurementUnitSystem { get; set; }

        //public CorrelationType CorrelationType { get; set; }
    
    }
}
