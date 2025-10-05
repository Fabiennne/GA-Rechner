using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ga_rechner
{
    /// <summary>
    /// Represents a commuting route taken by a person.
    /// </summary>
    public class Commute : TrainTravel
    {

        private int TravelDaysPerWeek {  get; set; }
        private int RidesPerDay { get; set; }
        private int VacationWeeks { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Commute"/> class.
        /// </summary>
        /// <param name="CommuteTravelDaysPerWeek">The number of days per week the commute takes place.</param>
        /// <param name="CommuteRidesPerDay">The number of rides taken per day.</param>
        /// <param name="CommuteSimpleFullPricePerJourney">The full price per journey for one way of the commute.</param>
        /// <param name="CommuteVacationWeeks">(optional) The number of vacation weeks per year. The amount of weeks where this commute is not taken. (Default: 4)</param>
        /// <param name="CommuteName">(optional) The name of the commute route.</param>
        /// <param name="CommuteStart">(optional) The start location of the commute route.</param>
        /// <param name="CommuteEnd">(optional) The end location of the commute route.</param>
        /// <param name="CommuteTrainClass">(optional) The train class for the commute route. (Default: Second Class)</param>
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

        /// <summary>
        /// Calculates the total cost of this type of commute per year.
        /// </summary>
        /// <returns>The total cost of of this type of commute per year.</returns>
        public double CalculateCommuteCostPerYear()
        {
            double costsPerDay = this.SimpleFullPricePerJourney * this.RidesPerDay;
            double costsPerWeek = costsPerDay * this.TravelDaysPerWeek;
            double costsPerYear = costsPerWeek * (AmountWeeksPerYear - this.VacationWeeks);

            return costsPerYear;
        }
    }
}
