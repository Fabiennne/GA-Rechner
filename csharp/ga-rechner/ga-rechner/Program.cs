using System;

namespace ga_rechner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Travel travel = new Travel(EnumSingleRetour.Retour, 36);
            Commute commute = new Commute(5, 2, 7.6);

            Person senior = new Person(personName: "senior dubel", personBirthday: new DateTime(1945, 9, 4), personTravel: travel, personCommute: commute, personHasHalbtax: true);
            Person erwachsen = new Person(personName: "erwachsen dubel", personBirthday: new DateTime(1970, 9, 4), personTravel: travel, personCommute: commute, personHasHalbtax: true);
            Person fuefezwanzgi = new Person(personName: "25 dubel", personBirthday: new DateTime(2000, 4, 9), personTravel: travel, personCommute: commute, personHasHalbtax: true);
            Person jugend = new Person(personName: "jugend dubel", personBirthday: new DateTime(2000, 9, 4), personTravel: travel, personCommute: commute, personHasHalbtax: true);
            Person kind = new Person(personName: "kind dubel", personBirthday: new DateTime(2014, 9, 4), personTravel: travel, personCommute: commute, personHasHalbtax: true);
            Person baby = new Person(personName: "baby dubel", personBirthday: new DateTime(2021, 9, 4), personTravel: travel, personCommute: commute, personHasHalbtax: true);

            //senior.PrintListOfTickets();
            //erwachsen.PrintListOfTickets();
            //fuefezwanzgi.PrintListOfTickets();
            //jugend.PrintListOfTickets();
            //kind.PrintListOfTickets();
            //baby.PrintListOfTickets();
        }
    }
}
