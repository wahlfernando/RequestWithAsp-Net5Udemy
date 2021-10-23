using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithAsp_Net5Udemy.Model;


namespace RestWithAsp_Net5Udemy.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FiindAll();
        Person Update(Person person);
        void Delete(long id);


    }
}
