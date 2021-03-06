using System;
using System.Collections.Generic;
using System.Linq;

namespace workshop2 {

    class MembersIndex {
        
        private List<Member> _members;
        
        public MembersIndex () {
            _members = new List<Member>();
        } 

        public Member GetMemberInList(int locationInList) {
            return _members[locationInList];
        }
        public int GetCount() {
            return _members.Count;
        }

        public bool MemberExistsInList(Member member) {
            return (_members.Contains(member));
        }
        public void DeleteMemberFromList(Member member) 
        {   
            _members.Remove(member);
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
        public int GetUsableID() {
            int usableID = 1;
            List<Member> SortedList = _members.OrderBy(member=>member.MemberId).ToList();
            foreach (Member member in SortedList) {
                if (member.MemberId == usableID) {
                    usableID++;
                }
            }
            return usableID;
        }

        
        public bool FaultyPersonalNumberCheck(int personalNr)
        {
            foreach(Member member in this.GetList())
            {
                if (personalNr == member.PersonalNr)
                {
                    return true;
                }
            }
            if (personalNr <= 19000101 || personalNr >= 20180101)
            {
                return true;
            }
            return false;
        }
    }
}