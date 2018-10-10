using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2
{

    class ViewHandler
    {

        private MembersIndex _members;
        private MemberRenderer _memberRenderer = new MemberRenderer();

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
                value = hf.GetValueFromUser(options.Count);
                Console.Clear();
                if (value == 1)
                {
                    _memberRenderer.ShowListCompactView(Members);
                }
                if (value == 2)
                {
                    _memberRenderer.ShowListVerboseView(Members);
                }
                if (value == 3)
                {
                    ShowAddMemberView();
                }
                if (value == 4)
                {
                    this.DoAction("DELETE");
                }
                if (value == 5)
                {
                    this.DoAction("VIEW");
                }
                if (value == 6)
                {
                    this.DoAction("EDIT");
                }
            } while (value != 0);
            hf.ChangeColorRedAddLine();
            Console.WriteLine("Application Terminated.");
            hf.ResetColorAddLine();
        }

        private void ShowAddMemberView() 
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
                    
                        if (!Int32.TryParse(Console.ReadLine(), out locationInList)) {
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
                                _memberRenderer.ShowMemberDetails(member);
                            
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
            value = hf.GetValueFromUser(options.Count);
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
                } while (member.FaultyNameCheck(name));
            member.changeName(name);
        }

        private void AddPersonalNumber(Member member)
        {
            int personalNr = -1;
            do
            {   
                Console.WriteLine("Write your Personal Number here(Must be unique, 1-99999):");
                Int32.TryParse(Console.ReadLine(), out personalNr);
                Console.WriteLine();
            } while (Members.FaultyPersonalNumberCheck(personalNr));
            member.changePersonalNr(personalNr);
        }

        private void AddDeleteEditBoats(Member member)
        {
            int value = 0;
            int options = 2;
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
                    options = 4;
                    Console.WriteLine("2. Delete Boat");
                    Console.WriteLine("3. Edit Boat");
                }
                value = hf.GetValueFromUser(options);
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
                value = hf.GetValueFromUser(options.Count);
                    boatType = RetrieveBoatType(value);
            } while (value > options.Count);
            if (value != 0)
            {
                int length = hf.RetrieveBoatLength();
                Boat boat = new Boat(length, boatType);
                member.RegisterBoat(boat);
            } 

        }
        private BoatType RetrieveBoatType(int value) {
                    if (value == 1) {
                        return BoatType.Canoe;
                    }
                    if (value == 2) {
                        return BoatType.Kayak;
                    }
                    if (value == 3) {
                        return BoatType.Sailboat;
                    }
                    if (value == 4) {
                        return BoatType.Motorsailer;
                    }
                    return BoatType.Other;
        }

        private void EditBoats(Member member)
        { 
        List<string> options = CreateBoatOptions(member);
        int value = options.Count;
        do {
            hf.ShowSectionText("EDIT");
            hf.printOptions(options);
            if (!Int32.TryParse(Console.ReadLine(), out value)) {
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
            value = hf.GetValueFromUser(options.Count);
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
                value = hf.GetValueFromUser(options.Count);
            } while (value > options.Count);
            boat.BoatType = (RetrieveBoatType(value));
        }
        private void EditBoatLength(Boat boat) {
            hf.ChangeColorBlueAddLine();
            Console.WriteLine($"# Editing Boat # Length: {boat.Length} #");
            hf.ResetColorAddLine();
            int length = hf.RetrieveBoatLength();
            boat.Length = length;
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
            hf.ShowSectionText("DELETE");
            hf.printOptions(options);
            if (!Int32.TryParse(Console.ReadLine(), out value))
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

    }

}