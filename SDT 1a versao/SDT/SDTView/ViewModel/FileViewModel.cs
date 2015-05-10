using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SDTBusiness.Registers;
using SDTBusiness.Unity;
using System.Windows;
using SDTPresentation.Utils;

namespace SDTPresentation.ViewModel
{
    public static class FileViewModel
    {
        public static string path;

        public static string Open()
        {
            //Stream myStream;

            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            //openFileDialog1.FilterIndex = 2;
            //openFileDialog1.RestoreDirectory = true;

            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    if ((myStream = openFileDialog1.OpenFile()) != null)
            //    {
            //        path = openFileDialog1.FileName;
            //        myStream.Close();
            //        return FileBusinessFacade.GetJson(path);
            //    }
            //}
            //else
            //{
            //    return null;
            //}

            //path = ".\\Utils\\Base de Dados\\TestandoNovaEstrutura.txt";
            //path = "C:\\Users\\turah\\Desktop\\SDT 1a versao\\SDT\\SDTView\\Utils\\Base de Dados\\TestandoNovaEstrutura.txt";
            path = "CertificadosDB_NAOEXCLUIR.cdb";
            return FileBusinessFacade.GetJson(path);
        }

        public static void Save(string views, bool showReturnMessage)
        {
            if (path == null)
            {
                //SaveAs(views);
                path = "CertificadosDB_NAOEXCLUIR.cdb";
            }
            else
            {
                FileBusinessFacade.SaveFile(views, path, showReturnMessage);
            }

        }
    }
}
