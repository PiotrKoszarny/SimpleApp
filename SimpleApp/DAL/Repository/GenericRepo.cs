using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.DAL.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly DbContext _db;

        public GenericRepo(DbContext db)
        {
            _db = db;
        }

        public async Task<T> Add(T t)
        {
            await _db.Set<T>().AddAsync(t);
            await _db.SaveChangesAsync();
            return t;
        }

        public async Task<T> GetItem(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<T> Update(T t)
        {
            _db.Set<T>().Update(t);
            await _db.SaveChangesAsync();
            return t;
        }
    }
}
