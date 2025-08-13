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

        public Travel(EnumSingleRetour TravelSingleRetour, string TravelName, string TravelStart, string TravelEnd, double TravelPricePerJourney, EnumTrainClass TravelTrainClass, int TravelPerYear = 1)
            : base(TTName: TravelName, TTStart: TravelStart, TTEnd: TravelEnd, TTPricePerJourney: TravelPricePerJourney, TTTrainClass: TravelTrainClass)
        {
            this.SingleRetour = TravelSingleRetour;
            this.TravelsPerYear = TravelPerYear;
            this.Name = TravelName;
            this.Start = TravelStart;
            this.End = TravelEnd;
            this.PricePerJourney = TravelPricePerJourney;
            this.TrainClass = TravelTrainClass;
        }

        public double CalculateTravelCost()
        {
            if (SingleRetour == EnumSingleRetour.Retour)
            {
                return 2 * this.PricePerJourney * this.TravelsPerYear;
            }
            else
            {
                return this.PricePerJourney * this.TravelsPerYear;
            }
        }
    }
}
