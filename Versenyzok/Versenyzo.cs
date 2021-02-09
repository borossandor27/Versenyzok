using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versenyzok
{
    class Versenyzo
    {
        //-- név;születési_dátum;nemzetiség;rajtszám
        string nev;
        DateTime szuletesi_datum;
        string nemzetiseg;
        int rajtszam;

        public Versenyzo(string[] sor)
        {
            nev = sor[0].Trim();
            szuletesi_datum = DateTime.Parse(sor[1].Trim());
            nemzetiseg = sor[2];
            int.TryParse(sor[3].Trim(), out rajtszam);
            //rajtszam = int.Parse();
        }

        public string Nev { get => nev; set => nev = value; }
        public DateTime Szuletesi_datum { get => szuletesi_datum; set => szuletesi_datum = value; }
        public string Nemzetiseg { get => nemzetiseg; set => nemzetiseg = value; }
        public int Rajtszam { get => rajtszam; set => rajtszam = value; }
    }
}
