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

        public Commute(int CommuteTravelDaysPerWeek, int CommuteRidesPerDay, string CommuteName, string CommuteStart, string CommuteEnd, double CommutePricePerJourney, EnumTrainClass CommuteTrainClass, int CommuteVacationWeeks = 4)
            : base(TTName: CommuteName, TTStart: CommuteStart, TTEnd: CommuteEnd, TTPricePerJourney: CommutePricePerJourney, TTTrainClass: CommuteTrainClass)
        {
            this.TravelDaysPerWeek = CommuteTravelDaysPerWeek;
            this.RidesPerDay = CommuteRidesPerDay;
            this.VacationWeeks = CommuteVacationWeeks;
            this.Name = CommuteName;
            this.Start = CommuteStart;
            this.End = CommuteEnd;
            this.PricePerJourney = CommutePricePerJourney;
            this.TrainClass = CommuteTrainClass;
        }

        public double CalculateCommuteCostPerYear()
        {
            double costsPerDay = this.PricePerJourney * this.RidesPerDay;
            double costsPerWeek = costsPerDay * this.TravelDaysPerWeek;
            double costsPerYear = costsPerWeek * (52 - this.VacationWeeks);

            return costsPerYear;
        }
    }
}
