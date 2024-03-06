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
using System.Windows.Shapes;

namespace Chicago
{
    /// <summary>
    /// Interaction logic for ScoreCard.xaml
    /// </summary>
    public partial class ScoreCard : Window
    {
        MainWindow main;
        public ScoreCard(MainWindow w)
        {
            InitializeComponent();
            main = w;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            main.scoreCard = null;
        }
    }
}
