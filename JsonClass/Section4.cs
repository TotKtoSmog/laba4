using System.Runtime.Serialization;

namespace laba4.JsonClass
{
    [DataContract]
    public class Section4
    {
        [DataMember]
        public ProfessionalStandards[] professionalStandards { get; set; }
        public ProfessionalCompetenceTaskTable[] professionalCompetenceTaskTable { get; set; }
    }
}
