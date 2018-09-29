using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2 {

    class ViewHandler {

        private Members _members;

       public Members Members
        {
            get
            {
                return _members;
            }
            set
            {
                _members = value;
            }
        }
        public ViewHandler(Members members) {
            this._members = members;
        }
        public void StartView(){
            int value;
            int options = 6;
            do
            {
                do
                {
                    ChangeColorBlueAddLine();
                    Console.WriteLine("Welcome to the members and boat listings, choose an OPTION:");
                    ResetColorAddLine();
                    Console.WriteLine("0. To exit the application.");
                    Console.WriteLine("1. Show list of members (COMPACT).");
                    Console.WriteLine("2. Show list of members (VERBOSE)");
                    Console.WriteLine("3. Add a member to the list.");
                    Console.WriteLine("4. Delete a member in the list.");
                    Console.WriteLine("5. View a member in the list.");
                    Console.WriteLine("6. Edit a member in the list.");
                    ConsoleKeyInfo input = Console.ReadKey(true);
                    if (char.IsDigit(input.KeyChar))
                    {
                        Int32.TryParse(input.KeyChar.ToString(), out value);
                    } else {
                        value = options + 1;
                    }
                } while ( value < 0 || value > 6);

                if (value == 1)
                {
                    this.ShowListCompactView();
                }

                if (value == 2)
                {
                    this.ShowListVerboseView();
                }

                if (value == 3)
                {
                    this.ShowAddMemberView();
                }
                if (value == 4)
                {
                   this.ShowDeleteMemberView();
                }
                if (value == 5)
                {
                    this.ShowMemberView();
                }
                if (value == 6)
                {
                    this.ShowEditMemberView();
                }
            } while (value != 0);
            ChangeColorRedAddLine();
            Console.WriteLine("Application Terminated.");
            ResetColorAddLine();
        }

        public void ShowListCompactView()
        {
            // add code for printing
            ChangeColorGreenAddLine();
            Console.WriteLine("Member's info: COMPACT:");
            ResetColorAddLine();
            //name, memberID, number of boats.
        }
        public void ShowListVerboseView() 
        {
            ChangeColorGreenAddLine();
            Console.WriteLine("Member's info: VERBOSE:");
            ResetColorAddLine();
            // add code for printing
            // name, personalNR, memberID, boats, boat-info
        }
        public void ShowAddMemberView() 
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
        public void ShowDeleteMemberView() {
            ChangeColorRedAddLine();
            Console.WriteLine("# Delete Member Section #");
            Console.WriteLine("# Deleting is a permanent action! #");
            ResetColorAddLine();
            this.DoAction("DELETE");
        }
        public void ShowMemberView() {
            ChangeColorGreenAddLine();
            Console.WriteLine("# View Member Section #");
            ResetColorAddLine();
            this.DoAction("VIEW");
        }

        public void ShowEditMemberView() {
            ChangeColorBlueAddLine();
            Console.WriteLine("# Edit Member Section #");
            ResetColorAddLine();
            this.DoAction("EDIT");
        }

       
        private void DoAction(string action) {
            int value;
            do 
            {
                int count = this.Members.Count();
                if (count == 0) {
                    Console.WriteLine("No Members in the list. Type: 0 to exit.");
                } else {
                    Console.WriteLine($"Type a Member ID between {1} and {count}, to {action} information. Type: 0 to exit.");
                }
            ConsoleKeyInfo input = Console.ReadKey(true);
            if (char.IsDigit(input.KeyChar))
                    {
                        Int32.TryParse(input.KeyChar.ToString(), out value);
                    } else {
                        value = count +1;
                    }
                    if (value > 0 && value < count+1) {
                        Member member = Members.GetMemberInList(value);
                        if (action == "DELETE") {
                            string memberName = member.Name;
                            if (Members.DeleteMemberFromList(member)) {
                                Console.WriteLine($"Member: {memberName} deleted.");
                            } else Console.WriteLine("Member could not be deleted.");
                            
                        }
                        if (action == "VIEW") {
                            this.ShowDetails(member);
                            
                        }
                        if (action == "EDIT") {
                            this.EditDetails(member);
                        }
                        
                    }

            } while (value != 0);
        }

        private void EditDetails (Member member) {

        }

        private void ShowDetails(Member member) {
            ChangeColorBlueAddLine();
            Console.WriteLine($":: MEMBER ID #{member.MemberId} ::");
            ResetColorAddLine();
            Console.WriteLine($"Name: {member.Name}");
            Console.WriteLine($"Personal Number: {member.PersonalNr}");
            ChangeColorBlueAddLine();
            Console.WriteLine($":: OWNED BOATS #{member.BoatsOwned.Count} ::");
            ResetColorAddLine();
            foreach (Boat boat in member.BoatsOwned) {
                Console.WriteLine($"Boat Length:{boat.Length}");
                Console.WriteLine($"Boat Type:{boat.BoatType}");
            }
            ResetColorAddLine();
        }

        private void ChangeColorBlueAddLine() {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        private void ChangeColorRedAddLine() {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        private void ChangeColorGreenAddLine() {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        private void ResetColorAddLine() {
            Console.ResetColor();
            Console.WriteLine();
        }
    }

}