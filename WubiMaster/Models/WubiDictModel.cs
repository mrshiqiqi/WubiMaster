using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace WubiMaster.Models
{
    public class WubiDictModel
    {
        [YamlMember(Alias = "name")]
        public string Name { get; set; }
        [YamlMember(Alias = "version")]
        public string Version { get; set; }
        [YamlMember(Alias = "sort")]
        public string Sort { get; set; }
        [YamlMember(Alias = "columns")]
        public string[] Columns { get; set; }
        [YamlMember(Alias = "encoder")]
        public Encoder Encoder { get; set; }
    }

    public class Encoder
    {
        public string[] ExcludePatterns { get; set; }
        public Rule[] Rules { get; set; }
    }

    public  class Rule
    {
        public long? LengthEqual { get; set; }

        public string Formula { get; set; }
        public long[] LengthInRange { get; set; }
    }
}
