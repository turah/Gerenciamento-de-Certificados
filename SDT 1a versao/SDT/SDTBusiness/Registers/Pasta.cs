using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SDTBusiness.Registers
{
    public static class Pasta
    {
        public static string path;

        public static string Abrir()
        {
            Stream myStream;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    path = openFileDialog1.FileName;
                    myStream.Close();
                    return MainBusinessFacade.ObterJson(path);
                }
            }

            return path;            
        }

        public static void Salvar(IEnumerable<string> views)
        {
            if (path == null)
            {
                SalvarComo(views);
            }
            else
            {                
                MainBusinessFacade.SalvarArquivo(views, path);
              
            }
            
        }

        public static void SalvarComo(IEnumerable<string> views)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    path = saveFileDialog1.FileName;
                    myStream.Close();
                    MainBusinessFacade.SalvarArquivo(views, path);
                }
            }
            
        }

    }
}
