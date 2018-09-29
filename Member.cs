using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2 {
    
    [Serializable]
    class Member  {

        private int _memberId;
        private int _personalNr;
        private int _listId;
        private string _name;
        private List<Boat> _boatsOwned;

        public int MemberId
        {
            get { return _memberId; }
            // set { _memberId = value; }
        }
        public int PersonalNr
        {
            get { return _personalNr; }
            // set { _personalNr = value; }
        }
        public int ListId
        {
            get { return _listId; }
            // set { _listId = value; }
        }
        public string Name
        {
            get { return _name; }
            // set { _name = value; }
        }

        public List<Boat> BoatsOwned
        {
            get { return _boatsOwned; }
            // set { _boatsOwned = value; }
        }
        
        public Member(string name, int personalNr) {
            //get memberlist count, MemberID = count+1;
            _name = name;
            _personalNr = personalNr;
            _boatsOwned = new List<Boat>();
        }

        public List<Boat> getBoats() {
            return _boatsOwned;
        }

        public void RegisterBoat(Boat boat) {
            _boatsOwned.Add(boat);
        }

        override public string ToString() {
            string outputString = "";
            outputString += _name + " " + _personalNr.ToString();
            return outputString;
        }
    }
}