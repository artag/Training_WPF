using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Business;

namespace Demo.Infrastructure.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetPeople();
        Task<IEnumerable<Person>> GetPeopleAsync();
    }
}
