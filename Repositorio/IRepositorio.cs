using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repositorio
{
    /// <summary>
    /// Representa el comportamiento de un repositorio
    /// </summary>
    public interface IRepositorio
    {
  
        TEntidad Obtener<TEntidad>(object id) where TEntidad : class;

        TEntidad ObtenerUnchanged<TEntidad>(object id) where TEntidad : class;


        TEntidad Obtener<TEntidad>(Expression<Func<TEntidad, bool>> condicion) where TEntidad : class;

        TEntidad Obtener<TEntidad>(IEnumerable<Expression<Func<TEntidad, object>>> includes, Expression<Func<TEntidad, bool>> condicion) where TEntidad : class;

        TEntidad ObtenerPrimero<TEntidad>(Expression<Func<TEntidad, bool>> condicion) where TEntidad : class;

        TEntidad ObtenerMasReciente<TEntidad>(Expression<Func<TEntidad, bool>> filtro,
                                              Expression<Func<TEntidad, DateTime>> columnaFecha) where TEntidad : class;

        TProyeccion ObtenerProyeccion<TEntidad, TProyeccion>(Expression<Func<TEntidad, bool>> filtro, Expression<Func<TEntidad, TProyeccion>> proyeccion)
            where TEntidad : class;

        TProyeccion ObtenerMayor<TEntidad, TOrden, TProyeccion>(Expression<Func<TEntidad, bool>> filtro, Expression<Func<TEntidad, TOrden>> columnaOrden, Expression<Func<TEntidad, TProyeccion>> proyeccion)
            where TEntidad : class where TOrden : IComparable;

        TEntidad ObtenerMenor<TEntidad, TOrden>(Expression<Func<TEntidad, bool>> filtro, Expression<Func<TEntidad, TOrden>> columnaOrden)
            where TEntidad : class
            where TOrden : IComparable;

        TEntidad ObtenerMayor<TEntidad, TOrden>(Expression<Func<TEntidad, bool>> filtro, Expression<Func<TEntidad, TOrden>> columnaOrden)
            where TEntidad : class
            where TOrden : IComparable;

        TProyeccion ObtenerMenor<TEntidad, TOrden, TProyeccion>(Expression<Func<TEntidad, bool>> filtro, Expression<Func<TEntidad, TOrden>> columnaOrden, Expression<Func<TEntidad, TProyeccion>> proyeccion)
            where TEntidad : class
            where TOrden : IComparable;


        IList<TEntidad> Listar<TEntidad>(Expression<Func<TEntidad, Boolean>> condicion = null) where TEntidad : class;
        IList<TEntidad> Listar<TEntidad>(IEnumerable<Expression<Func<TEntidad, object>>> includes, Expression<Func<TEntidad, Boolean>> condicion = null) where TEntidad : class;
        IList<TProyeccion> Listar<TEntidad, TProyeccion>(Expression<Func<TEntidad, TProyeccion>> proyeccion, Expression<Func<TEntidad, Boolean>> condicion = null) where TEntidad : class;
        IList<TEntidad> Listar<TEntidad>(Expression<Func<TEntidad, Boolean>> condicion, int maxResultados) where TEntidad : class;
        
        List<TProyeccion> Listar<TEntidad, TProyeccion>(Expression<Func<TEntidad, TProyeccion>> proyeccion, Expression<Func<TEntidad, Boolean>> condicion, int maxResultados) where TEntidad : class;

        IList<TEntidad> ListarVista<TEntidad>();
        int Contar<TEntidad>() where TEntidad : class;
        
        int Contar<TEntidad>(Expression<Func<TEntidad, Boolean>> condicion) where TEntidad : class;
        
        bool Existe<TEntidad>(Expression<Func<TEntidad, Boolean>> condicion) where TEntidad : class;
        
        TEntidad Agregar<TEntidad>(TEntidad entidad) where TEntidad : class;
        TEntidad Remover<TEntidad>(TEntidad entidad) where TEntidad : class;
        
        TEntidad Remover<TEntidad>(object id) where TEntidad : class;
        int GuardarCambios();

    }
}
