using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2
{

    class ViewHandler
    {

        private MembersIndex _members;

        private HelpFunctions hf = new HelpFunctions();

       public MembersIndex Members
        {
            get
            {
                return _members;
            }
        }
        public ViewHandler(MembersIndex members)
        {
            this._members = members;
        }
        public void StartView()
        {
            int value;
            List<string> options = new List<string>(new string[]
            {
             "To exit the application.",
             "Show list of members (COMPACT).",
             "Show list of members (VERBOSE)",
             "Add a member to the list.",
             "Delete a member in the list.",
             "View a member in the list",
             "Edit a member in the list." });
            do
            {        
                hf.ChangeColorBlueAddLine();
                Console.WriteLine("Welcome to the members and boat listings, choose an OPTION:");
                hf.ResetColorAddLine();
                hf.printOptions(options);
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (char.IsDigit(input.KeyChar))
                {
                    Int32.TryParse(input.KeyChar.ToString(), out value);
                    } else {
                        value = options.Count;
                    }

                if (value == 1)
                {
                    Console.Clear();
                    ShowListCompactView();
                    hf.Pause();
                }

                if (value == 2)
                {
                    Console.Clear();
                    ShowListVerboseView();
                    hf.Pause();
                }

                if (value == 3)
                {
                    Console.Clear();
                    ShowAddMemberView();
                }
                if (value == 4)
                {
                    Console.Clear();
                    ShowDeleteMemberView();
                }
                if (value == 5)
                {
                    Console.Clear();
                    ShowMemberView();
                }
                if (value == 6)
                {
                    Console.Clear();
                    ShowEditMemberView();
                }
            } while (value != 0);
            hf.ChangeColorRedAddLine();
            Console.WriteLine("Application Terminated.");
            hf.ResetColorAddLine();
        }

        public void ShowListCompactView()  
        {
            hf.ChangeColorGreenAddLine();
            Console.WriteLine("Member's info: COMPACT:");
            hf.ResetColorAddLine();
            if (Members.GetCount() != 0) {
                Console.WriteLine("{0, -10} {1,15} {2,20}\n", "Member", "MemberID", "No. of Boats");
                foreach (Member member in Members.GetList()) {
                    Console.WriteLine("{0, -10} {1,8} {2,16}\n", member.Name, member.MemberId, member.CountBoats());
                }
            } else {
                Console.WriteLine("No members in the list.");
            }
        }
        public void ShowListVerboseView()
        {
            hf.ChangeColorGreenAddLine();
            Console.WriteLine("Members info: VERBOSE:");
            hf.ResetColorAddLine();
            if (Members.GetCount() != 0)
            {
                foreach (Member member in Members.GetList())
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
        }
        public void ShowAddMemberView() 
        {
            Member member = new Member("",0, Members.GetUsableID());
            hf.ChangeColorBlueAddLine();
            Console.WriteLine("# Adding a Member to the system #");
            hf.ResetColorAddLine();
            Console.WriteLine($"Add Member information:");
            AddMemberName(member);
            if (member.Name != "")
            {
                AddPersonalNumber(member);
                if (member.PersonalNr != 0)
                {
                    AddBoat(member);
                    Members.AddMemberToList(member);
                    hf.ChangeColorGreenAddLine();
                    Console.WriteLine("Member created.");
                    hf.ResetColorAddLine();
                }
            }
            else
            {
                hf.ChangeColorRedAddLine();
                Console.WriteLine("Action aborted. Member NOT created.");
                hf.ResetColorAddLine();
            }
        }
        public void ShowDeleteMemberView()
        {
            this.DoAction("DELETE");
        }
        public void ShowMemberView()
        {
            this.DoAction("VIEW");
        }
        public void ShowEditMemberView()
        {
            this.DoAction("EDIT");
        }

       
        private void DoAction(string action)
        {
               int locationInList = 0;
                do 
                {   
                    List<string> options = new List<string>(new string[] {"to CANCEL."});
                    locationInList = options.Count;
                    if (this.Members.GetCount() != 0) {

                    foreach (Member member in Members.GetList())
                    {
                        options.Add($"Name: {member.Name}  MemberID: {member.MemberId}");
                    }
                    hf.ChangeColorBlueAddLine();
                    Console.WriteLine($"# {action} Member Section #");
                    if (action == "DELETE")
                    {
                        hf.ChangeColorRedAddLine();
                        Console.WriteLine("Deleting a Member is a permanent action!");
                    }
                    hf.ResetColorAddLine();
                    Console.WriteLine($"Perform {action} on user by typing the number, or 0 to Cancel.");

                    hf.printOptions(options);
                    
                    if (Int32.TryParse(Console.ReadLine(), out locationInList))
                    {
                        
                    }
                    else
                    {
                        locationInList = options.Count;
                    }
                    Console.WriteLine();
                    
                        
                        if (locationInList > 0 && locationInList < options.Count)
                        {
                            Member member = Members.GetMemberInList(locationInList-1);
                            if (action == "DELETE") {
                                string memberName = member.Name;
                                if (Members.MemberExistsInList(member))
                                {
                                    Members.DeleteMemberFromList(member);
                                    hf.ChangeColorRedAddLine();
                                    Console.WriteLine($"Member: {memberName} deleted.");
                                    hf.ResetColorAddLine();
                                    locationInList = 0;
                                } else Console.WriteLine("Member could not be deleted.");
                            
                            }
                            if (action == "VIEW")
                            {
                                this.ShowMemberDetails(member);
                            
                            }
                            if (action == "EDIT")
                            {
                                this.EditDetails(member);
                            }
                        
                        }
                    } 
                    else
                        {
                            hf.ChangeColorRedAddLine();
                            Console.WriteLine("No Members in the list!");
                            hf.ResetColorAddLine();
                            locationInList = 0;
                        }
                        
                } while (locationInList != 0);
        }

        private void EditDetails (Member member)
        {
        int value;
            do 
            {
            hf.ChangeColorBlueAddLine();
            Console.WriteLine($"# Editing Member # ID: {member.MemberId} : Name: {member.Name} #");
            hf.ResetColorAddLine();
            List<string> options = new List<string>(new string[] {
            "To GO BACK.",
             "To EDIT Member Name.",
             "To EDIT PersonalNR.",
             "To EDIT Boats."});
             
            Console.WriteLine($"Type a number for the information to edit, or 0 to go back.");
            hf.printOptions(options);
            ConsoleKeyInfo input = Console.ReadKey(true);
            if (char.IsDigit(input.KeyChar))
                    {
                        Int32.TryParse(input.KeyChar.ToString(), out value);
                    } else {
                        value = options.Count;
                    }
                    if (value > 0 && value < options.Count)
                    {
                        if (value == 1) {
                            AddMemberName(member);
                        }
                        if (value == 2) {
                            AddPersonalNumber(member);
                        }
                        if (value == 3) {
                            AddDeleteEditBoats(member);
                        }
                    }

            } while (value != 0);
        }

        private void AddMemberName(Member member)
        {
            string name = "";
            do
                {   
                    Console.WriteLine("Write Member Name here (Can't start with number, or be blank):");
                    name = Console.ReadLine();
                    Console.WriteLine();
                } while (FaultyNameCheck(name));
            member.Name = name;
        }
        private bool FaultyNameCheck(string name)
        {
            int value;
            if (string.IsNullOrWhiteSpace(name))
            {
                return true;
            }
            if (int.TryParse(name, out value)) 
            {
                return true;
            }
            return false;
            
        }
        private void AddPersonalNumber(Member member)
        {
            int personalNr = -1;
            do
            {   
                Console.WriteLine("Write your Personal Number here(Must be unique, 1-99999):");
                Int32.TryParse(Console.ReadLine(), out personalNr);
                Console.WriteLine();
            } while (FaultyPersonalNumberCheck(personalNr));
            member.PersonalNr = personalNr;
        }

        private bool FaultyPersonalNumberCheck(int personalNr)
        {
            foreach(Member member in Members.GetList())
            {
                if (personalNr == member.PersonalNr)
                {
                    return true;
                }
            }
            if (personalNr < 0 || personalNr > 99999)
            {
                return true;
            }
            return false;
        }
        private void AddDeleteEditBoats(Member member)
        {
            int value = 0;
            int options = 4;
            do 
            {
                hf.ChangeColorBlueAddLine();
                Console.WriteLine($"# Editing Boats for Member #{member.MemberId}");
                hf.ResetColorAddLine();
                Console.WriteLine("# Choose a number to: ADD , DELETE, or EDIT boat, 0 to go back.");
                Console.WriteLine("0. Go Back");
                Console.WriteLine("1. Add Boat");
                if (member.CountBoats() != 0)
                {
                    Console.WriteLine("2. Delete Boat");
                    Console.WriteLine("3. Edit Boat");
                }
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (char.IsDigit(input.KeyChar))
                    {
                        Int32.TryParse(input.KeyChar.ToString(), out value);
                    } else {
                        value = options;
                    }
                if (value == 1)
                {
                    AddBoat(member);
                }
                if (member.CountBoats() != 0)
                {
                    if (value == 2)
                    {
                        DeleteBoatForMember(member);
                    }
                    if (value == 3)
                    {   
                        EditBoats(member);
                    }
                }                
            } while (value !=0);
        }
        private void AddBoat(Member member) { 
        hf.ChangeColorBlueAddLine();
        Console.WriteLine($"# Adding a new Boat for Member #{member.MemberId}");
        hf.ResetColorAddLine();
        Console.WriteLine("Choose your type, or press 0 to Cancel.");
        List<string> options = hf.CreateBoatTypeOptions();
            int value;
            BoatType boatType = BoatType.Other;
            do {
                hf.printOptions(options);
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (char.IsDigit(input.KeyChar))
                {
                    Int32.TryParse(input.KeyChar.ToString(), out value);
                }
                else
                {
                    value =  options.Count;
                }
                    boatType = hf.RetrieveBoatType(value);
            } while (value > options.Count);
            if (value != 0)
            {
                int length = hf.RetrieveBoatLength();
                Boat boat = new Boat(length, boatType);
                member.RegisterBoat(boat);
            } 

        }

        private void EditBoats(Member member)
        { 
        List<string> options = CreateBoatOptions(member);
        int value = options.Count;
        do {
            ShowSectionText("EDIT");
            hf.printOptions(options);
            if (Int32.TryParse(Console.ReadLine(), out value))
            {
            }
                else
                    {
                        value = options.Count;
                    }
                    Console.WriteLine();
                if (value != 0 && value != options.Count) {
                    EditChosenBoat(member.BoatsOwned[value-1]);
                    value = 0;
                }

            } while (member.BoatsOwned.Count !=0 && value != 0);
        }

        private void EditChosenBoat(Boat boat)
        {
            int value;
            do 
            {
            hf.ChangeColorBlueAddLine();
            Console.WriteLine($"# Editing Boat # Type: {boat.BoatType} : Length: {boat.Length} #");
            hf.ResetColorAddLine();
            List<string> options = new List<string>(new string[] {
            "To GO BACK.",
             "To EDIT Boat Type.",
             "To EDIT Boat Length."});
             
            Console.WriteLine($"Type a number for the information to edit, or 0 to go back.");
            hf.printOptions(options);
            ConsoleKeyInfo input = Console.ReadKey(true);
            if (char.IsDigit(input.KeyChar))
                    {
                        Int32.TryParse(input.KeyChar.ToString(), out value);
                    } else {
                        value = options.Count;
                    }
                    if (value > 0 && value < options.Count) {
                        if (value == 1) {
                            EditBoatType(boat);
                            value = 0;
                        }
                        if (value == 2) {
                            EditBoatLength(boat);
                            value = 0;
                        }
                    }

            } while (value != 0);
        }

        private void EditBoatType(Boat boat) {
            hf.ChangeColorBlueAddLine();
            Console.WriteLine($"# Editing Boat # Type: {boat.BoatType} #");
            hf.ResetColorAddLine();
            List<string> options = hf.CreateBoatTypeOptions();
            int value;
            do {
                hf.printOptions(options);
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (char.IsDigit(input.KeyChar))
                {
                    Int32.TryParse(input.KeyChar.ToString(), out value);
                    } else {
                        value =  options.Count;
                    }
            } while (value > options.Count);
            boat.BoatType = (hf.RetrieveBoatType(value));
        }
        private void EditBoatLength(Boat boat) {
            hf.ChangeColorBlueAddLine();
            Console.WriteLine($"# Editing Boat # Length: {boat.Length} #");
            hf.ResetColorAddLine();
            int length = hf.RetrieveBoatLength();
            boat.Length = length;
        }

        private void ShowSectionText(string action) {
            hf.ChangeColorRedAddLine();
            Console.WriteLine($"# {action} Boat Section #");
            Console.WriteLine($"To {action} boat is a permanent action!");
            hf.ResetColorAddLine();
            Console.WriteLine($"Choose boat to {action} from the list, or type 0 to exit, then ENTER.");
            Console.WriteLine();
        }

        private List<string> CreateBoatOptions(Member member)
        {
            List<string> options = new List<string>(new string[] {"to CANCEL."});
            foreach (Boat boat in member.BoatsOwned)
            {
                options.Add($"Boat: {boat.BoatType.ToString()}  Length: {boat.Length}");
            }
            return options;
        }
        private void DeleteBoatForMember(Member member) {
        List<string> options = CreateBoatOptions(member);
        int value = options.Count;
        do {
            hf.ChangeColorRedAddLine();
            ShowSectionText("DELETE");
            hf.printOptions(options);
            if (Int32.TryParse(Console.ReadLine(), out value))
            {
            }   else
                    {
                        value = options.Count;
                    }
                    Console.WriteLine();
                if (value != 0 && value != options.Count)
                {
                    member.DeRegisterBoat(member.BoatsOwned[value-1]);
                    hf.ChangeColorRedAddLine();
                    Console.WriteLine($"# Boat at: {value} # Deleted!");
                    hf.ResetColorAddLine();
                    value = 0;
                }

            } while (member.BoatsOwned.Count !=0 && value != 0);

        }
        

        private void ShowMemberDetails(Member member)
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