using RezsikApp_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    public partial class Aram : Page
    {
        private ResziModelContainer rezsi;
        private Data adatok;
        public Aram()
        {
            InitializeComponent();
            adatok = new Data();
            
            Lekerdezes();
        }

        private void Lekerdezes()
        {
            List<Rezsik> lista = adatok.getdata("Aram");
            dgAdatracs.Visibility = Visibility.Visible;
            dgAdatracs.ItemsSource = lista;
        }


        private void ujrezsi_Click(object sender, RoutedEventArgs e)
        {
            bindcombo();
            dgAdatracs.Visibility = Visibility.Collapsed;
            ujRezsi.Visibility = Visibility.Visible;
            



        }
        private void Rezsik_Click(object sender, RoutedEventArgs e)
        {
            dgAdatracs.Visibility = Visibility.Visible;
            ujRezsi.Visibility = Visibility.Collapsed;
        }

        
        private void bindcombo()
        {
            rezsi = new ResziModelContainer();
            var tips = (from x in rezsi.Tipusok
                        select new { x.Tid,x.T_Nev }).ToList();
            DataContext = tips;
        }

  

        /*   private void miHelysegek_Click(object sender, RoutedEventArgs e)
           {

           }*/
    }
}
