using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ga_rechner
{
    /// <summary>
    /// Represents a travel route taken by a person.
    /// </summary>
    public class Travel : TrainTravel
    {
        private EnumSingleRetour SingleRetour { get; set; }
        private int TravelsPerYear { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Travel"/> class.
        /// </summary>
        /// <param name="TravelSingleRetour">The type of journey (single or return).</param>
        /// <param name="TravelSimpleFullPricePerJourney">The full price per journey for one way of the journey.</param>
        /// <param name="TravelPerYear">(optional) The number of journeys per year. (Default: 1)</param>
        /// <param name="TravelName">(optional) The name of the travel route.</param>
        /// <param name="TravelStart">(optional) The start location of the travel route.</param>
        /// <param name="TravelEnd">(optional) The end location of the travel route.</param>
        /// <param name="TravelTrainClass">(optional) The train class for the travel route. (Default: Second Class)</param>
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

        /// <summary>
        /// Calculates the total cost of this type of travel. It's the price multiplied by the number of journeys per year. If the journey is a return journey, the cost is doubled.
        /// </summary>
        /// <returns>The total cost of this type of travel.</returns>
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
