

using System.Runtime.Serialization;

namespace laba4.JsonClass
{
    [DataContract]
    public class EduPlan
    {
        [DataMember]
        public int termsAmount { get; set; }
        [DataMember]
        public Block1 block1 { get; set; }
    }
}
