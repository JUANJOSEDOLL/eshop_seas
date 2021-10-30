using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EShop.CORE.Contracts;
using EShop.DAL;

namespace EShop.APPLICATION
    {
    /// <summary>
    /// Clase genérica de Manager
    /// </summary>
    public class GenericManager<T> : IGenericManager<T>
        where T : class
        {
        /// <summary>
        /// Contexto de datos del manager
        /// </summary>
        public IApplicationDbContext Context { get; private set; }

        /// <summary>
        /// Constructor del manager
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        public GenericManager(IApplicationDbContext context)
            {
            Context = context;
            }

        /// <summary>
        /// Busca una entidad por su key
        /// </summary>
        public T Find(object[] key)
            {
            return Context.Set<T>().Find(key);
            }
        /// <inheritdoc />

        /// <summary>
        /// Busca una entidad por id
        /// </summary>
        public T Find(int key)
            {
            return Context.Set<T>().Find(new object[] { key });
            }
        /// <summary>
        /// Añade una entidad al contexto de datos
        /// </summary>
        /// <param name="entity">Entidad a añadir</param>
        /// <returns>Entidad añadida</returns>
        public T Add(T entity)
            {
            return Context.Set<T>().Add(entity);
            }

        /// <summary>
        /// Elimina una entidad del contexto de datos
        /// </summary>
        /// <param name="entity">Entidad a eliminar</param>
        /// <returns>Entidad eliminada</returns>
        public T Remove(T entity)
            {
            return Context.Set<T>().Remove(entity);
            }

        /// <summary>
        /// Obtiene una entidad por sus posibles claves
        /// </summary>
        /// <param name="key">Claves del objeto</param>
        /// <returns>Entidad si es encontrada</returns>
        public T GetById(object[] key)
            {
            return Context.Set<T>().Find(key);
            }

        /// <summary>
        /// Obtiene una entidad por su clave int
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Entidad si es encontrada</returns>
        public T GetById(int id)
            {
            return GetById(new object[] { id });
            }

        /// <summary>
        /// Obtiene todas las entidades de un tipo específico
        /// </summary>
        /// <returns>Lista todas las entidades</returns>
        public IQueryable<T> GetAll()
            {
            return Context.Set<T>();
            }

        /// <summary>
        /// Crea un DataTable de cualquier colección
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable CreateDataTable(IEnumerable<T> list)
            {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
                {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
                }

            foreach (T entity in list)
                {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                    {
                    values[i] = properties[i].GetValue(entity);
                    }

                dataTable.Rows.Add(values);
                }

            return dataTable;
            }

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
            {
            throw new NotImplementedException();
            }

        public T Update(T entity)
            {
            throw new NotImplementedException();
            }

        public int SaveChanges()
            {
            throw new NotImplementedException();
            }
        }
    }
