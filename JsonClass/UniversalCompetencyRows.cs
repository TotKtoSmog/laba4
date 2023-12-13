using System.Runtime.Serialization;

namespace laba4.JsonClass
{
    [DataContract]
    public class UniversalCompetencyRows
    {
        [DataMember]
        public Competence competence { get; set; }
        [DataMember]
        public Competence category { get; set; }
        [DataMember]
        public Indicator[] indicators { get; set; }
    }
}
