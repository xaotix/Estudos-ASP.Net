using RestWith_ASP.Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWith_ASP.Net.Services.Implementations
{

    public class PersonServiceImplementation : IPersonService
    {

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
           
        }

        public List<Person> FindAll()
        {
            var persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                var person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Address = "Nova Prata",
                FirstName = "Daniel",
                LastName = "Maciel",
                Gender = "Male",
                id = id
            };
        }
        public Person MockPerson(long id)
        {
            return new Person
            {
                Address = "Nova Prata",
                FirstName = "Daniel",
                LastName = "Maciel",
                Gender = "Male",
                id = id
            };
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
