using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ga_rechner
{
    /// <summary>
    /// Represents a person with various attributes and methods to manage their travel and commute data.
    /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="personName">The name of the person.</param>
        /// <param name="personBirthday">The birthday of the person.</param>
        /// <param name="personStreet">(optional)The street address of the person.</param>
        /// <param name="personCity">(optional) The city the person lives in.</param>
        /// <param name="personHasHalbtax">Indicates if the person already has a half-fare card.</param>
        public Person(string personName, DateTime personBirthday, string personStreet = "strasse", string personCity = "stadt", bool personHasHalbtax = false)
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="personName">The name of the person.</param>
        /// <param name="personBirthday">The birthday of the person.</param>
        /// <param name="personTravel">The information for a specific travel route of the person.</param>
        /// <param name="personStreet">(optional) The street address of the person.</param>
        /// <param name="personCity">(optional) The city the person lives in.</param>
        /// <param name="personHasHalbtax">Indicates if the person already has a half-fare card.</param>
        public Person(string personName, DateTime personBirthday, Travel personTravel, string personStreet = "strasse", string personCity = "stadt", bool personHasHalbtax = false)
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="personName">The name of the person.</param>
        /// <param name="personBirthday">The birthday of the person.</param>
        /// <param name="personCommute">The information for a specific commute route of the person.</param>
        /// <param name="personStreet">(optional) The street address of the person.</param>
        /// <param name="personCity">(optional) The city the person lives in.</param>
        /// <param name="personHasHalbtax">Indicates if the person already has a half-fare card.</param>
        public Person(string personName, DateTime personBirthday, Commute personCommute, string personStreet = "strasse", string personCity = "stadt", bool personHasHalbtax = false)
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="personName">The name of the person.</param>
        /// <param name="personBirthday">The birthday of the person.</param>
        /// <param name="personTravel">The information for a specific travel route of the person.</param>
        /// <param name="personCommute">The information for a specific commute route of the person.</param>
        /// <param name="personStreet">(optional) The street address of the person.</param>
        /// <param name="personCity">(optional) The city the person lives in.</param>
        /// <param name="personHasHalbtax">Indicates if the person already has a half-fare card.</param>
        public Person(string personName, DateTime personBirthday, Travel personTravel, Commute personCommute, string personStreet = "strasse", string personCity = "stadt", bool personHasHalbtax = false)
        {
            this.Name = personName;
            this.Birthday = personBirthday;
            this.Age = GetAge();
            this.Street = personStreet;
            this.City = personCity;
            this.Travels = new List<Travel> { personTravel };
            this.Commutes = new List<Commute> { personCommute };
            this.HasHalbtax = personHasHalbtax && CanHaveHalbTax() ? true : false;
            this.Costs = CalculateCosts();
        }

        /// <summary>
        /// Adds a new <see cref="Travel"/> to the person's list of travels and updates the total costs.
        /// </summary>
        /// <param name="newTravel">The travel to be added.</param>
        public void AddTravel(Travel newTravel)
        {
            this.Travels.Add(newTravel);
            this.Costs = CalculateCosts();
        }

        /// <summary>
        /// Adds a new <see cref="Commute"/> to the person's list of commutes and updates the total costs.
        /// </summary>
        /// <param name="newCommute">The commute to be added.</param>
        public void AddCommute(Commute newCommute)
        {
            this.Commutes.Add(newCommute);
            this.Costs = CalculateCosts();
        }

        /// <summary>
        /// Empties the person's list of travels and updates the total costs.
        /// </summary>
        public void EmptyTravels()
        {
            this.Travels.Clear();
            this.Costs = CalculateCosts();
        }

        /// <summary>
        /// Empties the person's list of commutes and updates the total costs.
        /// </summary>
        public void EmptyCommutes()
        {
            this.Commutes.Clear();
            this.Costs = CalculateCosts();
        }

        /// <summary>
        /// Empties the person's list of travels and commutes and updates the total costs.
        /// </summary>
        public void EmptyTravelsAndCommutes() 
        {
            EmptyTravels();
            EmptyCommutes();
        }

        /// <summary>
        /// Prints the list of different ways to pay for the person's travels and commutes and the respective costs. It also prints their age and whether they have a half-fare card.
        /// </summary>
        public void PrintListOfTickets()
        {
            if (!NeedsTickets())
            {
                Console.WriteLine(this.Name + " ist " + this.Age + " Jahre alt und somit jünger als 6 Jahre und fährt kostenlos.");
                return;
            }

            List<(string Name, double Cost)> listOfTickets = GetListOfTickets();

            Console.WriteLine("Kosten für " + this.Name + ":");
            Console.WriteLine("(Alter: " + this.Age + ", hat Halbtax: " + this.HasHalbtax + ")\n");
            for (int i = 0; i < listOfTickets.Count; i++)
            {
                Console.WriteLine(listOfTickets[i].Name + ": " + listOfTickets[i].Cost);
            }
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Gets a list of different ways to pay for the person's travels and commutes and the respective costs.
        /// </summary>
        /// <returns>A list of tuples containing the name and cost of each ticket option. Sorted by cost, cheapest to most expensive.</returns>
        private List<(string Name, double Cost)> GetListOfTickets()
        {
            if (!NeedsTickets())
            {
                return new List<(string Name, double Cost)>
                {
                    (this.Name + " ist " + this.Age + " Jahre alt und somit jünger als 6 Jahre und fährt kostenlos: ", 0)
                };
            }

            List<(string Name, double Cost)> listOfCosts = GetUnorderedListOfTickets();

            listOfCosts.RemoveAll(c => c.Cost == -1);

            List<(string Name, double Cost)> sortedCosts = listOfCosts.OrderBy(t => t.Cost).ToList();

            return sortedCosts;
        }

        /// <summary>
        /// Gets an unordered list of ticket options and their costs.
        /// </summary>
        /// <returns>An unordered list of tuples containing the name and cost of each ticket option.</returns>
        private List<(string Name, double Cost)> GetUnorderedListOfTickets()
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
                ("Kosten mit GA (1.Klasse)", gaCostsFirstClass),
                ("Kosten mit GA (2.Klasse)", gaCostsSecondClass),
                ("Kosten mit Halbtax", costsWithHalb),
                ("Kosten mit " + cheapestHalbPlus.Category, cheapestHalbPlus.Cost),
                ("Kosten mit " + cheapestHalbPlusWithHalb.Category + " plus Halbtax", cheapestHalbPlusWithHalb.Cost)
            };

            return costsList;
        }

        /// <summary>
        /// Gets the age of the person based on their birthday.
        /// </summary>
        /// <returns>The age of the person in years.</returns>
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

        /// <summary>
        /// Calculates the total costs for the person's travels and commutes.
        /// </summary>
        /// <returns>The total costs as a double.</returns>
        private double CalculateCosts()
        {
            if (!NeedsTickets())
            {
                return 0;
            }

            double travelCosts = GetTravelCosts();
            double commuteCosts = GetCommuteCosts();
            double totalCosts = travelCosts + commuteCosts;

            if (this.Age < 16 && this.Age >= 6)
            {
                totalCosts = CostsRemoveHalfOfCosts(totalCosts);
            }

            return totalCosts;
        }

        /// <summary>
        /// Gets the travel costs for the person's travels.
        /// </summary>
        /// <returns>The total travel costs as a double.</returns>
        private double GetTravelCosts()
        {
            double totalCosts = 0;

            for (int i = 0; i < Travels.Count; i++)
            {
                double cost = Travels[i].CalculateTravelCost();
                totalCosts += cost;
            }

            return totalCosts;
        }

        /// <summary>
        /// Gets the commute costs for the person's commutes.
        /// </summary>
        /// <returns>The total commute costs as a double.</returns>
        private double GetCommuteCosts()
        {
            double totalCosts = 0;

            for (int i = 0; i < Commutes.Count; i++)
            {
                double cost = Commutes[i].CalculateCommuteCostPerYear();
                totalCosts += cost;
            }

            return totalCosts;
        }

        /// <summary>
        /// Gets the prices for the GA (General Abonnement) in both first and second class based on the person's age.
        /// </summary>
        /// <returns>A tuple containing the prices for the first and second class.</returns>
        private (int FirstClass, int SecondClass) GetGAPrices()
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

        /// <summary>
        /// Gets the price for the HalbTax based on the person's age, whether they already have it and whether they can have it.
        /// </summary>
        /// <returns>The price for the HalbTax as an integer.</returns>
        private int GetHalbPrice()
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

        /// <summary>
        /// Gets the prices for each type of HalbtaxPlus based on the person's age and whether they can have it.
        /// </summary>
        /// <returns>A list of tuples containing the name, cost and amount a person can spend for each type of HalbtaxPlus.</returns>
        private List<(string Name, int Cost, int Credit)> GetHalbPlusPrices()
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

        /// <summary>
        /// Removes half of the costs from the given amount. For example to calculate the costs with Halbtax or if the person is a child.
        /// </summary>
        /// <param name="costs">The original costs as a double.</param>
        /// <returns>The costs after removing half as a double.</returns>
        private double CostsRemoveHalfOfCosts(double costs)
        {
            return costs / 2;
        }

        /// <summary>
        /// Calculates the travel and commute costs with Halbtax.
        /// </summary>
        /// <returns>The total costs with Halbtax as a double, including the costs for the Halbtax.</returns>
        private double CalculateCostsWithHalb()
        {
            if (!CanHaveHalbTax())
            {
                return -1;
            }

            double costsAfterHalb = CostsRemoveHalfOfCosts(this.Costs);
            int halbPrice = GetHalbPrice();

            return costsAfterHalb + halbPrice;
        }

        /// <summary>
        /// Calculates the costs with each type of HalbtaxPlus.
        /// </summary>
        /// <param name="costPerYear">The original travel costs per year as a double.</param>
        /// <returns>A list of tuples containing the costs for each type of HalbtaxPlus.</returns>
        private List<(string Name, double Cost)> CalculateCostsWithHalbPlus(double costPerYear)
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
                    costsWithHalbPlus.Add((halbPlusPrices[i].Name, tempCost));
                }
                else
                {
                    costsWithHalbPlus.Add((halbPlusPrices[i].Name, halbPlusPrices[i].Cost));
                }
            }

            return costsWithHalbPlus;
        }

        /// <summary>
        /// Calculates the costs with Halbtax and each type of HalbtaxPlus.
        /// </summary>
        /// <returns>A list of tuples containing the costs with Halbtax and each type of HalbtaxPlus.</returns>
        private List<(string Name, double Cost)> CalculateCostsWithHalbAndHalbPlus()
        {
            if (!CanHaveHalbTax())
            {
                return new List<(string Name, double Cost)> { (string.Empty, -1) };
            }

            double costsAfterHalb = CostsRemoveHalfOfCosts(this.Costs);

            List<(string Name, double Cost)> totalCosts = CalculateCostsWithHalbPlus(costsAfterHalb);

            int halbPrice = GetHalbPrice();

            for (int i = 0; i < totalCosts.Count; i++)
            {
                var modifiedItem = totalCosts[i];
                modifiedItem.Cost += halbPrice;
                totalCosts[i] = modifiedItem;
            }

            return totalCosts;
        }

        /// <summary>
        /// Calculates which HalbtaxPlus would be the cheapest for the person, based on their travel needs. (Without Halbtax)
        /// </summary>
        /// <returns>A tuple containing the category and how much it costs with the cheapest HalbtaxPlus. (Without Halbtax)</returns>
        private (string Category, double Cost) CalculateCheapestHalbPlusPrice()
        {
            if (!CanHaveHalbPlusOrGA())
            {
                return (string.Empty, -1);
            }

            List<(string Name, double Cost)> costsWithHalbPlus = CalculateCostsWithHalbPlus(this.Costs);
            var cheapestHalbPlus = DetermineCheapestHalbPlus(costsWithHalbPlus);

            return (cheapestHalbPlus);
        }

        /// <summary>
        /// Calculates the cheapest HalbtaxPlus price with the Halbtax price included.
        /// </summary>
        /// <returns>A tuple containing the category and how much it costs with the cheapest HalbtaxPlus. (with Halbtax)</returns>
        private (string Category, double Cost) CalculateCheapestHalbPlusWithHalbPrice()
        {
            if (!CanHaveHalbTax())
            {
                return (string.Empty, -1);
            }

            List<(string Name, double Cost)> costsWithHalbAndHalbPlus = CalculateCostsWithHalbAndHalbPlus();
            var cheapestHalbPlusWithHalb = DetermineCheapestHalbPlus(costsWithHalbAndHalbPlus);

            return (cheapestHalbPlusWithHalb);
        }

        /// <summary>
        /// Determines the cheapest HalbtaxPlus from a list of prices.
        /// </summary>
        /// <param name="halbPlusPrices">A list of different costs with HalbtaxPlus.</param>
        /// <returns>A tuple containing the category and how much it costs with the cheapest HalbtaxPlus.</returns>
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

        // todo: rename to IsChildOrBaby()
        /// <summary>
        /// Determines if the person is eligible for Halbtax. (16 or older)
        /// </summary>
        private bool CanHaveHalbTax()
        {
            return this.Age >= 16;
        }

        // todo remove after renaming NeedsTickets
        /// <summary>
        /// Determines if the person is eligible for HalbtaxPlus or GA. (6 or older)
        /// </summary>
        private bool CanHaveHalbPlusOrGA()
        {
            return NeedsTickets();
        }

        // todo: rename to IsBaby()
        /// <summary>
        /// Determines if the person is eligible for a ticket. (6 or older)
        /// </summary>
        private bool NeedsTickets()
        {
            return this.Age >= 6;
        }
    }
}
