using System.Windows;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.Linq;
using laba4.JsonClass;

namespace laba4
{
    
    public partial class MainWindow : Window
    {
        public string PathJsonFile = @"C:\Users\Totkt\source\repos\laba4\data\file.json";
        public JsonProfStandart jsonProfStandart { get; set; }
        public List<Standart> standart { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            jsonProfStandart = LoadJsonFile(PathJsonFile);
            standart = getStandartInData(jsonProfStandart);
            this.DataContext = this;
        }
        public JsonProfStandart LoadJsonFile(string PathJsonFile)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(JsonProfStandart));
            JsonProfStandart returnResult;
            using (FileStream fs = new FileStream(PathJsonFile, FileMode.OpenOrCreate))
            {
                returnResult = (JsonProfStandart)serializer.ReadObject(fs);
            }
            return returnResult;
        }

        private List<Standart> getStandartInData(JsonProfStandart jsonProfStandart)
        {
            List<Standart> returnResult = new List<Standart>();
            foreach(ProfessionalStandards PS in jsonProfStandart.content.section4.professionalStandards)
            {
                string id = PS.content.Split(' ').First();
                string name = PS.content.Replace(id + " ", "");
                if (!id.Contains("06."))
                {
                    id = "";
                    name = PS.content;
                }
                returnResult.Add(new Standart(id, name));
            }
            return returnResult;
        }
    }
}
