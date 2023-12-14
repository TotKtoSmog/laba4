using System.Runtime.Serialization;

namespace laba4.JsonClass
{
    [DataContract]
    public class Subrows
    {
        [DataMember]
        public string tpe { get; set; }
        [DataMember]
        public string[] attestationFormIds { get; set;}
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string unitsCost { get; set; }

        [DataMember]
        public string title { get; set; }
        [DataMember]
        public Competenc[] competences { get; set; }
        [DataMember]
        public bool[] terms { get; set; }
        [DataMember]
        public string index { get; set; }

    }
}
