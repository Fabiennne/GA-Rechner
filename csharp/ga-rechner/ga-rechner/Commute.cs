using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ga_rechner
{
    public class Commute : TrainTravel
    {
        private int TravelDaysPerWeek {  get; set; }
        private int RidesPerDay { get; set; }
        private int VacationWeeks { get; set; }

        public double CalculateCommuteCostPerYear()
        {
            double costsPerDay = this.PricePerJourney * this.RidesPerDay;
            double costsPerWeek = costsPerDay * this.TravelDaysPerWeek;
            double costsPerYear = costsPerWeek * (52 - this.VacationWeeks);

            return costsPerYear;
        }
    }
}
