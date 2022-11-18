using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezsikApp_WPF.Model
{
    public class Tip
    {
        public Tip(int tid, string nev)
        {
            Tid = tid;
            T_Nev = nev;
        }

        public int Tid { get; set; }
            public string T_Nev { get; set; }

    }
}

