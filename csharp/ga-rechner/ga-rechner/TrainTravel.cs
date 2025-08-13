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
        protected double PricePerJourney { get; set; }
        protected EnumTrainClass TrainClass {  get; set; }

        protected TrainTravel(string TTName, string TTStart, string TTEnd, double TTPricePerJourney, EnumTrainClass TTTrainClass)
        {
            this.Name = TTName;
            this.Start = TTStart;
            this.End = TTEnd;
            this.PricePerJourney = TTPricePerJourney;
            this.TrainClass = TTTrainClass;
        }
    }
}
