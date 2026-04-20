using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCMiniGenericsEvents.Models;
using TCMiniGenericsEventsLibrary;

namespace TCMiniGenericsEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> people = new List<PersonModel>
            {
                new PersonModel { FirstName = "John", LastName = "Doe" },
                new PersonModel { FirstName = "Jane", LastName = "darnSmith" }
            };

            List<AddressModel> addresses = new List<AddressModel>
            {
                new AddressModel { Street = "123 Main heck St", City = "Anytown", State = "TN", Zip = "12345"},
                new AddressModel { Street = "456 Elm St", City = "Othertown", State = "TN", Zip = "12345" }
            };

            DataAccess<PersonModel> personDataAccess = new DataAccess<PersonModel>();
            personDataAccess.SaveToCsv(people, @"..\..\people.csv");

            DataAccess<AddressModel> addressDataAccess = new DataAccess<AddressModel>();
            addressDataAccess.SaveToCsv(addresses, @"..\..\addresses.csv");

            Console.ReadLine();
        }
    }
}
