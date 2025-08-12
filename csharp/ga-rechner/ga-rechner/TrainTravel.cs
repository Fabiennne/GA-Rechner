using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ga_rechner
{
    public abstract class TrainTravel
    {
        protected string Start {  get; private set; }
        protected string End { get; private set; }
        protected double PricePerJourney { get; private set; }
        protected EnumTrainClass TrainClass {  get; private set; }
    }
}
