using SDTDataAccess;
using SDTBusiness.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDTFramework.Utils.Log;

namespace SDTBusiness.Registers
{
    public class FileBusinessFacade : BaseUnity
    {
        #region JsonProcess

        public static void SaveFile(string views, string path, bool showReturnMessage)
        {
   
            SendJson("", path, false);

            SendJson(views, path, true);

            const string SUCCESS = "Sucesso";
            const string FILEHASBEENSAVED = "Alterações Salvas!";

            if (showReturnMessage)
            {
                MessageBox.Show(FILEHASBEENSAVED, SUCCESS);
            }
        }

        public static void SendJson(string obj, string path, bool add)
        {
            FileDataAcces.WriteFile(obj, path, add);
        }

        public static string GetJson(string path)
        {
            return FileDataAcces.ReadFile(path);
        }

        #endregion
    }
}
