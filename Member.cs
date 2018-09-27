using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2 {
    class Member  {

        private int _listId;
        private string _name;
        private int _personalNR;
        //private int MemberID;
        private List<Boat> _boatsOwned;

        public int ListId
    {
        get
        {
            return _listId;
        }
        set
        {
            _listId = value;
        }
    }
        
        public Member(string name, int personalNR) {
            //get memberlist count, MemberID = count+1;
            _name = name;
            _personalNR = personalNR;
            _boatsOwned = new List<Boat>();
        }

        public List<Boat> getBoats() {
            return _boatsOwned;
        }
        public void Edit() {
            // add code.
        }
        public void Delete() {
            // add code.
        }
        public void View() {
            // add code.
        }

        public void RegisterBoat(Boat boat) {
            _boatsOwned.Add(boat);
        }

        override public string ToString() {
            string outputString = "";
            outputString += _name + " " + _personalNR.ToString();
            return outputString;
        }
    }
}