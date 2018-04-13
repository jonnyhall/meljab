using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using car_dealershipWebAPI.Repos;

namespace car_dealershipWebAPI.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IVehicleRepository>().ImplementedBy<VehicleRepository>().LifestylePerWebRequest());
        }
    }
}