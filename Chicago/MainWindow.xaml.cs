using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

namespace Chicago
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Kortlek kortlek = new Kortlek();
        List<string> kortlista = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_DelaUt_Click(object sender, RoutedEventArgs e)
        {
            kortlista = kortlek.skapaKortlek();
            int y = 1;
            for (int i = 0; i < 20; i++)
            {
                Random rnd = new Random();
                int x = rnd.Next(kortlista.Count);
                if (i < 5)
                {
                    string controlName = $"a{y}b";
                    Image imgControl = FindName(controlName) as Image;
                    if (imgControl != null)
                    {
                        string imageName = @"C:\Users\viktor.b - elev1\Pictures\Kort\" + kortlista[x] + ".png";
                        Uri imageUri = new Uri(imageName);

                        imgControl.Source = new BitmapImage(imageUri);

                    }
                }
                else if (i < 10)
                {

                }
                else if (i < 15)
                {

                }
                else
                {

                }
                if (y < 5) y++;
                else y = 1;
                kortlista.RemoveAt(x);
            }
        }
    }
}
