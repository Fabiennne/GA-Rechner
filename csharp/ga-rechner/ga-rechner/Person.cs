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
        private int Age { get; set; }
        private string Street { get; set; }
        private string City { get; set; }
        private List<Travel> Travels { get; set; }
        private List<Commute> Commutes { get; set; }
        private bool HasHalbtax { get; set; }
        private double Costs { get; set; }
        
        public Person(string personName, DateTime personBirthday, string personStreet, string personCity, bool personHasHalbtax = false)
        {
            this.Name = personName;
            this.Birthday = personBirthday;
            this.Age = GetAge();
            this.Street = personStreet;
            this.City = personCity;
            this.Travels = new List<Travel>();
            this.Commutes = new List<Commute>();
            this.HasHalbtax = personHasHalbtax && CanHaveHalbTax() ? true : false;
            this.Costs = CalculateCosts();
        }

        public Person(string personName, DateTime personBirthday, string personStreet, string personCity, Travel personTravel, bool personHasHalbtax = false)
        {
            this.Name = personName;
            this.Birthday = personBirthday;
            this.Age = GetAge();
            this.Street = personStreet;
            this.City = personCity;
            this.Travels = new List<Travel> { personTravel };
            this.Commutes = new List<Commute>();
            this.HasHalbtax = personHasHalbtax && CanHaveHalbTax() ? true : false;
            this.Costs = CalculateCosts();
        }

        public Person(string personName, DateTime personBirthday, string personStreet, string personCity, Commute personCommute, bool personHasHalbtax = false)
        {
            this.Name = personName;
            this.Birthday = personBirthday;
            this.Age = GetAge();
            this.Street = personStreet;
            this.City = personCity;
            this.Travels = new List<Travel>();
            this.Commutes = new List<Commute> { personCommute };
            this.HasHalbtax = personHasHalbtax && CanHaveHalbTax() ? true : false;
            this.Costs = CalculateCosts();
        }

        public Person(string personName, DateTime personBirthday, string personStreet, string personCity, Travel personTravel, Commute personCommute, bool personHasHalbtax = false)
        {
            this.Name = personName;
            this.Birthday = personBirthday;
            this.Age = GetAge();
            this.Street = personStreet;
            this.City = personCity;
            this.Travels = new List<Travel> { personTravel };
            this.Commutes = new List<Commute> { personCommute };
            this.HasHalbtax = personHasHalbtax && CanHaveHalbTax() ? true : false;
            this.Costs = CalculateCosts(); //TODO: handle case if "travels" and "commutes" lists are both empty
        }

        public string getPersonName()
        {
            return this.Name;
        }

        public void setPersonName(string newName)
        {
            this.Name = newName;
        }

        public void AddTravel(Travel newTravel)
        {
            this.Travels.Add(newTravel);
            this.Costs = CalculateCosts();
        }

        public void AddCommute(Commute newCommute)
        {
            this.Commutes.Add(newCommute);
            this.Costs = CalculateCosts();
        }

        public void EmptyTravels()
        {
            this.Travels.Clear();
            this.Costs = CalculateCosts();
        }

        public void EmptyCommutes()
        {
            this.Commutes.Clear();
            this.Costs = CalculateCosts();
        }

        public List<(string Name, double Cost)> GetOrderedListOfCosts()
        {
            if (!NeedsTickets())
            {
                return new List<(string Name, double Cost)>
                {
                    (this.Name + " fährt kostenlos: ", 0)
                };
            }

            List<(string Name, double Cost)> listOfCosts = GetListOfCosts();

            //remove values with -1
            List<(string Name, double Cost)> cleanedList = RemoveEmptyListItems(listOfCosts);

            //order list
            List<(string Name, double Cost)> sortedCosts = SortList(cleanedList);

            //return ordered list
            return sortedCosts;
        }

        public List<(string Name, double Cost)> GetListOfCosts()
        {
            var gaCosts = GetGAPrices();
            double gaCostsFirstClass = gaCosts.FirstClass;
            double gaCostsSecondClass = gaCosts.SecondClass;

            int halbPrice = GetHalbPrice();
            List<(string Name, int Cost, int Credit)> halbPlusPrices = GetHalbPlusPrices();

            double costsWithHalb = CalculateCostsWithHalb();

            List<(string Name, double Cost)> costsWithHalbPlus = CalculateCostsWithHalbPlus(this.Costs);
            var cheapestHalbPlus = CalculateCheapestHalbPlusPrice();

            List<(string Name, double Cost)> costsWithHalbAndHalbPlus = CalculateCostsWithHalbAndHalbPlus();
            var cheapestHalbPlusWithHalb = CalculateCheapestHalbPlusWithHalbPrice();

            List<(string Name, double Cost)> costsList = new List<(string Name, double Cost)>
            {
                ("Kosten ohne Abo", this.Costs),
                ("GA (1.Klasse)", gaCostsFirstClass),
                ("GA (2.Klasse)", gaCostsSecondClass),
                ("Halbtax", costsWithHalb),
                (cheapestHalbPlus.Category, cheapestHalbPlus.Cost),
                (cheapestHalbPlusWithHalb.Category, cheapestHalbPlusWithHalb.Cost)
            };

            return costsList;
        }

        public List<(string Name, double Cost)> RemoveEmptyListItems(List<(string Name, double Cost)> costList)
        {
            costList.RemoveAll(c => c.Cost == -1);
            
            return costList;
        }

        public List<(string Name, double Cost)> SortList(List<(string Name, double Cost)> unsortedList)
        {
            List<(string Name, double Cost)> sortedList = (List<(string Name, double Cost)>)unsortedList.OrderBy(t => t.Cost);

            return sortedList;
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
            if (!NeedsTickets())
            {
                return 0;
            }

            double travelCosts = GetTravelCosts();
            double commuteCosts = GetCommuteCosts();
            double totalCosts = travelCosts + commuteCosts;

            return totalCosts;
        }

        private double GetTravelCosts()
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

        private double GetCommuteCosts()
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

        public (int FirstClass, int SecondClass) GetGAPrices()
        {
            int one, two;

            if (this.Age >= 65)
            {
                one = Prices.gaSeniorKl1;
                two = Prices.gaSeniorKl2;
            }
            else if (this.Age >= 26)
            {
                one = Prices.gaErwachsenKl1;
                two = Prices.gaErwachsenKl2;
            }
            else if (this.Age == 25)
            {
                one = Prices.ga25Kl1;
                two = Prices.ga25Kl2;
            }
            else if (this.Age >= 16)
            {
                one = Prices.gaJugendKl1;
                two = Prices.gaJugendKl2;
            }
            else if (this.Age >= 6)
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

        public int GetHalbPrice()
        {
            if (!CanHaveHalbTax())
            {
                return -1;
            }

            int halbPrice = 0;

            if (this.Age >= 25)
            {
                if (this.HasHalbtax)
                {
                    halbPrice = Prices.halbErwachsenTreu;
                }
                else
                {
                    halbPrice = Prices.halbErwachsenNeu;
                }
            }
            else if (this.Age >= 16)
            {
                if (this.HasHalbtax)
                {
                    halbPrice = Prices.halbJugendTreu;
                }
                else
                {
                    halbPrice = Prices.halbJugendNeu;
                }
            }

            return halbPrice;
        }

        public List<(string Name, int Cost, int Credit)> GetHalbPlusPrices()
        {
            if (!CanHaveHalbPlusOrGA())
            {
                return new List<(string Name, int Cost, int Credit)> { (string.Empty, -1, -1) };
            }

            List<(string Name, int Cost, int Credit)> halbPlusPrices = new List<(string Name, int Cost, int Credit)> { };

            if (this.Age >= 25)
            {
                halbPlusPrices.Add(Prices.halbPlusErwachsen1000);
                halbPlusPrices.Add(Prices.halbPlusErwachsen2000);
                halbPlusPrices.Add(Prices.halbPlusErwachsen3000);
            }
            else
            {
                halbPlusPrices.Add(Prices.halbPlusJugend1000);
                halbPlusPrices.Add(Prices.halbPlusJugend2000);
                halbPlusPrices.Add(Prices.halbPlusJugend3000);
            }

            return halbPlusPrices;
        }

        public double CalculateCostsWithHalb()
        {
            int halbPrice = GetHalbPrice(); //can be -1

            if (!CanHaveHalbTax())
            {
                return -1;
            }
            return (this.Costs / 2) + halbPrice;
        }

        public List<(string Name, double Cost)> CalculateCostsWithHalbPlus(double costPerYear)
        {
            if (!CanHaveHalbPlusOrGA())
            {
                return new List<(string Name, double Cost)> { (string.Empty, -1) };
            }

            List<(string Name, int Cost, int Credit)> halbPlusPrices = GetHalbPlusPrices();

            List<(string Name, double Cost)> costsWithHalbPlus = new List<(string Name, double Cost)> { };
            double tempCost;

            for (int i = 0; i < halbPlusPrices.Count(); i++)
            {
                if (costPerYear > halbPlusPrices[i].Credit)
                {
                    tempCost = costPerYear - halbPlusPrices[i].Credit + halbPlusPrices[i].Cost;
                    costsWithHalbPlus.Add((costsWithHalbPlus[i].Name, tempCost));
                }
                else
                {
                    costsWithHalbPlus.Add((costsWithHalbPlus[i].Name, halbPlusPrices[i].Cost));
                }
            }

            return costsWithHalbPlus;
        }

        public List<(string Name, double Cost)> CalculateCostsWithHalbAndHalbPlus()
        {
            if (!CanHaveHalbTax())
            {
                return new List<(string Name, double Cost)> { (string.Empty, -1) };
            }

            double costsWithHalb = CalculateCostsWithHalb();

            List<(string Name, double Cost)> totalCosts = CalculateCostsWithHalbPlus(costsWithHalb);

            return totalCosts;
        }

        public (string Category, double Cost) CalculateCheapestHalbPlusPrice()
        {
            if (!CanHaveHalbPlusOrGA())
            {
                return (string.Empty, -1);
            }

            List<(string Name, double Cost)> costsWithHalbPlus = CalculateCostsWithHalbPlus(this.Costs);
            var cheapestHalbPlus = DetermineCheapestHalbPlus(costsWithHalbPlus);

            return (cheapestHalbPlus);
        }

        public (string Category, double Cost) CalculateCheapestHalbPlusWithHalbPrice()
        {
            if (!CanHaveHalbTax())
            {
                return (string.Empty, -1);
            }

            List<(string Name, double Cost)> costsWithHalbAndHalbPlus = CalculateCostsWithHalbAndHalbPlus();
            var cheapestHalbPlusWithHalb = DetermineCheapestHalbPlus(costsWithHalbAndHalbPlus);

            return (cheapestHalbPlusWithHalb);
        }

        private (string Category, double Cost) DetermineCheapestHalbPlus(List<(string Name, double Cost)> halbPlusPrices)
        {
            if (!CanHaveHalbPlusOrGA())
            {
                return (string.Empty, -1);
            }

            string category = string.Empty;
            double price = 0;

            for (int i = 0; i < halbPlusPrices.Count(); i++)
            {
                if (halbPlusPrices[i].Cost < price || price == 0)
                {
                    category = halbPlusPrices[i].Name;
                    price = halbPlusPrices[i].Cost;
                }
            }
            return (category, price);
        }

        public bool CanHaveHalbTax()
        {
            if (this.Age < 16)
            {
                return false;
            }
            return true;
        }

        public bool CanHaveHalbPlusOrGA()
        {
            return NeedsTickets();
        }

        public bool NeedsTickets()
        {
            if (this.Age < 6)
            {
                return false;
            }
            return true;
        }
    }
}
