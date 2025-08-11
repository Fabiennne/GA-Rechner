using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ga_rechner
{
    public abstract class TrainTravel
    {
        protected string start {  get; private set; }
        protected string end { get; private set; }
        protected double pricePerJourney { get; private set; }
        protected enum trainClass { First, Second }
    }
}
