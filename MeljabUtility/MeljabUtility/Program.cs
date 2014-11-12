using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Security.Principal;

namespace MeljabUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckAndExecuteUtilFolder();
        }

        private static void CheckAndExecuteUtilFolder()
        {
            using (WindowsIdentity.Impersonate(IntPtr.Zero))
            {
                string strUtilFile = ConfigurationManager.AppSettings["UtilFile"];
                DirectoryInfo dinfo = new DirectoryInfo(strUtilFile);

            //    string command = System.IO.File.ReadAllText(strUtilFile);
                FileInfo[] Files = dinfo.GetFiles();

                foreach (FileInfo file in Files)
                {
                    ExecuteCommand(file.Name);
                    string utilPath = string.Format(@"{0}\{1}",strUtilFile,file.Name);
                    System.IO.File.Delete(utilPath);
                }
            }         
         
        }

        private static void ExecuteCommand(string command)
        {
            string path = string.Format(@"{0}\BatchFiles\{1}.bat", AppDomain.CurrentDomain.BaseDirectory, command.Replace(".txt", "").Replace(".gdoc",""));
            System.Diagnostics.Process.Start(path);
        }
    }
}
