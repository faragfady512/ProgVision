using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgVision.BLL.Interfaces;
using ProgVision.BLL.Specification;
using ProgVision.DAL.Context;
using ProgVision.DAL.Entities;

namespace ProgVision.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
         => await _context.Set<T>()/*.AsNoTracking()*/.ToListAsync();


        public async Task<T> GetByIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);



        public void Add(T entity)
        { 
            _context.Add(entity);
            _context.SaveChanges();
        }


        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }



        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
                 => await ApplySpecifications(spec).ToListAsync();



        public async Task<int> GetCountAsync(ISpecification<T> spec)
          => await ApplySpecifications(spec).CountAsync();

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
             => await ApplySpecifications(spec).FirstOrDefaultAsync();


        private IQueryable<T> ApplySpecifications(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), spec);
        }


    }
}
