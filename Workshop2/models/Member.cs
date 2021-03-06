using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2 {
    
    [Serializable]
    class Member  {

        private int _memberId;
        private int _personalNr;
        private string _name;
        private List<Boat> _boatsOwned;

        public int MemberId
        {
            get { return _memberId; }
        }
        public int PersonalNr
        {
            get { return _personalNr; }
        }
        public string Name
        {
            get { return _name; }
        }

        public List<Boat> BoatsOwned
        {
            get { return _boatsOwned; }
        }
        
        public Member(string name, int personalNr, int memberId) {
            _memberId = memberId;
            _name = name;
            _personalNr = personalNr;
            _boatsOwned = new List<Boat>();
        }
        public int CountBoats() {
            return _boatsOwned.Count;
        }

        public void changeName(string name) {
            int other;
            if (!string.IsNullOrWhiteSpace(name) && !int.TryParse(name, out other)) {
                if (2 <= name.Count() && name.Count() <= 12) {
                    _name = name;
                }
            } else {
                throw new System.FormatException();
            }
        }

        public void changePersonalNr(int number) {
            if (number > 19000101 && number <= 20180101) {
                _personalNr = number;
            } else {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void RegisterBoat(Boat boat) {
            _boatsOwned.Add(boat);
        }
        public void DeRegisterBoat(Boat boat) {
            _boatsOwned.Remove(boat);
        }

        public bool FaultyNameCheck(string name)
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
            if (2 <= name.Count() && name.Count() <= 12) {
                return false;
            }
            return true;
            
        }
    }
}