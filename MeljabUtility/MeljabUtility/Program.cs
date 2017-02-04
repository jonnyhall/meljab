using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Security.Principal;
using System.Net;
using System.Net.Mail;
using System.Net.Http;
using System.Xml;
using System.Text.RegularExpressions;
using SchwabenCode.EasySmtp;


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
            var task = command.Replace(".txt", "").Replace(".gdoc", "");

            if (!string.IsNullOrEmpty(task) && !task.ToLower().Contains("ipaddress"))
            {
                string path = string.Format(@"{0}\BatchFiles\{1}.bat", AppDomain.CurrentDomain.BaseDirectory, task);
                System.Diagnostics.Process.Start(path);
                return;
            }

            if (!string.IsNullOrEmpty(task) && task.ToLower().Contains("ipaddress")) {
                var ipaddress = GETExternalIpAddress("http://checkip.dyndns.org");
                SendEmail(ipaddress);
            }
        }

        public static string GETExternalIpAddress(string url)
        {
            try
            {
                var data = GET(url);
                var ipAddress = "Could not get ipaddress";
                var dataXml = new XmlDocument();
                if (!string.IsNullOrEmpty(data))
                {
                    dataXml.LoadXml(data);

                    ipAddress = dataXml.SelectSingleNode("html/body").InnerText;
                    return ipAddress;
                }                

                return ipAddress;
            }
            catch (Exception e)
            {                
                return e.Message;
            }           
        }

        public static void SendEmail(string from, string to, string subject, string messageText)
        {
            MeljabCredentials meljabCredentials = new MeljabCredentials();
            ICredentialsByHost creds = meljabCredentials.GetCredential();
            SchwabenCode.EasySmtp.GMailSmtp gmailSmtp = new GMailSmtp(creds);
            MailMessage mailMessage = new MailMessage(from, to, subject, messageText);
            gmailSmtp.Send(mailMessage);
        }


        public static void SendEmail(string messageText)
        {
            MeljabCredentials meljabCredentials = new MeljabCredentials();
            ICredentialsByHost creds = meljabCredentials.GetCredential();
            SchwabenCode.EasySmtp.GMailSmtp gmailSmtp = new GMailSmtp(creds);
            MailMessage mailMessage = new MailMessage("jonnyhall@hotmail.com", "meljab@gmail.com", "From MeljabUtility: Your External IP Address", messageText);
            gmailSmtp.Send(mailMessage);
        }


        public static string GET(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                string data = reader.ReadToEnd();

                reader.Close();
                stream.Close();

                return data;
            }
            catch (Exception e)
            {
                throw e;
            }           
        }
    }
}
