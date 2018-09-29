using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2 {
    [Serializable]
    class Boat {
        private int _length;
        public BoatType BoatType {get;}

        public int Length {get;}
        public Boat (int length, BoatType boatType) 
        {
            // add checks? criteras?
            _length = length;
            BoatType = boatType;
        }

        override public string ToString() {
            
            string outString = BoatType.ToString() + " " + Length.ToString();

            return outString;
        }
    }
}