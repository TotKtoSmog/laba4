﻿

using System.Runtime.Serialization;

namespace laba4.JsonClass
{
    [DataContract]
    public class Indicator
    {
        [DataMember]
        public string id {  get; set; }
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public string content { get; set; }

    }
}
