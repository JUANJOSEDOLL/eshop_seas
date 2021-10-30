using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.CORE.Contracts
    {
    /// <summary>
    /// Interfaz del contexto
    /// </summary>
    public interface IApplicationDbContext
        {
        /// <summary>
        /// Obtiene la colección de una entidad
        /// </summary>
        /// <typeparam name="T">Entidad de la que queremos el contexto</typeparam>
        /// <returns>Colección de la entidad</returns>
        DbSet<T> Set<T>() where T : class;
        /// <summary>
        /// Obtiene una entrada de una entidad del contexto
        /// </summary>
        /// <typeparam name="T">Tipo de entidad de la que queremos la entrada</typeparam>
        /// <param name="entity">Entidad de la que queremos su entrada</param>
        /// <returns>Entada de la entidad</returns>
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        /// <summary>
        /// Guarda cambios en el contexto
        /// </summary>
        /// <returns>Número de elementos guardados</returns>
        int SaveChanges();
        }
    }
