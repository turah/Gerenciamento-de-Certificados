using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SDTDataAccess
{
    public static class FileDataAcces
    {
        public static void WriteFile(string obj, string path, bool add)
        {
            StreamWriter wr = new StreamWriter(path, add);
            wr.Write(obj);
            wr.Close();
        }

        public static string ReadFile(string path)
        {
            StreamReader rd = new StreamReader(path);
            string obj = rd.ReadLine();
            rd.Close();
            return obj;
        }

    }
}

