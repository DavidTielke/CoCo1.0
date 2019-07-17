using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.DataClasses;
using DavidTielke.PersonManagementApp.Data.DataStoring.Contract;
using DavidTielke.PersonManagementApp.Logic.PersonManagement.Contract;
using DavidTielke.PersonManagementApp.Logic.PersonManagement.Contract.DataClasses;
using DavidTielke.PersonManagementApp.Logic.PersonManagement.Contract.Exceptions;

namespace DavidTielke.PersonManagementApp.Logic.PersonManagement
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _repository;

        public PersonManager(IPersonRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Person> GetAllAdults() => _repository.Query.Where(p => p.Age >= 18);

        public IQueryable<Person> GetAllChildren() => _repository.Query.Where(p => p.Age < 18);

        public AgeStatistic GetAgeStatistic() => new AgeStatistic
        {
            AmountAdults = GetAllAdults().Count(),
            AmountChildren = GetAllChildren().Count()
        };

        public void Add(Person person)
        {
            var alreadyAddedPerson = person.Id != 0;
            if (alreadyAddedPerson)
            {
                throw new PersonManagementException("Can't add a already inserted Person with id unequal 0");
            }

            try
            {
                _repository.Insert(person);
            }
            catch (Exception exc) when(!(exc is PersonManagementException))
            {
                throw new PersonManagementException($"Can't add the person {person.Name}", exc);
            }
        }
    }
}
