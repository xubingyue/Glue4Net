using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glue4Net
{
    public class Context
    {
        private Dictionary<string, object> mProperties = new Dictionary<string, object>();

        public EventCreateProxyObject CreateProxyObjectHandler
        {
            get;
            set;
        }

        public object this[string name]
        {
            get
            {
                object result = null;
                mProperties.TryGetValue(name, out result);
                return result;
            }
            set
            {
                mProperties[name] = value;
            }
        }

        private static Context mCurrent = new Context();

        public IEventLog Log
        {
            get;
            set;
        }

        public static Context Current
        {
            get
            {
                return mCurrent;
            }
        }

        public delegate object EventCreateProxyObject(string name);

        public object CreateProxyObject(string name)
        {
            if (CreateProxyObjectHandler == null)
                return null;
            return CreateProxyObjectHandler(name);
        }
    }
}
