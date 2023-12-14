using System.Collections.Generic;

namespace laba4
{
    public class Term
    {
        public string name {  get; set; }
        public ushort number { get; set; }
        public List<Subject> subject { get; set; }

        public Term() { }
        public Term(string name, ushort number, List<Subject> subject)
        {
            this.name = name;
            this.number = number;
            this.subject = subject;
        }
    }
}
