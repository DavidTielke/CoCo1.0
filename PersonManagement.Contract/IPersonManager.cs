using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.DataClasses;
using DavidTielke.PersonManagementApp.Logic.PersonManagement.Contract.DataClasses;

namespace DavidTielke.PersonManagementApp.Logic.PersonManagement.Contract
{
    public interface IPersonManager
    {
        IQueryable<Person> GetAllAdults();
        IQueryable<Person> GetAllChildren();
        AgeStatistic GetAgeStatistic();
        void Add(Person person);
    }
}
