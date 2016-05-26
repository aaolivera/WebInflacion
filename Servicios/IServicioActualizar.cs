using System.ServiceModel;

namespace Actualizador
{
    [ServiceContract]
    public interface IServicioActualizar
    {

        [OperationContract]
        int Actualizar();

    }

}
