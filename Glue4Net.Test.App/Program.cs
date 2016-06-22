using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glue4Net.Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            

            DomainAdapter da = new DomainAdapter(@"C:\Test",
                "TEST", new DomainArgs { Compiler=true, UpdateWatch= true, WatchFilter=new string[]{"*.cs"} });
            da.Log = new ConsoleEventLogImpl();
            da.Load();
          
            Console.Read();
        }
    }
   
}
