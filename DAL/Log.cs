using System;
using System.IO;

namespace DAL
{
    public class Bitacora
    {
        public static string _Path { get; set; }

        public static void Write(string msg)
        {
            _Path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            using (StreamWriter w = File.AppendText(Path.Combine(_Path, "Bitacora.txt")))
            {
                Log(msg, w);
            }
        }

        static private void Log(string msg, TextWriter w)
        {
            w.Write(Environment.NewLine);
            w.Write("[{0} {1}]", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.Write("\t");
            w.WriteLine(" {0}", msg);
            w.WriteLine("-----------------------");
        }
    }
}
