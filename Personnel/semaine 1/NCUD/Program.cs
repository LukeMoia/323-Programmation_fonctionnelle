using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string directory = Directory.GetCurrentDirectory() + "..\\..\\..\\";
                // Console.WriteLine(Directory.GetCurrentDirectory());
                string[] dirs = Directory.GetDirectories(directory, "*");
                string[] files = Directory.GetFiles(directory, "*");
                // IEnumerable<string> dirs = Directory.EnumerateDirectories(directory);


                // files

                foreach (string file in files)
                {
                    // Console.WriteLine(dir);
                    string splt = Path.GetFileName(file);
                    FileInfo fi = new FileInfo(file);
                    Console.WriteLine(splt);
                    Console.WriteLine(fi.Length);
                }

                // directory

                foreach (string dir in dirs)
                {
                    // Console.WriteLine(dir);
                    string splt = Path.GetFileName(dir);
                    Console.WriteLine(splt);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            Console.ReadLine();
        }
    }
}
