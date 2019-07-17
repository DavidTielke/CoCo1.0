using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.DataClasses;

namespace DavidTielke.PersonManagementApp.Data.DataStoring.Contract
{
    public interface IPersonRepository
    {
        IQueryable<Person> Query { get; }
        void Insert(Person person);
    }
}
