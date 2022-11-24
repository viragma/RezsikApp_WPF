using MahApps.Metro.IconPacks;
using RezsikApp_WPF.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RezsikApp_WPF.View
{
    public partial class PageRezsik : Page
    {
        private ResziModelContainer rezsi;
        private Data adatok;       
        private string pr;
        public PageRezsik(string pageRezsi)
        {
            rezsi = new ResziModelContainer();
            this.pr=pageRezsi;       
            InitializeComponent();
            adatok = new Data();
            Lekerdezes(pr);
        }
        //Konstruktor által kapott menu adatok lekérdezése
        private void Lekerdezes(string pr)
        {
            List<Rezsi> lista = new List<Rezsi>();
            tbFejlec.Text = pr;
            
            if (pr == "Home")
            {
                
                //Kezdő képenyőn minden adat látható
                lista = adatok.getalldata();
                icFejlec.Foreground = Brushes.MediumPurple;
                icFejlec.Kind = PackIconMaterialKind.Home;

            }
            else
            {
                var iconS = adatok.setIconColor(pr);
                icFejlec.Kind = iconS.iconPack;
                icFejlec.Foreground = iconS.colorPack;
                // Adott menüre szürt lekérdezés
                 lista = adatok.getdata(pr);
             
            }
            dgAdatracs.Visibility = Visibility.Visible;
            grModiRezsi.Visibility = Visibility.Collapsed;
            ujRezsi.Visibility = Visibility.Collapsed;
            dgAdatracs.ItemsSource = lista;
        }
        //Új adatok felületének láthatóvá tétele
        private void ujrezsi_Click(object sender, RoutedEventArgs e)
        {
            bindcombo();
            grModiRezsi.Visibility = Visibility.Collapsed;
            dgAdatracs.Visibility = Visibility.Collapsed;
            ujRezsi.Visibility = Visibility.Visible;
        }
        //Listás adatok felületének láthatóvá tétele
        private void Rezsik_Click(object sender, RoutedEventArgs e)
        {
            dgAdatracs.Visibility = Visibility.Visible;
            grModiRezsi.Visibility = Visibility.Collapsed;
            ujRezsi.Visibility = Visibility.Collapsed;
        }
        //Módosítáni kívánt sor adatok felületének láthatóvá tétele, mezök feltöltése a kiválasztott sor adataival
        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            Rezsi r = dgAdatracs.SelectedItem as Rezsi;
            dgAdatracs.Visibility = Visibility.Collapsed;
            ujRezsi.Visibility = Visibility.Collapsed;
            grModiRezsi.Visibility = Visibility.Visible;
            tbModFizetendo.Text = r.fizetendo.ToString();
            tbModOraallas.Text = r.oraallas.ToString();
            dpModDate.Text = r.datum.ToString();
        }
        //Comboboxhoz való Tipusok lekérdezése
        private void bindcombo()
        {
            rezsi = new ResziModelContainer();
            var tips = (from x in rezsi.TipusokSet
                        select new { x.Tid, x.Tipus_Nev }).ToList();
            DataContext = tips;
        }
        //Módosítás mentése
        private void btModRezsi_Click(object sender, RoutedEventArgs e)
        {
            Rezsi r = dgAdatracs.SelectedItem as Rezsi;
            Int32 id = r.id;
            Rezsik mr = rezsi.RezsikSet.SingleOrDefault(x => x.Rid == id);
            mr.Oraallas = double.Parse(tbModOraallas.Text);
            mr.Fizetendo = double.Parse(tbModFizetendo.Text);
            mr.Datum = DateTime.Parse(dpModDate.Text);
            rezsi.SaveChanges();
            Lekerdezes(pr);
        }
        //Új adatok felvétele
        private void btNewRezsi_Click(object sender, RoutedEventArgs e)
        {
            Int32 tid = cbSzamlaTipus.SelectedIndex + 1;
            var ti = (from t in rezsi.TipusokSet
                      where t.Tid == tid
                      select t).Single();

            var fe = (from f in rezsi.FelhasznalokSet
                      where f.Felh_Nev == "Admin"
                      select f).Single();
            Rezsik ujRezsi = new Rezsik
            {
                Oraallas = double.Parse(tbOraallas.Text),
                Fizetendo = double.Parse(tbFizetendo.Text),
                Datum = DateTime.Parse(dpDate.Text),
                Felhasznalok = fe,
                Tipusok = ti
            };
            rezsi.RezsikSet.Add(ujRezsi);
            rezsi.SaveChanges();

            Lekerdezes(pr);
        }
        //Kivánt sor törlése
        public void btRemove_Click(object sender, RoutedEventArgs e)
        {
            Rezsi r = dgAdatracs.SelectedItem as Rezsi;
            Int32 id = r.id;
            var er = (from x in rezsi.RezsikSet
                      where x.Rid == id
                      select x).FirstOrDefault();
            rezsi.RezsikSet.Remove(er);
            rezsi.SaveChanges();
            Lekerdezes(pr);
        }
    }
}
