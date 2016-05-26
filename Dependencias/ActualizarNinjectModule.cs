using Actualizador;
using Ninject.Modules;
using Repositorio;
using System.Data.Entity;
using System.ServiceModel;

namespace Dependencias
{
    public class ActualizarNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<InflacionDbContext>().InScope(ctx => OperationContext.Current);
            Bind<IRepositorio>().To<RepositorioEF>().InScope(ctx => OperationContext.Current);
            Bind<IServicioActualizar>().To<ServicioActualizar>().InSingletonScope();
        }
    }
}
