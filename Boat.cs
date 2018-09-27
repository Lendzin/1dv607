using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2 {
    class Boat {
        private Member Owner;
        private int Length;
        public BoatType BoatType {get;}

        public Boat (Member owner, int length, BoatType boatType) 
        {
            // add checks? criteras?
            Owner = owner;
            Length = length;
            BoatType = boatType;
        }
        public void GetInfo() 
        {
            //create code.
        }
        public void Delete() {
            //create code.
        }
        public void Edit() {
            //create code.
        }

        override public string ToString() {
            
            string outString = BoatType.ToString() + " " + Length.ToString();

            return outString;
        }
    }
}