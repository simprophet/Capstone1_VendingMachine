using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachFileWriter
    {
        private string path;

        public VendingMachFileWriter(string path)
        {
            if (path == "")
            {
                string currentDir = Directory.GetCurrentDirectory();
                string fileName = "Log.txt";
                this.path = Path.Combine(currentDir, fileName);
            }
            else
            {
                this.path = path;
            }
        }

        public void LogMessage(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    string[] outputMessage = message.Split('|');

                    foreach(string s in outputMessage)
                    {
                        sw.Write(s);
                    }
                    sw.WriteLine();
                }
            }
            catch (IOException e1)
            {
                Console.WriteLine(e1.ToString() + e1.Message);
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.ToString() + e2.Message);
            }
        }
    }
}
