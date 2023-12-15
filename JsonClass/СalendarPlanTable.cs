using System.Runtime.Serialization;

namespace laba4.JsonClass
{
    [DataContract]
    public class СalendarPlanTable
    {
        [DataMember]
        public Course[] courses {get; set;}
    }
}
