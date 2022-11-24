using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezsikApp_WPF.Model
{
    internal class Rezsi
    {
        public int id { get; set; }
        public double oraallas { get; set; }
        public double fizetendo { get; set; }
        public DateTime datum { get; set; }
        public string name { get; set; }
        public string tipus { get; set; }
        public string szin { get; set; }


        public Rezsi(int id, double oraallas, double fizetendo, DateTime datum, string name, string tipus = "Egyebb", string szin = "green")
        {
            this.id = id;
            this.oraallas = oraallas;
            this.fizetendo = fizetendo;
            this.datum = datum;
            this.name = name;
            this.tipus = tipus;
            this.szin = szin;
        }
    }
}
