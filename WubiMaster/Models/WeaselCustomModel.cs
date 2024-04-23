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
        public CustomPatch patch { get; set; }
    }

    public class CustomPatch
    {
        public ColorStyle style { get; set; }
    }
}