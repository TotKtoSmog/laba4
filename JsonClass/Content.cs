﻿using System.Runtime.Serialization;

namespace laba4.JsonClass
{
    [DataContract]
    public class Content
    {
        [DataMember]
        public string orderNumber {  get; set; }
        [DataMember]
        public Section4 section4 { get; set; }
    }
}
