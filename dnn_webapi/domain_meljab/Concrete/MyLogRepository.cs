using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain_meljab;
using domain_meljab.Abstract;
using System.Data.Entity;


namespace domain_meljab.Concrete
{
   public class MyLogRepository:IMyLogRepository
    {
        #region IMyLogRepository Members

       public IQueryable<dnn_YourCompany_LogEntry> Get()
        {
            IQueryable<dnn_YourCompany_LogEntry> items = null;
            var transactionOptions = new System.Transactions.TransactionOptions();
            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;

            using (var transactionScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, transactionOptions))
            {
                using (dotnetnukeEntities db = new dotnetnukeEntities())
                {
                    try
                    {
                        db.Configuration.ProxyCreationEnabled = false;
                        items = db.dnn_YourCompany_LogEntry
                            .ToList().OrderBy(e => e.ItemID).AsQueryable<dnn_YourCompany_LogEntry>();

                        //db.Configuration.ProxyCreationEnabled = false;
                        //items = db.dnn_YourCompany_LogEntry
                        //    .ToList().OrderByDescending(e => e.ItemID).Take(25).AsQueryable<dnn_YourCompany_LogEntry>();
                    }
                    catch (Exception e)
                    {
                        string error = e.Message;
                    }
                }
                transactionScope.Complete();
            }
            return items;
        }

       public IQueryable<dnn_YourCompany_LogEntry> Get(string keyWord)
        {
            IQueryable<dnn_YourCompany_LogEntry> items = null;
            var transactionOptions = new System.Transactions.TransactionOptions();
            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;

            using (var transactionScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, transactionOptions))
            {
                using (dotnetnukeEntities db = new dotnetnukeEntities())
                {
                    try
                    {
                        db.Configuration.ProxyCreationEnabled = false;
                        items = db.dnn_YourCompany_LogEntry
                             .Where(e => e.Entry.ToLower().Contains(keyWord.ToLower()))
                            .ToList().AsQueryable<dnn_YourCompany_LogEntry>();
                    }
                    catch (Exception e)
                    {
                        string error = e.Message;
                    }
                }
                transactionScope.Complete();
            }
            return items;
        }

       public int Post(dnn_YourCompany_LogEntry logEntry)
       {
           var transactionOptions = new System.Transactions.TransactionOptions();
           transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
           int newItemid = 0;
           using (var transactionScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, transactionOptions))
           {
               using (dotnetnukeEntities db = new dotnetnukeEntities())
               {
                   try
                   {
                       db.Configuration.ProxyCreationEnabled = false;
                       logEntry.CreatedDate = DateTime.Now;
                       logEntry.EntryDate = DateTime.Now;
                       logEntry.ModuleID = 380;
                       db.Set<dnn_YourCompany_LogEntry>().Add(logEntry);
                       db.SaveChanges();
                       newItemid = logEntry.ItemID;
                   }
                   catch (Exception e)
                   {
                       string error = e.Message;
                   }
               }
               transactionScope.Complete();

           }
           return newItemid;
       }

       public void Put(dnn_YourCompany_LogEntry logEntry)
       {
           var transactionOptions = new System.Transactions.TransactionOptions();
           transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
         
           using (var transactionScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, transactionOptions))
           {
               using (dotnetnukeEntities db = new dotnetnukeEntities())
               {
                   try
                   {
                       dnn_YourCompany_LogEntry _logEntry = db.dnn_YourCompany_LogEntry
                             .Where(e => e.ItemID == logEntry.ItemID).FirstOrDefault();
                       if (_logEntry != null)
                       {
                           db.Configuration.ProxyCreationEnabled = false;
                          
                           if (_logEntry.EntryDate == null)
                               _logEntry.EntryDate = DateTime.Now;

                           _logEntry.Entry = logEntry.Entry;
                          
                           db.SaveChanges();
                       }
                       else
                           Post(logEntry);
                     
                       
                   }
                   catch (Exception e)
                   {
                       string error = e.Message;
                   }
               }
               transactionScope.Complete();

           }
          
       }

       public void Delete(int itemid)
       {
           var transactionOptions = new System.Transactions.TransactionOptions();
           transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;

           using (var transactionScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, transactionOptions))
           {
               using (dotnetnukeEntities db = new dotnetnukeEntities())
               {
                   try
                   {
                       dnn_YourCompany_LogEntry _logEntry = db.dnn_YourCompany_LogEntry
                             .Where(e => e.ItemID == itemid).FirstOrDefault();
                       if (_logEntry != null)
                       {
                           db.Configuration.ProxyCreationEnabled = false;
                           db.Set<dnn_YourCompany_LogEntry>().Remove(_logEntry);
                           db.SaveChanges();
                       }
                   }
                   catch (Exception e)
                   {
                       string error = e.Message;
                   }
               }
               transactionScope.Complete();
           }
       }

        #endregion

       
    }
}
