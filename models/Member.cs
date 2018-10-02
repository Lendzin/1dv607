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
            set 
            {   if (value > 0 && value < 9999) {
                 _personalNr = value;
            } else {
                    throw new ArgumentOutOfRangeException();
                }
                
            }
        }
        public string Name
        {
            get { return _name; }
            set {
                int other;
                if (!string.IsNullOrWhiteSpace(value) && !int.TryParse(value, out other)) {
                    _name = value;
                } else {
                    throw new System.FormatException("Name is in the wrong format, too short, or nonexistant.");
                }
            }
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

        public void RegisterBoat(Boat boat) {
            _boatsOwned.Add(boat);
        }
        public void DeRegisterBoat(Boat boat) {
            _boatsOwned.Remove(boat);
        }
    }
}