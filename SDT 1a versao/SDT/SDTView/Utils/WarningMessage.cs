using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDTPresentation.Utils
{
    public static class WarningMessage
    {
        #region Titles

        public const string WARNING = "Warning";
        public const string SUCCESS = "Success";
        public const string ERROR = "Error";

        #endregion

        #region Geometry Output

        public const string NOTRECOMMENDEDFORNEWDESIGNS = "The inlet device selected is not recommended for new designs, only for rating.";
        public const string NOTRECOMMENDEDFORTHREEPHASESEPARATORS = "The inlet device selected is not recommended for three-phase separators.";
        public const string NOTRECOMMENDEDFORMOSTNEWSERVICES = "The inlet device selected is not recommended for most new services, only for rating.";
        public const string ENTERDRUMINSIDEDIAMETERWATER = "Please enter a Drum Inside Diameter to calculate Water Smallest Droplet Diameter.";
        public const string ENTERDRUMINSIDEDIAMETERHYDROCARBON = "Please enter a Drum Inside Diameter to calculate Hydrocarbon Smallest Droplet Diameter.";
        public const string ENTERDRUMINSIDEDIAMETER = "Please enter a Drum Inside Diameter.";        
        public const string INSIDEDIAMETERLIQUIDOUTLETNOZZLEISNOTACCEPTABLE = "Value is not acceptable.";
        public const string BADESTIMATEFORDROPLETSIZE = "Bad estimate for droplet size. Try another one.";

        #endregion

        #region Process Information

        public const string ATLEASTONECOLUMNENABLED = "At least one column must be enabled.";

        #endregion

        #region File

        public const string FILEHASBEENSAVED = "Alterações salvas!";        
        public const string UNEXPECTEDFILEFORMAT = "Erro ao carregar arquivo que armazena os dados do sistema.";

        #endregion

    }
}
