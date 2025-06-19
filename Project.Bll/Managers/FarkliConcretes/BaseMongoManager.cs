using Project.Bll.Managers.Abstracts;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.FarkliConcretes
{
    public abstract class BaseMongoManager<T> : IManager<T> where T : class, IEntity
    {
        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateRangAsync(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> FirstDatas(int count)
        {
            throw new NotImplementedException();
        }

        public List<T> GetActives()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetPassives()
        {
            throw new NotImplementedException();
        }

        public List<T> GetUpdateds()
        {
            throw new NotImplementedException();
        }

        public Task<string> HardDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> LastDatas(int count)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T newEntity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }
    }
}
