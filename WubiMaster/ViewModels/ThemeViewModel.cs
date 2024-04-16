using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WubiMaster.Common;
using WubiMaster.Models;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace WubiMaster.ViewModels
{
    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
    }

    public class Hello
    {
        public string config_version { get; set; }
        public Dictionary<string, Word> preset_color_schemes { get; set; }
        public Style style { get; set; }
    }

    public class Person
    {
        public Dictionary<string, Address> Addresses { get; set; }
        public int Age { get; set; }
        public string HeightInInches { get; set; }
        public string Name { get; set; }
    }

    public partial class ThemeViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private List<string> rimeThemes;

        public ThemeViewModel()
        {
            Test();
        }

        private void Test()
        {
            string path = @"D:\Rime\weasel.yaml";
            string yml = File.ReadAllText(path);

            //var yml = @"
            //    name: George Washington
            //    age: 89
            //    height_in_inches: 5.75
            //    addresses:
            //      home:
            //        street: 400 Mockingbird Lane
            //        city: Louaryland
            //        state: Hawidaho
            //        zip: 99970
            //    ";

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml
                .Build();

            //yml contains a string containing your YAML
            Hello p = deserializer.Deserialize<Hello>(yml);
            var ts = p.preset_color_schemes;
            List<string> tList = new List<string>();
            foreach (var t in ts.Keys)
            {
                tList.Add(ts[t].name);
            }

            RimeThemes = tList;
            Console.WriteLine();
            //var h = p.Addresses["home"];
            //System.Console.WriteLine($"{p.Name} is {p.Age} years old and lives at {h.Street} in {h.City}, {h.State}.");
        }
    }

    public class Word
    {
        public string author { get; set; }
        public string back_color { get; set; }
        public string border_color { get; set; }
        public string candidate_text_color { get; set; }
        public string comment_text_color { get; set; }
        public string hilited_back_color { get; set; }
        public string hilited_candidate_back_color { get; set; }
        public string hilited_candidate_label_color { get; set; }
        public string hilited_candidate_text_color { get; set; }
        public string hilited_comment_text_color { get; set; }
        public string hilited_label_color { get; set; }
        public string hilited_text_color { get; set; }
        public string label_color { get; set; }
        public string name { get; set; }
        public string text_color { get; set; }
    }
}