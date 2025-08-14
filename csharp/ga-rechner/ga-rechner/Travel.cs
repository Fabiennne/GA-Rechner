using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ga_rechner
{
    public class Travel : TrainTravel
    {
        private EnumSingleRetour SingleRetour { get; set; }
        private int TravelsPerYear { get; set; }

        public Travel(EnumSingleRetour TravelSingleRetour, double TravelSimpleFullPricePerJourney, int TravelPerYear = 1, string TravelName = "travel name", string TravelStart = "travel start", string TravelEnd = "travel end", EnumTrainClass TravelTrainClass = EnumTrainClass.Second)
            : base(TTName: TravelName, TTStart: TravelStart, TTEnd: TravelEnd, TTSimpleFullPricePerJourney: TravelSimpleFullPricePerJourney, TTTrainClass: TravelTrainClass)
        {
            this.SingleRetour = TravelSingleRetour;
            this.TravelsPerYear = TravelPerYear;
            this.Name = TravelName;
            this.Start = TravelStart;
            this.End = TravelEnd;
            this.SimpleFullPricePerJourney = TravelSimpleFullPricePerJourney;
            this.TrainClass = TravelTrainClass;
        }

        public double CalculateTravelCost()
        {
            if (SingleRetour == EnumSingleRetour.Retour)
            {
                return 2 * this.SimpleFullPricePerJourney * this.TravelsPerYear;
            }
            else
            {
                return this.SimpleFullPricePerJourney * this.TravelsPerYear;
            }
        }
    }
}
