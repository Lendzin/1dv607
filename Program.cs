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
            FileHandler fileHandler = new FileHandler();
            members.AddMultipleMembers(fileHandler.LoadMemberList());
            ViewHandler viewHandler = new ViewHandler(members);
            viewHandler.StartView();
            return 0;
        }
    }
}
            

