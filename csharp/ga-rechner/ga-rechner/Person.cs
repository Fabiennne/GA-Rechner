using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ga_rechner
{
    public class Person
    {
        private string Name { get; set; }
        private DateTime Birthday { get; set; }
        private string Street { get; set; }
        private string City { get; set; }
        private List<Travel> Travels { get; set; }
        private List<Commute> Commutes { get; set; }
        private Boolean IsHalbtaxNew { get; set; }
        
        public Person(string personName, DateTime personBirthday, string personStreet, string personCity)
        {
            this.Name = personName;
            this.Birthday = personBirthday;
            this.Street = personStreet;
            this.City = personCity;
        }

        public List<(string Name, double Cost)> CompareSubscriptions()
        {
            int age = GetAge();
            if (age < 6)
            {
                return new List<(string Name, double Cost)>
                {
                    ("Gratisfahrt mit Eltern", 0)
                };
            }

            double costs = CalculateCosts(); //

            var gaCosts = GetGAPrices(age);
            double gaCostsFirstClass = gaCosts.FirstClass; //
            double gaCostsSecondClass = gaCosts.SecondClass; //

            int halbPrice = GetHalbPrice(age);
            int[,] halbPlusPrices = GetHalbPlusPrices(age);

            double costsWithHalb = CalculateCostsWithHalb(costs, halbPrice); //

            double[] costsWithHalbPlus = CalculateCostsWithHalbPlus(halbPlusPrices, costs);
            var cheapestHalbPlus = DetermineCheapestHalbPlus(costsWithHalbPlus); //

            double[] costsWithHalbAndHalbPlus = CalculateCostsWithHalbAndHalbPlus(costs, halbPrice, halbPlusPrices);
            var cheapestHalbPlusWithHalb = DetermineCheapestHalbPlus(costsWithHalbAndHalbPlus); //

            var costsList = new List<(string Name, double Cost)>
            {
                ("Kosten ohne Abo: ", costs),
                ("GA (1.Klasse): ", gaCostsFirstClass),
                ("GA (2.Klasse): ", gaCostsSecondClass),
                ("Kosten mit Halbtax: ", costsWithHalb),
                ("Günstigstes Halbtax Plus (" + cheapestHalbPlus.Category + "): ", cheapestHalbPlus.Cost),
                ("Günstigstes Halbtax Plus (" + cheapestHalbPlus.Category + ") mit Halbtax: ", cheapestHalbPlusWithHalb.Cost)
            };

            var sortedCosts = costsList.OrderBy(t => t.Cost);

            return (List<(string Name, double Cost)>)sortedCosts;
        }

        private int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - this.Birthday.Year;
            if (today.Month < Birthday.Month)
            {
                age--;
            }
            else if (today.Month == Birthday.Month && today.Day < Birthday.Day)
            {
                age--;
            }
            return age;
        }

        public double CalculateCosts()
        {
            double travelCosts = GetTravelCosts();
            double commuteCosts = GetCommuteCosts();
            double totalCosts = travelCosts + commuteCosts;

            return totalCosts;
        }

        public double GetTravelCosts()
        {
            double totalCosts = 0;
            double cost = 0;

            for (int i = 0; i < Travels.Count; i++)
            {
                cost = Travels[i].CalculateTravelCost();
                totalCosts += cost;
            }

            return totalCosts;
        }

        public double GetCommuteCosts()
        {
            double totalCosts = 0;
            double cost = 0;

            for (int i = 0; i < Commutes.Count; i++)
            {
                cost = Commutes[i].CalculateCommuteCostPerYear();
                totalCosts += cost;
            }

            return totalCosts;
        }

        public (int FirstClass, int SecondClass) GetGAPrices(int age)
        {
            int one, two;

            if (age >= 65)
            {
                one = Prices.gaSeniorKl1;
                two = Prices.gaSeniorKl2;
            }
            else if (age >= 26)
            {
                one = Prices.gaErwachsenKl1;
                two = Prices.gaErwachsenKl2;
            }
            else if (age == 25)
            {
                one = Prices.ga25Kl1;
                two = Prices.ga25Kl2;
            }
            else if (age >= 16)
            {
                one = Prices.gaJugendKl1;
                two = Prices.gaJugendKl2;
            }
            else if (age >= 6)
            {
                one = Prices.gaKindKl1;
                two = Prices.gaKindKl2;
            }
            else 
            {
                one = -1;
                two = -1;
            }

            return (one, two);
        }

        public int GetHalbPrice(int age)
        {
            int halbPrice = 0;

            if (age >= 25)
            {
                if (this.IsHalbtaxNew)
                {
                    halbPrice = Prices.halbErwachsenNeu;
                }
                else
                {
                    halbPrice = Prices.halbErwachsenTreu;
                }
            }
            else if (age >= 16)
            {
                if (this.IsHalbtaxNew)
                {
                    halbPrice = Prices.halbJugendNeu;
                }
                else
                {
                    halbPrice = Prices.halbJugendTreu;
                }
            }
            else
            {
                halbPrice = -1;
            }

            return halbPrice;
        }

        public int[,] GetHalbPlusPrices(int age)
        {
            int[,] halbPlusPrices = new int[3, 2];

            if (age >= 25)
            {
                halbPlusPrices[0, 0] = Prices.halbPlusErwachsen1000[0];
                halbPlusPrices[0, 1] = Prices.halbPlusErwachsen1000[1];
                halbPlusPrices[1, 0] = Prices.halbPlusErwachsen2000[0];
                halbPlusPrices[1, 1] = Prices.halbPlusErwachsen2000[1];
                halbPlusPrices[2, 0] = Prices.halbPlusErwachsen3000[0];
                halbPlusPrices[2, 1] = Prices.halbPlusErwachsen3000[1];
            }
            else if (age >= 6)
            {
                halbPlusPrices[0, 0] = Prices.halbPlusJugend1000[0];
                halbPlusPrices[0, 1] = Prices.halbPlusJugend1000[1];
                halbPlusPrices[1, 0] = Prices.halbPlusJugend2000[0];
                halbPlusPrices[1, 1] = Prices.halbPlusJugend2000[1];
                halbPlusPrices[2, 0] = Prices.halbPlusJugend3000[0];
                halbPlusPrices[2, 1] = Prices.halbPlusJugend3000[1];
            }
            else
            {
                for (int i = 0; i < halbPlusPrices.GetLength(0); i++)
                {
                    for(int j = 0; j < halbPlusPrices.GetLength(1); j++)
                    {
                        halbPlusPrices[i, j] = -1;
                    }
                }
            }

            return halbPlusPrices;
        }

        public double[] CalculateCostsWithHalbPlus(int[,] halbPlusPrices, double costs)
        {
            int halbPlusPricesLength = halbPlusPrices.GetLength(0);
            double[] costsWithHalbPlus = new double[halbPlusPricesLength];

            for (int i = 0; i < halbPlusPrices.GetLength(0); i++)
            {
                if (costs > halbPlusPrices[i, 1])
                {
                    costsWithHalbPlus[i] = costs - halbPlusPrices[i, 1] + halbPlusPrices[i, 0];
                }
                else
                {
                    costsWithHalbPlus[i] = halbPlusPrices[i, 0];
                }
            }

            return costsWithHalbPlus;
        }

        public double CalculateCostsWithHalb(double costs, int halbPrice)
        {
            return (costs / 2) + halbPrice;
        }

        public double[] CalculateCostsWithHalbAndHalbPlus(double costs, int halbPrice, int[,] halbPlusPrices)
        {
            double costsWithHalb = CalculateCostsWithHalb(costs, halbPrice);

            double[] totalCosts = CalculateCostsWithHalbPlus(halbPlusPrices, costsWithHalb);

            return totalCosts;
        }

        public (int Category, double Cost) DetermineCheapestHalbPlus(double[] halbPlusPrices)
        {
            double price = -1;
            int category = -1;

            for (int i = 0; i < halbPlusPrices.Length; i++)
            {
                if (halbPlusPrices[i] < price || price == 0)
                {
                    price = halbPlusPrices[i];

                    category = (i++) * 1000;
                }
            }
            return (category, price);
        }
    }
}
