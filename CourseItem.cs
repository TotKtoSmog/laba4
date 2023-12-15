namespace laba4
{
    public class CourseItem
    {
        public string title { get; set; }
        public string date { get; set; }
        public int count { get; set; }
        public CourseItem() { }
        public CourseItem(string title, string date, int count)
        {
            this.title = title;
            this.date = date;
            this.count = count;
        }
    }
}
