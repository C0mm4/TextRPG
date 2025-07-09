using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class StatusData
    {
        public int level { get; set; }
        public int exp { get; set; }
        public string name { get; set; }
        public string classType { get; set; }
        public float atk { get; set; }
        public float itemAtk { get; set; }
        public float def { get; set; }
        public float itemDef { get; set; }
        public int currHP { get; set; }
        public int maxHP { get; set; }
        public int itemMaxHP { get; set; }
        public int gold { get; set; }
    } 
}
