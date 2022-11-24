using RezsikApp_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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

namespace RezsikApp_WPF
{
  
    public partial class MainWindow : Window
    {
        private ResziModelContainer rezsikDBContainer;
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new View.PageRezsik("Home");
            rezsikDBContainer = new ResziModelContainer();
            userLekerdezes();
        }
        //Bejelentkezés hiánya miatt.
        private void userLekerdezes()
        {
            try
            {
                var er = (from x in rezsikDBContainer.FelhasznalokSet
                          where x.Felh_Nev == "admin"
                          select new
                          {
                              x.V_Nev,
                              x.K_Nev
                          }).ToList();

                foreach (var e in er)
                {
                    userLabel.Text = e.V_Nev + " " + e.K_Nev;
                }
            }catch(Exception ex)
            {
             
                Console.WriteLine(ex.ToString());
            }
        }
        //Ablak mozgatása
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        //Adott gomb nevét át adja az osztálynak ami az alapján kéri le az adatokat.
        private void PageSelectClick(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Name.ToString();
            Main.Content = new View.PageRezsik(content);
        }
        //Beállítások menű betöltése
        private void BeallitasClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.Beallitasok();
        }
        //Kilépés
        private void KilepesClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


    }
}
