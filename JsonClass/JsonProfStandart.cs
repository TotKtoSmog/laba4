using System.Runtime.Serialization;

namespace laba4.JsonClass
{
    [DataContract]
    public class JsonProfStandart
    {
        [DataMember]
        public string authorFIO { get; set; }
        [DataMember]
        public string educationDirectionCode { get; set; }
        [DataMember]
        public string educationDirectionTitle { get; set; }
        [DataMember]
        public string fgosOrderNumber { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string educationLevelTitle { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string fgosOrderDate { get; set; }
        [DataMember]
        public Content content { get; set; }
    }
}
