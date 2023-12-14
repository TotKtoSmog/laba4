using System.Runtime.Serialization;

namespace laba4.JsonClass
{
    [DataContract]
    public class Block1
    {
        [DataMember]
        public string index { get; set; }
        [DataMember]
        public Subrows[] subrows { get; set; }
    }
}
