using HRManagement.Application.Contract.Persistence;
using HRManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Persitence.Repositores
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LeaveManagementContext _context;

        public GenericRepository(LeaveManagementContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T entity)
        {
            await _context.AddAsync<T>(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _context.Remove<T>(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.FindAsync<T>(id); 
        }

        public async Task<bool> IsExist(int id)
        {
            var entity =await GetById(id);
            return  entity != null;
        }

        public async Task Update(T entity)
        {
            _context.Update<T>(entity);
            await _context.SaveChangesAsync();
        }
    }
}
