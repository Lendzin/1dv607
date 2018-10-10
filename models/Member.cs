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

        public List<Boat> GetBoats() {
            return _boatsOwned;
        }
        public void changeName(string name) {
            int other;
            if (!string.IsNullOrWhiteSpace(name) && !int.TryParse(name, out other)) {
                _name = name;
            } else {
                throw new System.FormatException();
            }
        }

        public void changePersonalNr(int number) {
            if (number > 0 && number < 9999) {
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
    }
}