using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WubiMaster.Models
{
    public class SpellingKeyModel
    {
        public string SpellingKey { get; set; }
    }

    public class CodeKeyModel
    {
        public string CodeKey { get; set; }
    }

    public class ZigenModel
    {
        public string Text { get; set; }
        public string Type { get; set; }
        public List<SpellingKeyModel> SpellingKeyList86 { get; set; }
        public List<SpellingKeyModel> SpellingKeyList98 { get; set; }
        public List<SpellingKeyModel> SpellingKeyList06 { get; set; }
        public List<CodeKeyModel> CodeKeyList86 { get; set; }
        public List<CodeKeyModel> CodeKeyList98 { get; set; }
        public List<CodeKeyModel> CodeKeyList06 { get; set; }
        public string WubiType { get; set; }
    }
}
