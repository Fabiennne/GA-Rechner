using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ga_rechner
{
    public abstract class TrainTravel
    {
        protected string Name { get; set; }
        protected string Start {  get; set; }
        protected string End { get; set; }
        protected double SimpleFullPricePerJourney { get; set; }
        protected EnumTrainClass TrainClass {  get; set; }
        protected const int AmountWeeksPerYear = 52;

        protected TrainTravel(string TTName, string TTStart, string TTEnd, double TTSimpleFullPricePerJourney, EnumTrainClass TTTrainClass)
        {
            this.Name = TTName;
            this.Start = TTStart;
            this.End = TTEnd;
            this.SimpleFullPricePerJourney = TTSimpleFullPricePerJourney;
            this.TrainClass = TTTrainClass;
        }
    }
}
