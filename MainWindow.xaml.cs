﻿using System.Windows;
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
        public List<Subject> subject { get; set; }
        public List<ProgressIdentifier> progressIdentifier { get; set; }
        public Term[] terms { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            jsonProfStandart = LoadJsonFile(PathJsonFile);
            standart = getStandartInData(jsonProfStandart);
            progressIdentifier = getProgressIdentifierInData(jsonProfStandart);
            subject = getSubjectsInfoInData(jsonProfStandart);
            terms = GetTerms(subject);

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
        private List<ProgressIdentifier> getProgressIdentifierInData(JsonProfStandart jsonProfStandart)
        {
            List<ProgressIdentifier> returnResult = new List<ProgressIdentifier>();
            foreach (UniversalCompetencyRows item in jsonProfStandart.content.section4.universalCompetencyRows)
            {
                ProgressIdentifier temp = new ProgressIdentifier();
                temp.code = item.competence.code.Replace("\n",""); 
                temp.title = item.competence.title.Replace("\n", "");
                temp.knowLabel = item.indicators[0].content.Split(' ').First().Replace("\n", "");
                temp.knowDescription = item.indicators[0].content.Replace(temp.knowLabel + " ", "").Replace("\n", "");
                temp.possessLabel = item.indicators[1].content.Split(' ').First().Replace("\n", "");
                temp.possessDescription = item.indicators[1].content.Replace(temp.possessLabel + " ", "").Replace("\n", "");
                temp.canLabel = item.indicators[1].content.Split(' ').First().Replace("\n", "");
                temp.canDescription = item.indicators[1].content.Replace(temp.canLabel + " ", "").Replace("\n", "");
                returnResult.Add(temp);
            }
            return returnResult;
        }
        private List<Subject> getSubjectsInfoInData(JsonProfStandart jsonProfStandart)
        {
            List<Subject> returnResult = new List<Subject>();
            foreach(Subrows item in jsonProfStandart.content.section5.eduPlan.block1.subrows)
            {
                string[] d = item.description.Split('>');
                string temp = "";
                foreach (string str in d)
                {
                    if (str.IndexOf('<') == -1)
                    {
                        temp += str;
                        continue;
                    }
                    temp += str.Remove(str.IndexOf('<'));
                }
                returnResult.Add(new Subject(item.index, item.title, temp,
                    item.competences.Select(n => n.code).ToArray(), item.unitsCost, item.terms));
            }
                
            return returnResult;
        }
        
        private Term[] GetTerms(List<Subject> subject)
        {
            const ushort countTerm = 8;
            Term[] terms = new Term[countTerm];
            for (ushort i = 0; i < countTerm; i++)
                terms[i] = new Term($"Семестр №{i + 1}", i, GetSubjectsInTerm(i, subject));
            return terms;
        }
        private List<Subject> GetSubjectsInTerm(ushort trem, List<Subject> subject)
            => subject.Where(n => n.terms[trem].terms == true).ToList();

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SubjectTable.ItemsSource = terms[ListTerm.SelectedIndex].subject;
        }
    }
}
