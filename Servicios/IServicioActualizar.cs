using System.ServiceModel;

namespace Actualizador
{
    [ServiceContract]
    public interface IServicioActualizar
    {

        [OperationContract]
        bool Actualizar(int offset);

        [OperationContract]
        int CantidadDeProductos();
    }

}
