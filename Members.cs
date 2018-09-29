using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2 {
    class Members {
        private List<Member> _members;
        
        public Members () {
            _members = new List<Member>();
        }

        public Member GetMemberInList(int memberID) {
        foreach (Member controlMember in _members) 
            {
                if (controlMember.ListId != memberID) {
                    return controlMember;
                }
            }
            throw new Exception("That is not a member!");
        }
        public bool DeleteMemberFromList(Member member) 
        {   
            if (_members.Contains(member)) {
                   _members.Remove(member);
                   return true;
            } else return false;
                
        }
        public List<Member> GetList() 
        {
            return _members;
        }

        public void AddMemberToList(Member member) {
            _members.Add(member);
        }
        public void AddMultipleMembers(List<Member> members) {
            foreach(Member member in members) {
                _members.Add(member);
            }
        }
        
        public int Count() {
            return _members.Count();
        }
    }
}