using laba4.JsonClass;
using System;
using System.Collections.Generic;

namespace laba4
{
    public class CurseInfo
    {
        public string curseName { get; set; }
        public int number { get; set;}
        public List<CourseItem> content { get; set; }
        private Course _content {  get; set; }
        public CurseInfo()
        {

        }
        public CurseInfo(string curseName, int number, Course content)
        {
            this.curseName = curseName;
            this.number = number;
            this._content = content;
            fillingContent();
        }
        private void fillingContent()
        {
            content = new List<CourseItem>();
            string[] weekActivityIds = _content.weekActivityIds;
            for(int i = 0; i < weekActivityIds.Length; i++)
                weekActivityIds[i] = getFulltitle(weekActivityIds[i]);
            string temp = "";
            int count = 1;
            DateTime date = new DateTime(2022, 9, 1);
            foreach (string item in weekActivityIds)
            {
                if (temp != "" && temp != item)
                {
                    DateTime tempD = date;
                    date = getDataCourse(date, count);
                    content.Add(new CourseItem(temp, $"{(tempD.Day <= 9 ? "0" + tempD.Day : "" + tempD.Day)}." +
                        $"{(tempD.Month <=9 ? "0" + tempD.Month : "" + tempD.Month)}.{tempD.Year}-" +
                        $"{(date.Day <= 9 ? "0" + date.Day : "" + date.Day)}.{(date.Month <= 9 ? "0" + date.Month : "" + date.Month)}.{date.Year}", count));
                    temp = item;
                    count = 1;
                    
                }
                else if (temp == "")
                    temp = item;
                else
                    count++;
            }
        }
        private string getFulltitle(string title)
        {
            string result = "";
            switch (title)
            {
                case "Б1": result = "Теоретическое обучение"; break;
                case "Б2": result = "Практика"; break;
                case "Э": result = "Промежуточная аттестация"; break;
                case "К": result = "Каникулы"; break;
                case "У": result = "Учебная практика"; break;
                case "П": result = "Производственная практика"; break;
                case "НИР": result = "Научно-исследовательская работа"; break;
                case "Д": result = "Государственная итоговая аттестация"; break;
                default: result = "NaN"; break;
            }
            return result;
        }
        private DateTime getDataCourse(DateTime date, int countWeek)
            => date.AddDays(countWeek * 7);
    }
}
