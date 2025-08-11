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
        private List<Travel> TrainTravels { get; set; }
        private List<Commute> Commutes { get; set; }
        
        public Person(string personName, DateTime personBirthday, string personStreet, string personCity)
        {
            this.Name = personName;
            this.Birthday = personBirthday;
            this.Street = personStreet;
            this.City = personCity;
        }

        public void CalculateCosts()
        {
            string category = GetAgeCategory();
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

        private string GetAgeCategory()
        {
            int age = GetAge();
            
            if (age >= 65)
            {
                return "senior";
            }
            else if (age >= 26)
            {
                return "erwachsen";
            }
            else if (age == 25)
            {
                return "25";
            }
            else if (age >= 16)
            {
                return "jugend";
            }
            else if (age >= 6)
            {
                return "kind";
            }
            else if (age >= 0)
            {
                return "baby";
            }
            else
            {
                return "error";
            }
        }
    }
}
