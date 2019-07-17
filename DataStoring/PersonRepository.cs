using System;
using System.IO;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.DataClasses;
using DavidTielke.PersonManagementApp.Data.DataStoring.Contract;
using DavidTielke.PersonManagementApp.Data.DataStoring.Contract.Exceptions;

namespace DavidTielke.PersonManagementApp.Data.DataStoring
{
    public class PersonRepository : IPersonRepository
    {
        public IQueryable<Person> Query => File
            .ReadAllLines("data.csv")
            .Select(l => l.Split(','))
            .Select(p => new Person
            {
                Id = int.Parse(p[0]),
                Name = p[1],
                Age = int.Parse(p[2])
            }).AsQueryable();

        public void Insert(Person person)
        {
            try
            {
                if (person.Id != 0)
                {
                    throw new EntityAlreadyInStoreException("...");
                }

                var personWithLastId = Query.OrderBy(x => x.Id).LastOrDefault();

                var newPersonId = 7;

                if (personWithLastId != null)
                {
                    newPersonId = personWithLastId.Id + 1;
                }

                person.Id = newPersonId;

                
                File.AppendAllLines("data.csv", new[] { $"{Environment.NewLine}{person.Id},{person.Name},{person.Age}" });

            }
            catch (Exception exc) when(!(exc is DataStoringException))
            {
                throw new EntityAlreadyInStoreException($"Person with Id {person.Id} already in database", exc);
            }
        }
    }
}
