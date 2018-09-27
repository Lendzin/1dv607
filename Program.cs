using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2
{
    class Program
    {
        static int Main(string[] args)
        {
            Members members = new Members();
            members.Load();
            ViewHandler viewHandler = new ViewHandler(members);
            viewHandler.Options();
            return 0;
        }
    }
}
            

