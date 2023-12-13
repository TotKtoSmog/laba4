using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization.Json;

namespace laba4
{
    
    public partial class MainWindow : Window
    {
        public string PathJsonFile = @"C:\Users\Totkt\source\repos\laba4\data\file.json";
        public JsonProfStandart jsonProfStandart { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            jsonProfStandart = LoadJsonFile(PathJsonFile);
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
    }
}
