using RestWithAsp_Net5Udemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAsp_Net5Udemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FiindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);

            }
            return persons;
        }

        
        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirtName = "Fernando",
                LasName = "Wahl",
                Adress = "Porto União - SC - BR",
                Gender = "Masculino",
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
                FirtName = "Person name" + i,
                LasName = "Person LastName" + i,
                Adress = "Person Adress" + i,
                Gender = "Masculino",
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
