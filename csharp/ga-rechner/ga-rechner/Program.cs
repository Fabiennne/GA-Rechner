namespace ga_rechner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //foreach (var item in sortedCosts)
            //{
            //    Console.WriteLine($"{item.Name}: {item.Cost}");
            //}
            Person person = new Person(personName: "dubel", personBirthday: new DateTime(2000, 9, 4), personStreet: "stross", personCity: "stadt", true);
            //Travel travel = new Travel(TravelSingleRetour: EnumSingleRetour.Retour, TrainTravel.);

            Console.WriteLine(person.GetOrderedListOfCosts());
        }
    }
}
