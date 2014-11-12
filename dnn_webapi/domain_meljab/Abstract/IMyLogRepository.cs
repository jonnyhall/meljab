using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain_meljab.Abstract
{
    public interface IMyLogRepository
    {
        IQueryable<dnn_YourCompany_LogEntry> Get();
        IQueryable<dnn_YourCompany_LogEntry> Get(string keyWord);
        int Post(dnn_YourCompany_LogEntry logEntry);
        void Put(dnn_YourCompany_LogEntry logEntry);
        void Delete(int itemid);

    }
}
