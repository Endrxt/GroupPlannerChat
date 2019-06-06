using System;
using System.Collections.Generic;
using System.IO;
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

        List<Post> infos = new List<Post>();

        public Window1()
        {
            InitializeComponent();
            //StreamReader stream = new StreamReader(@"../../../daten.txt");
            //string daten = "";

            //string line = stream.ReadLine();
            //daten += line;

            //string[] array = daten.Split(';');

            //foreach (var item in array)
            //{
            //    LbMessages.Items.Add(item);
            //}

            //while (stream.EndOfStream == false)
            //{
            //    line = stream.ReadLine();
            //    string[] feindaten = line.Split(';');

            //    Post Post1 = new Post()
            //    {
            //        Erstelldatum = DateTime.Parse(feindaten[0]),
            //        Ablaufdatum = DateTime.Parse(feindaten[1]),
            //        Kurzbeschreibung = feindaten[2]
            //    };

            //    infos.Add(Post1);

            //}
            //stream.Close();
            //LbMessages.Items.RemoveAt(LbMessages.Items.Count - 1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //LbMessages.Items.Add($"{MainWindow.ww.username}\n{TbInput.Text}");
            //LbMessages.Items.Add(TbInput.Text);

            try
            {
                infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Ablaufdatum = (DateTime)DatumPicker.SelectedDate;
            }
            catch (Exception)
            {
                infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Ablaufdatum = DateTime.Now;
            }
            infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Kurzbeschreibung = TbInput.Text;

            //infos.Add(Post1);
            LbMessages.SelectedItem = LbMessages.Items[0];
            txtInfos.Text = $"Erstellzeit: {infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Erstelldatum}\nFrist: {infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Ablaufdatum.ToString("dd/MM/yyyy")}\nBeschreibung:\n{infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Kurzbeschreibung}";
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            infos.RemoveAt(LbMessages.Items.IndexOf(LbMessages.SelectedItem));
            LbMessages.Items.Remove(LbMessages.SelectedItem);
            LbMessages.SelectedItem = LbMessages.Items[0];

        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LbMessages.Items.Add($"{MainWindow.ww.username}: {TbInput.Text}");
                StreamWriter stream = new StreamWriter(@"../../../daten.txt", true);
                stream.Write($"{MainWindow.ww.username}: {TbInput.Text};");
                stream.Close();

                TbInput.Text = "";
            }
            Post Post1 = new Post()
            {
                Erstelldatum = DateTime.Now/*.Date*/,
                Ablaufdatum = DateTime.Now,
                Kurzbeschreibung = TbInput.Text
            };

            infos.Add(Post1);

            StreamWriter streamInfos = new StreamWriter(@"../../../daten.txt", true);
            streamInfos.WriteLine($"{Post1.Erstelldatum};{Post1.Ablaufdatum};{Post1.Kurzbeschreibung}");
            streamInfos.Close();
        }

        private void LbMessages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtInfos.Text = $"Erstellzeit: {infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Erstelldatum}\nFrist: {infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Ablaufdatum.ToString("dd/MM/yyyy")}\nBeschreibung:\n{infos[LbMessages.Items.IndexOf(LbMessages.SelectedItem)].Kurzbeschreibung}";
        }
    }
}
