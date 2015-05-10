using SDTDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDTBusiness.Registers
{
    public static class MainBusinessFacade
    {
        #region JsonProcess

        public static void SalvarArquivo(IEnumerable<string> views, string path)
        {
            EnviarJson("", path, false);

            foreach (var item in views)
	        {
                EnviarJson(item, path, true);
	        }

            string message = "Arquivo Salvo com Sucesso!";
            MessageBox.Show(message);
        }

        public static void EnviarJson(string obj, string path, bool add)
        {

            File.WriteFile(obj, path, add);
        }

        public static string ObterJson(string path)
        {
            return File.ReadFile(path);
        }

        #endregion
    }
}
