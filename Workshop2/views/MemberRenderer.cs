using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2 {

    class MemberRenderer {
        private HelpFunctions hf = new HelpFunctions();

        public void ShowListCompactView(MembersIndex members)  
        {
            hf.ChangeColorGreenAddLine();
            Console.WriteLine("Member's info: COMPACT:");
            hf.ResetColorAddLine();
            if (members.GetCount() != 0) {
                Console.WriteLine("{0, -10} {1,15} {2,20}\n", "Member", "MemberID", "No. of Boats");
                foreach (Member member in members.GetList()) {
                    Console.WriteLine("{0, -10} {1,8} {2,16}\n", member.Name, member.MemberId, member.CountBoats());
                }
            } else {
                Console.WriteLine("No members in the list.");
            }
            hf.Pause();
        }
        public void ShowListVerboseView(MembersIndex members)
        {
            hf.ChangeColorGreenAddLine();
            Console.WriteLine("Members info: VERBOSE:");
            hf.ResetColorAddLine();
            if (members.GetCount() != 0)
            {
                foreach (Member member in members.GetList())
                {
                Console.WriteLine("--------------- Member Info ---------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("{0, -10} {1,15} {2,20} {3,25}\n", "Member", "PersonalNR", "MemberID", "No. of Boats");
                Console.WriteLine("{0, -10} {1,10} {2,22} {3,21}\n", member.Name, member.PersonalNr, member.MemberId, member.CountBoats());
                    if (member.CountBoats() != 0)
                    {
                        Console.WriteLine("--------------- Boats owned by member -----------------------------------------------------------------------");
                        Console.WriteLine();
                        foreach(Boat boat in member.GetBoats()) {
                            Console.WriteLine("{0, 0} {1,0} {2,10} {3,0}\n", "Type: ", boat.BoatType, "Length: ", boat.Length);
                        }
                    }
                }
            } else {
                Console.WriteLine("No members in the list.");
            }
            hf.Pause();
        }

        public void ShowMemberDetails(Member member)
        {
            hf.ChangeColorBlueAddLine();
            Console.WriteLine($":: MEMBER ID #{member.MemberId} ::");
            hf.ResetColorAddLine();
            Console.WriteLine($"Name: {member.Name}");
            Console.WriteLine($"Personal Number: {member.PersonalNr}");
            hf.ChangeColorBlueAddLine();
            Console.WriteLine($":: OWNED BOATS #{member.BoatsOwned.Count} ::");
            hf.ResetColorAddLine();
            foreach (Boat boat in member.BoatsOwned)
            {
                Console.WriteLine($"Boat Length:{boat.Length}");
                Console.WriteLine($"Boat Type:{boat.BoatType}");
            }
            hf.ResetColorAddLine();
        }
    }
}