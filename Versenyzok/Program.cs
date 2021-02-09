using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Versenyzok
{
    class Program
    {
        /*
         * 
         */

        static List<Versenyzo> Versenyzok = new List<Versenyzo>();
        static void Main(string[] args)
        {
            Beolvas("pilotak.csv");
            Console.WriteLine($"3. feladat: {Versenyzok.Count}");
            Console.WriteLine($"\n4. feladat: {Versenyzok.Last().Nev}");
            Console.WriteLine($"\n5. feladat:");
            foreach (var item in Versenyzok.FindAll(a => a.Szuletesi_datum < DateTime.Parse("1901-01-01")))
            {
                Console.WriteLine($"\t{item.Nev} ({item.Szuletesi_datum.ToString("yyyy. MM. dd.")})");
            }

            int rajtszam = Versenyzok.FindAll(a => a.Rajtszam != 0).Min(b => b.Rajtszam);
            //-- 6. feladat -------------------------------
            Console.WriteLine($"\n6. feladat: {Versenyzok.Find(a => a.Rajtszam==rajtszam).Nemzetiseg}");
            //-- 7. feladat -------------------------------
             var ver = Versenyzok.FindAll(a => a.Rajtszam > 0).GroupBy(b => b.Rajtszam).Select(c => new { rsz = c.Key, db = c.Count() }).Where(d => d.db > 1);

            Console.WriteLine($"\n7. feladat: {string.Join(", ",ver.Select(a => a.rsz))}");
            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }

        static void Beolvas(string fajl)
        {
            using (StreamReader sr = new StreamReader(fajl))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    Versenyzok.Add(new Versenyzo(sr.ReadLine().Split(';')));
                }
            }
        }
    }
}
