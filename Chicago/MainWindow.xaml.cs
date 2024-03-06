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
        List<string> KortMedSiffror = new List<string>();
        List<string> Sp1 = new List<string>();
        List<string> Sp2 = new List<string>();
        List<string> Sp3 = new List<string>();
        List<string> Sp4 = new List<string>();

        public ScoreCard scoreCard {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void Button_DelaUt_Click(object sender, RoutedEventArgs e)
        {
            kortlista = kortlek.skapaKortlek();
            KortMedSiffror = KortSet.OmvandlaKortlek(kortlista);
            int y = 1;
            for (int i = 0; i < 20; i++)
            {
                Random rnd = new Random();
                int x = rnd.Next(kortlista.Count);
                if (i < 5)
                {
                    string controlName = $"A{y}b";
                    Image imgControl = FindName(controlName) as Image;
                    if (imgControl != null)
                    {
                        string imageName = @"C:\Users\viktor.b-elev1\Pictures\Kort\" + kortlista[x] + ".png";
                        Uri imageUri = new Uri(imageName);

                        imgControl.Source = new BitmapImage(imageUri);
                        Sp1.Add(kortlista[x]);
                    }
                }
                else if (i < 10)
                {
                    string controlName = $"B{y}b";
                    Image imgControl = FindName(controlName) as Image;
                    if (imgControl != null)
                    {
                        string imageName = @"C:\Users\viktor.b-elev1\Pictures\Kort\" + kortlista[x] + ".png";
                        Uri imageUri = new Uri(imageName);

                        imgControl.Source = new BitmapImage(imageUri);
                        Sp2.Add(kortlista[x]);
                    }
                }
                else if (i < 15)
                {
                    string controlName = $"C{y}b";
                    Image imgControl = FindName(controlName) as Image;
                    if (imgControl != null)
                    {
                        string imageName = @"C:\Users\viktor.b-elev1\Pictures\Kort\" + kortlista[x] + ".png";
                        Uri imageUri = new Uri(imageName);

                        imgControl.Source = new BitmapImage(imageUri);
                        Sp3.Add(kortlista[x]);
                    }
                }
                else
                {
                    string controlName = $"D{y}b";
                    Image imgControl = FindName(controlName) as Image;
                    if (imgControl != null)
                    {
                        string imageName = @"C:\Users\viktor.b-elev1\Pictures\Kort\" + kortlista[x] + ".png";
                        Uri imageUri = new Uri(imageName);

                        imgControl.Source = new BitmapImage(imageUri);
                        Sp4.Add(kortlista[x]);
                    }
                }

                if (y < 5) y++;
                else y = 1;
                kortlista.RemoveAt(x);
            }
            Button_DelaUt.IsEnabled = false;
        }

        private void A1_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (scoreCard == null)
            {
                scoreCard = new ScoreCard(this); 
            }
            scoreCard.Show();
            scoreCard.Activate();
        }

    }
}
