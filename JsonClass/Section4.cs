using System.Runtime.Serialization;

namespace laba4.JsonClass
{
    [DataContract]
    public class Section4
    {
        [DataMember]
        public ProfessionalStandards[] professionalStandards { get; set; }
        [DataMember] 
        public ProfessionalCompetenceTaskTable[] professionalCompetenceTaskTable { get; set; }
        [DataMember]
        public UniversalCompetencyRows[] universalCompetencyRows { get; set; }
    }
}
