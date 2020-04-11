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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2020MintaKozepGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string Neve { get; set; }
        public static string Tipp { get; set; }
        public static int TippekSzama { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Jatek.Beolvasas("egyszamjatek2.txt");
        }

        private void jatekosTippjei_TextChanged(object sender, TextChangedEventArgs e)
        {
            Tipp = jatekosTippjei.Text.TrimEnd();

            TippekSzama = Tipp.Split(' ').Length;

            lblTipp.Content = $"{TippekSzama} db";
        }

        private void jatekosNeve_TextChanged(object sender, TextChangedEventArgs e)
        {
            Neve = jatekosNeve.Text;
        }

        private void btnJatekosHozzadasa_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(Neve);

            int ugyanaz = 0;

            for (int i = 0; i < Jatek.Adat.Count; i++)
            {
                if (Jatek.Adat[i].Neve == Neve)
                {
                    ugyanaz++;
                }
            }

            if(ugyanaz != 0)
                MessageBox.Show("Van már ilyen nevű játékos!", "Hiba!");

            if (TippekSzama != Jatek.Adat[0].SzamTippek.Count)
                MessageBox.Show("A tippek száma nem megfelelő!", "Hiba");

            if (ugyanaz == 0 && TippekSzama == Jatek.Adat[0].SzamTippek.Count)
            {
                FileStream fuz = new FileStream(@"egyszamjatek2.txt", FileMode.Append);
                StreamWriter ki = new StreamWriter(fuz, Encoding.UTF8);

                ki.WriteLine($"{Neve} {Tipp}");
                ki.Flush();

                ki.Close();
                fuz.Close();

                MessageBox.Show("Az állomány bővítése sikeres volt!", "Üzenet");
            }
        }
    }
}
