using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glue4Net.Test.Demo
{
    public interface ITest
    {
        int Add(int value);
    }
    public class TestImpl :MarshalByRefObject,ITest
    {
        private int i = 0;

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public int Add(int value)
        {
            i++;
            return i;
        }
    }
    public class TestModule : IAppModule
    {

        public string Name
        {
            get {return "TEST"; }
        }

        public IEventLog Log
        {
            get;
            set;
        }

        public void Load()
        {
            Context.Current.CreateProxyObjectHandler = (type) => {
                if (type == "test")
                    return new TestImpl();
                return null;
            };
        }

        public void UnLoad()
        {
           
        }
    }
}
