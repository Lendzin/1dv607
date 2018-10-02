using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace workshop2 {
    class FileHandler {


            private string _dir;
            private string _serializationFile;

            public FileHandler () {
                _dir = Path.GetTempPath();   
                _serializationFile = Path.Combine(_dir, "memberlist.bin");
            }

            public void SaveMemberList(List<Member> memberList) {
                
                using (Stream stream = File.Open(_serializationFile, FileMode.Create))
                {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, memberList);
                }
            }

            public List<Member> LoadMemberList() {

                if (File.Exists(_serializationFile)) {
                    using (Stream stream = File.Open(_serializationFile, FileMode.Open))
                    {
                        var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                        List<Member> members = (List<Member>)bformatter.Deserialize(stream);
                        Console.WriteLine(Path.GetTempPath());
                        return members;
                    }
                } else return new List<Member>();
        }
    }
}