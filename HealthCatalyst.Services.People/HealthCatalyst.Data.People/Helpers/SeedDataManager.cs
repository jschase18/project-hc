using System;
using System.Collections.Generic;
using HealthCatalyst.Data.People.Schema;

namespace HealthCatalyst.Data.People.Helpers
{
    /// <summary>
    /// Manages seed (catalog) data for the database
    /// </summary>
    public class SeedDataManager
    {
        public static void ApplySeedDataToDbContext(PeopleDbContext context)
        {
            SeedContactMethodTypes(context);
            SeedStates(context);
            SeedPeopleData(context);
        }

        private static void SeedPeopleData(PeopleDbContext context)
        {
            IList<Person> people = new List<Person>();

            people.Add(GeneratePerson("John", "Smith", 30, 1234));
            people.Add(GeneratePerson("Susan", "Thompson", 42, 2345));
            people.Add(GeneratePerson("Adam", "Anderson", 27, 3456));
            people.Add(GeneratePerson("Carl", "Roberts", 21, 4567));
            people.Add(GeneratePerson("Michelle", "Holms", 35, 5678));

            foreach (Person person in people)
                context.People.Add(person);
        }

        private static void SeedContactMethodTypes(PeopleDbContext context)
        {
            IList<ContactMethodType> contactMethodTypes = new List<ContactMethodType>();

            contactMethodTypes.Add(new ContactMethodType { ContactMethodTypeId = 1, Name = "Phone" });
            contactMethodTypes.Add(new ContactMethodType { ContactMethodTypeId = 2, Name = "Email" });

            foreach (ContactMethodType contactMethodType in contactMethodTypes)
                context.ContactMethodTypes.Add(contactMethodType);
        }

        private static void SeedStates(PeopleDbContext context)
        {
            IList<State> states = new List<State>();

            states.Add(new State { StateId = 1, Name = "Alabama" });
            states.Add(new State { StateId = 2, Name = "Alaska" });
            states.Add(new State { StateId = 3, Name = "Arizona" });
            states.Add(new State { StateId = 4, Name = "Arkansas" });
            states.Add(new State { StateId = 5, Name = "California" });
            states.Add(new State { StateId = 6, Name = "Colorado" });
            states.Add(new State { StateId = 7, Name = "Connecticut" });
            states.Add(new State { StateId = 8, Name = "Delaware" });
            states.Add(new State { StateId = 9, Name = "Florida" });
            states.Add(new State { StateId = 10, Name = "Georgia" });
            states.Add(new State { StateId = 11, Name = "Hawaii" });
            states.Add(new State { StateId = 12, Name = "Idaho" });
            states.Add(new State { StateId = 13, Name = "Illinois" });
            states.Add(new State { StateId = 14, Name = "Indiana" });
            states.Add(new State { StateId = 15, Name = "Iowa" });
            states.Add(new State { StateId = 16, Name = "Kansas" });
            states.Add(new State { StateId = 17, Name = "Kentucky" });
            states.Add(new State { StateId = 18, Name = "Louisiana" });
            states.Add(new State { StateId = 19, Name = "Maine" });
            states.Add(new State { StateId = 20, Name = "Maryland" });
            states.Add(new State { StateId = 21, Name = "Massachusetts" });
            states.Add(new State { StateId = 22, Name = "Michigan" });
            states.Add(new State { StateId = 23, Name = "Minnesota" });
            states.Add(new State { StateId = 24, Name = "Mississippi" });
            states.Add(new State { StateId = 25, Name = "Missouri" });
            states.Add(new State { StateId = 26, Name = "Montana" });
            states.Add(new State { StateId = 27, Name = "Nebraska" });
            states.Add(new State { StateId = 28, Name = "Nevada" });
            states.Add(new State { StateId = 29, Name = "New Hampshire" });
            states.Add(new State { StateId = 30, Name = "New Jersey" });
            states.Add(new State { StateId = 31, Name = "New Mexico" });
            states.Add(new State { StateId = 32, Name = "New York" });
            states.Add(new State { StateId = 33, Name = "North Carolina" });
            states.Add(new State { StateId = 34, Name = "North Dakota" });
            states.Add(new State { StateId = 35, Name = "Ohio" });
            states.Add(new State { StateId = 36, Name = "Oklahoma" });
            states.Add(new State { StateId = 37, Name = "Oregon" });
            states.Add(new State { StateId = 38, Name = "Pennsylvania" });
            states.Add(new State { StateId = 39, Name = "Rhode Island" });
            states.Add(new State { StateId = 40, Name = "South Carolina" });
            states.Add(new State { StateId = 41, Name = "South Dakota" });
            states.Add(new State { StateId = 42, Name = "Tennessee" });
            states.Add(new State { StateId = 43, Name = "Texas" });
            states.Add(new State { StateId = 44, Name = "Utah" });
            states.Add(new State { StateId = 45, Name = "Vermont" });
            states.Add(new State { StateId = 46, Name = "Virginia" });
            states.Add(new State { StateId = 47, Name = "Washington" });
            states.Add(new State { StateId = 48, Name = "West Virginia" });
            states.Add(new State { StateId = 49, Name = "Wisconsin" });
            states.Add(new State { StateId = 50, Name = "Wyoming" });

            foreach (State state in states)
                context.States.Add(state);
        }

        private static Person GeneratePerson(string firstName, string lastName, int age, int random)
        {
            var person = new Person
            {
                Addresses = new List<Address>(),
                Age = age,
                ContactMethods = new List<ContactMethod>(),
                Created = DateTimeOffset.UtcNow,
                FirstName = firstName,
                Interests = new List<Interest>(),
                LastName = lastName,
                ProfilePictureUrl = "app/images/default-profile.png",
                Updated = DateTimeOffset.UtcNow
            };

            person.Addresses.Add(new Address
            {
                Address1 = random + " " + lastName + " Street",
                Address2 = "Suite " + random,
                City = "Test Ville",
                Created = DateTimeOffset.UtcNow,
                Person = person,
                PostalCode = "88888",
                StateId = 25,
                Updated = DateTimeOffset.UtcNow
            });

            person.ContactMethods.Add(new ContactMethod
            {
                ContactMethodTypeId = 1,
                Created = DateTimeOffset.UtcNow,
                Person = person,
                Updated = DateTimeOffset.UtcNow,
                Value = "801-555-" + random
            });

            person.ContactMethods.Add(new ContactMethod
            {
                ContactMethodTypeId = 2,
                Created = DateTimeOffset.UtcNow,
                Person = person,
                Updated = DateTimeOffset.UtcNow,
                Value = firstName + "." + lastName + "@testing.com"
            });

            person.Interests.Add(new Interest
            {
                Created = DateTimeOffset.UtcNow,
                Description = "Programming " + random,
                Person = person,
                Updated = DateTimeOffset.UtcNow
            });

            return person;
        }
    }
}
