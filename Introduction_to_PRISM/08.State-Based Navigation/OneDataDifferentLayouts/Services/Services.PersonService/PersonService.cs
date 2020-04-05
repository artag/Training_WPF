using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Business;
using Demo.Infrastructure.Services;

namespace Services.PersonService
{
    public class PersonService : IPersonService
    {
        private static readonly string Avatar1Uri =
            @"/Services.PersonService;component/Images/MC900432625.PNG";

        private static readonly string Avatar2Uri =
            @"/Services.PersonService;component/Images/MC900433938.PNG";

        public IEnumerable<Person> GetPeople()
        {
            var people = new List<Person>();

            for (int i = 0; i < 50; i++)
            {
                var person = new Person
                {
                    FirstName = $"First{i}",
                    LastName = $"Last{i}",
                    Age = i,
                    Email = GetPersonEmail($"First{i}", $"Last{i}"),
                    ImagePath = GetPersonImagePath(i),
                };
                Task.Delay(1).Wait();

                people.Add(person);
            }

            return people;
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            return await Task.Run(() => GetPeople());
        }

        private string GetPersonEmail(string firstName, string lastName)
        {
            return $"{firstName}.{lastName}@domain.com";
        }

        private string GetPersonImagePath(int index)
        {
            return index % 2 == 0
                ? Avatar1Uri
                : Avatar2Uri;
        }
    }
}
