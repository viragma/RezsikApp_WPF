using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezsikApp_WPF.Model
{
    //public Rezsik(int id, double oraallas, double fizetendo, DateTime datum, string name, string tipus = "Egyebb")
    internal class Data
    {
        public List<Rezsik> rezsik;
        public List<Tip> rezsiTipus;
        private ResziModelContainer rezsikDBContainer;

        public List<Rezsik> getalldata()
        {
            rezsik = new List<Rezsik> ();
            rezsikDBContainer = new ResziModelContainer();
            var er = (from x in rezsikDBContainer.Rezsik
                      select new { x.Rid, x.Tipus.T_Nev, x.Fizetendo, x.Oraallas, x.Datum, x.Felhasznalo.Felh_Nev }).ToList();
            string t, sz;
            foreach (var x in er)
            {
                switch (x.T_Nev)
                {
                    case "Aram":
                        t = "Flash";
                        sz = "Yellowgreen";
                        break;
                    case "Viz":
                        t = "Water";
                        sz = "blue";
                        break;
                    case "Gaz":
                        t = "GasStation";
                        sz = "Tan";
                        break;
                    default:
                        t = "More";
                        sz = "Red";
                        break;
                }
               
                
                rezsik.Add(new Rezsik(x.Rid, x.Oraallas, x.Fizetendo, x.Datum, x.Felh_Nev, t,sz));
                
            }
            return rezsik;
        }
        public List<Rezsik> getdata(string rtipus)
        {
            rezsik = new List<Rezsik>();
            rezsikDBContainer = new ResziModelContainer();
            var er = (from x in rezsikDBContainer.Rezsik
                      where x.Tipus.T_Nev == rtipus
                      select new { x.Rid, x.Tipus.T_Nev, x.Fizetendo, x.Oraallas, x.Datum, x.Felhasznalo.Felh_Nev }).ToList();
            string t, sz;
            foreach (var x in er)
            {
                switch (x.T_Nev)
                {
                    case "Aram":
                        t = "Flash";
                        sz = "Yellowgreen";
                        break;
                    case "Viz":
                        t = "Water";
                        sz = "blue";
                        break;
                    case "Gaz":
                        t = "GasStation";
                        sz = "Tan";
                        break;
                    default:
                        t = "More";
                        sz = "Red";
                        break;
                }


                rezsik.Add(new Rezsik(x.Rid, x.Oraallas, x.Fizetendo, x.Datum, x.Felh_Nev, t, sz));

            }
            return rezsik;
        }

    }
}
