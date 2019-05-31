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
using System.IO;

namespace FamilyChatPlanner
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string username;
        static public MainWindow ww;

        public MainWindow()
        {
            ww = this;
            InitializeComponent();
            
        }

        public void BtnAnmelden_Click(object sender, RoutedEventArgs e)
        {
            StreamReader stream = new StreamReader(@"../../../pw.txt");

            while (stream.EndOfStream == false)
            {
                string line = stream.ReadLine();
                string[] array = line.Split(';');

                if (array[0] == UserBox.Text && array[1] == PwBox.Password)
                {
                    username = UserBox.Text;
                    Window1 Window = new Window1();
                    App.Current.MainWindow = Window;
                    this.Hide();
                    Window.Show();
                    //change statupURi in App.xml

                }
            }

            UserBox.Text = "";
            PwBox.Password = "";
            stream.Close();

        }

        public  void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter stream = new StreamWriter(@"../../../pw.txt", true);

            string name = UserBox.Text;
            string pw = PwBox.Password;
            string line = name + ';' + pw;

            stream.WriteLine(line);
            stream.Close();

            Window1 Window = new Window1();
            App.Current.MainWindow = Window;
            this.Close();
            Window.Show();
        }

    }
}
