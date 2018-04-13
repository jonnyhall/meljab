using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using SchwabenCode.EasySmtp;

namespace MeljabUtility
{
    public class MeljabCredentials: ICredentialsByHost
    {
        public NetworkCredential GetCredential()
        {
            var networkCredential = GetCredential("", 0, "");
            return networkCredential;
        }

        public NetworkCredential GetCredential(string host, int port, string authenticationType)
        {
            var networkCredential = new NetworkCredential("", "");
            return networkCredential;
        }
    }
}
