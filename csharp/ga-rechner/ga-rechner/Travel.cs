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

        //public Travel(EnumSingleRetour TravelSingleRetour,  int TravelPerYear)
        //{
        //    this.SingleRetour = TravelSingleRetour;
        //    this.TravelsPerYear = TravelPerYear;
        //}

        //public Travel(EnumSingleRetour TravelSingleRetour)
        //{
        //    this.SingleRetour = TravelSingleRetour;
        //    this.TravelsPerYear = 1;
        //}

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
