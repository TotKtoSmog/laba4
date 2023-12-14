

using System.Runtime.Serialization;

namespace laba4.JsonClass
{
    [DataContract]
    public class Section5
    {
        [DataMember]
        public string section5_6 { get; set; }
        [DataMember]
        public EduPlan eduPlan { get; set; }
    }
}
