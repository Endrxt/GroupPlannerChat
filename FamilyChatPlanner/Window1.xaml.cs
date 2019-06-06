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

namespace FamilyChatPlanner
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        interface Anmeldung
        {

        }

        List<Post> infos = new List<Post>();

        public Window1()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (sucukPlanner.SelectedDate is null)
            //{
            //    sucukPlanner.SelectedDate = DateTime.Now;
            //}

            //MessageBox.Show(sucukPlanner.SelectedDate.ToString() + " hat an dem Tag SUCUK gegessen!");
            //LbMessages.Items.Add($"{MainWindow.ww.username}\n{TbInput.Text}");
            //LbMessages.Items.Add(TbInput.Text);

            Post Post1 = new Post()
            {
                Erstelldatum= DateTime.Now/*.Date*/,
                Ablaufdatum = (DateTime)DatumPicker.SelectedDate,
                Kurzbeschreibung = TbInput.Text
            };

            infos.Add(Post1);
            LbMessages.SelectedItem = LbMessages.Items[0];           
            txtInfos.Text = $"{infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Erstelldatum} \n {infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Ablaufdatum.ToString("dd/MM/yyyy")} \n {infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Kurzbeschreibung}";
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            LbMessages.Items.Remove(LbMessages.SelectedItem);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LbMessages.Items.Add($"{MainWindow.ww.username}\n{TbInput.Text}");
                
                TbInput.Text = " ";
            }
            Post Post1 = new Post()
            {
                Erstelldatum = DateTime.Now/*.Date*/,
                Ablaufdatum = (DateTime)DatumPicker.SelectedDate,
                Kurzbeschreibung = TbInput.Text
            };

            infos.Add(Post1);

        }

        private void LbMessages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LbMessages.SelectedItem = LbMessages.Items[0];


                txtInfos.Text = $"{infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Erstelldatum} \n {infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Ablaufdatum.ToString("dd/MM/yyyy")} \n {infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Kurzbeschreibung}";

        }
    }
}
