using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RezsikApp_WPF.Model
{
    //Osztály a lekérdezések egyszerűségért
    internal class Data
    {
        public List<Rezsi> rezsik;
        private ResziModelContainer rezsikDBContainer;
        public struct viewType
        {
            public string icon;
            public string color;
            public PackIconMaterialKind iconPack;
            public SolidColorBrush colorPack;
        }

        public Data()
        {
           
        }

        //Összes Rezsi adat lekérdezése és Rezsi tipusu listába betöltés a megjelenítéshez.
        public List<Rezsi> getalldata()
        {
            rezsik = new List<Rezsi>();
            rezsikDBContainer = new ResziModelContainer();
            //Adatok lekérése
            var er = (from x in rezsikDBContainer.RezsikSet
                      select new { x.Rid, x.Tipusok.Tipus_Nev, x.Fizetendo, x.Oraallas, x.Datum, x.Felhasznalok.Felh_Nev }).ToList();
            foreach (var x in er)
            {
                viewType ic =setIconColor(x.Tipus_Nev);
                rezsik.Add(new Rezsi(x.Rid, x.Oraallas, x.Fizetendo, x.Datum, x.Felh_Nev, ic.icon,ic.color));               
            }
            return rezsik;
        }
        //Paraméteres lekérdezés a Tipus neve alapján lekérdezi az abba tartozó rezsiket
        public List<Rezsi> getdata(string rtipus)
        {
            rezsik = new List<Rezsi>();
            rezsikDBContainer = new ResziModelContainer();
            var er = (from x in rezsikDBContainer.RezsikSet
                      where x.Tipusok.Tipus_Nev == rtipus
                      select new { x.Rid, x.Tipusok.Tipus_Nev, x.Fizetendo, x.Oraallas, x.Datum, x.Felhasznalok.Felh_Nev }).ToList();
            viewType ic = setIconColor(rtipus);
            foreach (var x in er)
            {
               rezsik.Add(new Rezsi(x.Rid, x.Oraallas, x.Fizetendo, x.Datum, x.Felh_Nev, ic.icon.ToString(), ic.color.ToString()));

            }
            return rezsik;
        }
        //Tipus alapján kiválasztja melyik icon és szín kell
        public viewType setIconColor(string rtype)
        {
            viewType t;
            switch (rtype)
            {
                case "Aram":
                    t.icon = "Flash";
                    t.color = "Yellowgreen";
                    t.iconPack = PackIconMaterialKind.Flash;
                    t.colorPack = Brushes.YellowGreen;
                    break;
                case "Viz":
                    t.icon = "Water";
                    t.color = "blue";
                    t.iconPack = PackIconMaterialKind.Water;
                    t.colorPack = Brushes.Blue;
                    break;
                case "Gaz":
                    t.icon = "GasStation";
                    t.color = "Tan";
                    t.iconPack = PackIconMaterialKind.GasStation;
                    t.colorPack = Brushes.Tan;
                    break;
                default:
                    t.icon = "More";
                    t.color = "Red";
                    t.iconPack = PackIconMaterialKind.More;
                    t.colorPack = Brushes.Red;
                    break;
            }
            return t;
        }


    }
}
