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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ResziModelContainer rezsikDBContainer;
        public MainWindow()
        {
            InitializeComponent();
            rezsikDBContainer = new ResziModelContainer();
            userLekerdezes();
        }

        private void userLekerdezes()
        {
            try
            {
                var er = (from x in rezsikDBContainer.Felhasznalok
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
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaxmimized = false;
      /*  private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaxmimized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaxmimized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaxmimized = true;
                }

            }
        }*/

        private void FooldalClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.Fooldal();
        }

        private void AramClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.Aram();
        }

        private void GazClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.Gaz();
        }

        private void VizClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.Viz();
        }

        private void EgyebbClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.Egyebb();
        }

        private void BeallitasClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new View.Beallitasok();
        }

        private void KilepesClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


    }
}
