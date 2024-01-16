using ProgVision.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        // Retrieves an entity by its unique identifier asynchronously
        Task<T> GetByIdAsync(int id);


        // Retrieves all entities of type T asynchronously
        Task<IReadOnlyList<T>> GetAllAsync();


        // Retrieves a single entity based on a specific criteria specified by a specification
        Task<T> GetEntityWithSpec(ISpecification<T> spec);


        // Retrieves a list of entities based on a specific criteria specified by a specification
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);


        // Retrieves the count of entities based on a specific criteria specified by a specification
        Task<int> GetCountAsync(ISpecification<T> spec);


        // Adds a new entity to the repository
        void Add(T entity);

        // Updates an existing entity in the repository
        void Update(T entity);

        // Deletes an entity from the repository
        void Delete(T entity);

    }
}
