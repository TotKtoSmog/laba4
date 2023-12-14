
using System.Collections.Generic;

namespace laba4
{
    public class Subject
    {
        public string index { get; set; }
        public string title { get; set; }
        public string purposeDescription { get; set; }
        public string competenceDescription { get; set; }
        public string unitsCost { get; set; }
        public List<Terms> terms { get; set; }
        public const string competence = "Компетенции";
        public string purpose { get; set; }
        public string unitsCostDescription { get; set; }
        public string termsLabel { get; set; }
        public Subject() { }
        public Subject(string index, string title, string purposeDescription, string[] competenceDescription, string unitsCost, bool[] terms)
        {
            this.index = index;
            this.title = title;
            purpose = "Цель";
            this.purposeDescription = purposeDescription;
            this.competenceDescription = "";
            foreach (string item in competenceDescription)
                this.competenceDescription += $"{item}, ";
            this.competenceDescription = this.competenceDescription.Remove(this.competenceDescription.LastIndexOf(','));
            unitsCostDescription = "З.Е.";
            this.unitsCost = unitsCost;
            termsLabel = "Семестры \r\n(terms)\r\n";
            this.terms = new List<Terms>();
            foreach (bool item in terms)
                this.terms.Add(new Terms(item));
        }
    
        public class Terms
        {
            
            public bool terms { get; set; }
            public Terms(bool terms)
            {
                this.terms = terms;
            }
        }
    
    }
}
