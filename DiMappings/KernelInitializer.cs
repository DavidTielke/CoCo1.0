using DavidTielke.PersonManagementApp.Data.DataStoring;
using DavidTielke.PersonManagementApp.Data.DataStoring.Contract;
using DavidTielke.PersonManagementApp.Logic.PersonManagement;
using DavidTielke.PersonManagementApp.Logic.PersonManagement.Contract;
using Ninject;

namespace DavidTielke.PersonManagementApp.Mappings.DiMappings
{
    public class KernelInitializer
    {
        public void Initialize(IKernel kernel)
        {
            kernel.Bind<IPersonManager>().To<PersonManager>();
            kernel.Bind<IPersonRepository>().To<PersonRepository>();
        }
    }
}
