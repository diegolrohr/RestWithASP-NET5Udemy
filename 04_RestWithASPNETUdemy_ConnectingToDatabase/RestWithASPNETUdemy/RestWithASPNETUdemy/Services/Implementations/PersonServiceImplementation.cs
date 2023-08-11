using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        //mockar id como se estivesse indo no banco
        private volatile int count;

        public Person Create(Person person)
        {
            //
            return person;
        }

        public void Delete(long id)
        {
            
        }

        //mock
        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                persons.Add(MockPerson(i));
            }
            return persons;
        }

        //mock
        public Person FindById(long i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = $"{i} Diego",
                LastName = "Rohr",
                Address = "Sarandi - Porto Alege - Rio Grande do Sul",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = $"{i} Diego Person",
                LastName = "Rohr Person",
                Address = "Sarandi - Porto Alege - Rio Grande do Sul",
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
