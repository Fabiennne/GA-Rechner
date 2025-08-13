using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ga_rechner
{
    public class Prices
    {
        //TODO: should i do it with unsigned int?
        public static readonly int gaErwachsenKl1 = 6520;
        public static readonly int gaErwachsenKl2 = 3995;
        public static readonly int gaKindKl1 = 2850;
        public static readonly int gaKindKl2 = 1720;
        public static readonly int gaJugendKl1 = 4450;
        public static readonly int gaJugendKl2 = 2780;
        public static readonly int ga25Kl1 = 5670;
        public static readonly int ga25Kl2 = 3495;
        public static readonly int gaSeniorKl1 = 4950;
        public static readonly int gaSeniorKl2 = 3040;
        public static readonly int gaBehinderungKl1 = 4120;
        public static readonly int gaBehinderungKl2 = 2600;
        public static readonly int gaDuoKl1 = 4450;
        public static readonly int gaDuoKl2 = 2860;

        public static readonly int halbErwachsenNeu = 190;
        public static readonly int halbErwachsenTreu = 170;
        public static readonly int halbJugendNeu = 120;
        public static readonly int halbJugendTreu = 100;

        public static readonly (string Name, int Cost, int Credit) halbPlusErwachsen1000 = ("Halbtax PLUS 1000.", 800, 1000);
        public static readonly (string Name, int Cost, int Credit) halbPlusErwachsen2000 = ("Halbtax PLUS 2000.", 1500, 2000);
        public static readonly (string Name, int Cost, int Credit) halbPlusErwachsen3000 = ("Halbtax PLUS 3000.", 2100, 3000);

        public static readonly (string Name, int Cost, int Credit) halbPlusJugend1000 = ("Halbtax PLUS Jugend 1000.", 600, 1000);
        public static readonly (string Name, int Cost, int Credit) halbPlusJugend2000 = ("Halbtax PLUS Jugend 2000.", 1125, 2000);
        public static readonly (string Name, int Cost, int Credit) halbPlusJugend3000 = ("Halbtax PLUS Jugend 3000.", 1575, 3000);
    }
}
