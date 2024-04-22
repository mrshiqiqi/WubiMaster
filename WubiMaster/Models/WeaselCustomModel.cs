using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WubiMaster.Models;

namespace WubiMaster.Models
{
    public class WeaselCustomModel
    {
        public WeaselCustomPatch patch { get; set; }
    }

    public class WeaselCustomPatch
    {
        public WeaselStyle style { get; set; }
    }
}