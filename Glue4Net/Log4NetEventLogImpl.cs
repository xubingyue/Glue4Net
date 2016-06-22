using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glue4Net
{
    public class Log4NetEventLogImpl:MarshalByRefObject, IEventLog
    {
        public override object InitializeLifetimeService()
        {
            return null;
        }
        static Log4NetEventLogImpl()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        public log4net.ILog Log
        {
            get
            {
                return log4net.LogManager.GetLogger("Glue4Net");
            }
        }

        public void Debug(string value)
        {
            Log.Debug(value);
        }

        public void Debug(string formater, params object[] data)
        {
            Log.DebugFormat(formater, data);
        }

        public void Info(string value)
        {
            Log.Info(value);
            
        }

        public void Info(string formater, params object[] data)
        {
            Log.InfoFormat(formater, data);
        }

        public void Error(string value)
        {
            Log.Error(value);
        }

        public void Error(string formater, params object[] data)
        {
            Log.ErrorFormat(formater, data);
        }
    }
}
