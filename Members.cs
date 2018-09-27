using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2 {
    class Members {
        private List<Member> MemberList;

        public Members () {
            MemberList = new List<Member>();
        }
        public void AddMember() 
        {
            int value;
            do 
            {
            Console.WriteLine("pooop!, 0 to exit.");
            ConsoleKeyInfo input = Console.ReadKey(true);
            if (char.IsDigit(input.KeyChar))
                    {
                        Int32.TryParse(input.KeyChar.ToString(), out value);
                    } else {
                        value = 4;
                    }

            } while (value != 0);
        }
        public void DeleteMember() {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("# Deleting a member is a permanent action! #");
            Console.ResetColor();
            Console.WriteLine();
            this.DoAction("delete");
        }
        public void ViewMember() {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("# View Member Section #");
            Console.ResetColor();
            Console.WriteLine();
            this.DoAction("view");
        }

        private void DoAction(string action) {
            int value;
            do 
            {
                int count = this.MemberList.Count();
                if (count == 0) {
                    Console.WriteLine("No Members in the list. Type: 0 to exit.");
                } else {
                if (action == "delete") {
                    Console.WriteLine($"Type a Member ID between {1} and {count}, to delete it. Type: 0 to exit.");
                }
                if (action == "view") {
                    Console.WriteLine($"Type a Member ID between {1} and {count}, to view information. Type: 0 to exit.");
                }
            }
            ConsoleKeyInfo input = Console.ReadKey(true);
            if (char.IsDigit(input.KeyChar))
                    {
                        Int32.TryParse(input.KeyChar.ToString(), out value);
                    } else {
                        value = count +1;
                    }
                    if (value > 0 && value < count+1) {
                        if (action == "delete") {
                            Member member = this.FindMemberInList(value);
                            member.View();
                        }
                        if (action == "view") {
                            Member member = this.FindMemberInList(value);
                            this.DeleteMemberFromList(member);
                        }
                        
                    }

            } while (value != 0);
        }
        

        private Member FindMemberInList(int memberID) {
        foreach (Member controlMember in MemberList) 
            {
                if (controlMember.ListId != memberID) {
                    return controlMember;
                }
            }
            throw new Exception("That is not a member!");
        }
        private void DeleteMemberFromList(Member member) 
        {
            MemberList.Remove(member);
            Console.WriteLine("Member deleted.");
        }
        // public List<Member> GetList() 
        // {
        //     return MemberList;
        // }
        // public void ListMembers() 
        // {
        //     Console.WriteLine(MemberList.Count);
        //     foreach (Member controlMember in MemberList) 
        //     {
        //         Console.WriteLine(controlMember.ToString());
        //     }
        // }
        public void ListCompact()
        {
            // add code for printing
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Member's info: COMPACT:");
            Console.ResetColor();
            //name, memberID, number of boats.
        }
        public void ListVerbose() 
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Member's info: VERBOSE:");
            Console.ResetColor();
            // add code for printing
            // name, personalNR, memberID, boats, boat-info
        }

        public void Save() 
        {
            // add code.
        }

        public void Load() 
        {
            // add code.
        }
    }
}