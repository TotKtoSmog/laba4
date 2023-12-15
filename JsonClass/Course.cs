using System.Runtime.Serialization;

namespace laba4.JsonClass
{
    [DataContract]
    public class Course
    {
        [DataMember]
        public bool isEdited {  get; set; }
        [DataMember] 
        public string[] weekActivityIds { get; set; }
    }
}
