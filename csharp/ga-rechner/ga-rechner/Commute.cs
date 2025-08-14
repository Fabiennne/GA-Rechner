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

        public Commute(int CommuteTravelDaysPerWeek, int CommuteRidesPerDay, double CommuteSimpleFullPricePerJourney, int CommuteVacationWeeks = 4, string CommuteName = "commute name", string CommuteStart = "commute start", string CommuteEnd = "commute end", EnumTrainClass CommuteTrainClass = EnumTrainClass.Second)
            : base(TTName: CommuteName, TTStart: CommuteStart, TTEnd: CommuteEnd, TTSimpleFullPricePerJourney: CommuteSimpleFullPricePerJourney, TTTrainClass: CommuteTrainClass)
        {
            this.TravelDaysPerWeek = CommuteTravelDaysPerWeek;
            this.RidesPerDay = CommuteRidesPerDay;
            this.VacationWeeks = CommuteVacationWeeks;
            this.Name = CommuteName;
            this.Start = CommuteStart;
            this.End = CommuteEnd;
            this.SimpleFullPricePerJourney = CommuteSimpleFullPricePerJourney;
            this.TrainClass = CommuteTrainClass;
        }


        public double CalculateCommuteCostPerYear()
        {
            double costsPerDay = this.SimpleFullPricePerJourney * this.RidesPerDay;
            double costsPerWeek = costsPerDay * this.TravelDaysPerWeek;
            double costsPerYear = costsPerWeek * (AmountWeeksPerYear - this.VacationWeeks);

            return costsPerYear;
        }
    }
}
