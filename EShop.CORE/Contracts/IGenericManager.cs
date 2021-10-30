using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.CORE.Contracts
    {
    /// <summary>
    /// Interfaz del respositorio de datos
    /// </summary>
    /// <typeparam name="T">Clase en la que se basa el repositorio</typeparam>
    public interface IGenericManager<T>
        where T : class
        {
        /// <summary>
        /// Contexto de datos
        /// </summary>
        IApplicationDbContext Context { get; }
        /// <summary>
        /// Busca un elemento por sus claves
        /// </summary>
        /// <param name="key">Claves del elemento</param>
        /// <returns>Objeto si se encuetra</returns>
        T Find(object[] key);
        /// <summary>
        /// Busca un elemento por su clave de tipo int
        /// </summary>
        /// <param name="key">Clave del elemento</param>
        /// <returns>Objeto si se encuentra</returns>
        T Find(int key);
        /// <summary>
        /// Obtiene todos los elementos de la entidad sin Tracking
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();
        /// <summary>
        /// Devuelve un conjunto de registros filtrado por la expresión indicada en el parámetro
        /// </summary>
        /// <param name="predicate">expresión de filtrado</param>
        /// <returns>Elementos filtrados</returns>
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Añadir un nuevo elemento en la colección
        /// </summary>
        /// <param name="entity">Elemento a añadir</param>
        /// <returns>Elemento añadido</returns>
        T Add(T entity);
        /// <summary>
        /// Elimina un elemento de la colección
        /// </summary>
        /// <param name="entity">Elemento a eliminar</param>
        /// <returns>Elemento eliminado</returns>
        T Remove(T entity);
        /// <summary>
        /// Modifica un elemento de la coleccion
        /// </summary>
        /// <param name="entity">Elemento a modificar</param>
        /// <returns>Elemento modificado</returns>
        T Update(T entity);
        /// <summary>
        /// Guarda cambios
        /// </summary>
        /// <returns>Numero de cambios efectuados</returns>
        int SaveChanges();
        }
    }
