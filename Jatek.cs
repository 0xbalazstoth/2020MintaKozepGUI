using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020MintaKozepGUI
{
    class Jatek
    {
        public static List<Jatek> Adat = new List<Jatek>();
        public string Neve { get; set; }
        public List<int> SzamTippek { get; set; }
        public static int megadottFordulo { get; set; }

        public Jatek(string sor)
        {
            SzamTippek = new List<int>();
            string[] split = sor.Split(' ');
            Neve = split[0];
            for (int i = 1; i < split.Length; i++)
            {
                SzamTippek.Add(Convert.ToInt32(split[i]));
            }
        }

        public static void Beolvasas(string fajl)
        {
            using (StreamReader olvas = new StreamReader(fajl))
            {
                while (!olvas.EndOfStream)
                {
                    Jatek jatek = new Jatek(olvas.ReadLine());

                    Adat.Add(jatek);
                }
            }
        }
    }
}
