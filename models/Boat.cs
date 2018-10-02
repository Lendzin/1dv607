using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2 {
    [Serializable]
    class Boat {
        private int _length;
        private BoatType _boatType;
        public BoatType BoatType 
        { 
            get { return _boatType;}
            set { _boatType = value; }
        }

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public Boat (int length, BoatType boatType) 
        {
            _length = length;
            _boatType = boatType;
        }

    }
}