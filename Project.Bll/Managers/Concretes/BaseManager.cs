using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    public abstract class BaseManager<T> : IManager<T> where T : class, IEntity
    {
        readonly IRepository<T> _repository;

        protected BaseManager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.Status = DataStatus.Inserted;
            await _repository.CreateAsync(entity);
        }

        public async Task CreateRangAsync(List<T> entities)
        {
            foreach(T entity in entities) await CreateAsync(entity);
        }

        public async Task<List<T>> FirstDatas(int count)
        {
            List<T> values = await _repository.GetAllAsync();
            return values.OrderBy(x=>x.CreatedDate).Take(count).ToList();
        }

        public List<T> GetActives()
        {
            return _repository.Where(x=>x.Status != DataStatus.Deleted).ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public List<T> GetPassives()
        {
            return _repository.Where(x => x.Status == DataStatus.Deleted).ToList();

        }

        public List<T> GetUpdateds()
        {
            return _repository.Where(x => x.Status == DataStatus.Updated).ToList();
        }

        public async Task<string> HardDeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            if (entity.Status == DataStatus.Deleted)
            {
                await _repository.DeleteAsync(entity);
                return $"Silme basarilidir... Silinen id : {entity.Id}";
            }
            return "Sadece pasif verileri silebilirsiniz.";
        }

        public async Task<List<T>> LastDatas(int count)
        {
            List<T> values = await _repository.GetAllAsync();
            return values.OrderByDescending(x=>x.CreatedDate).Take(count).ToList();
        }

        public async Task SoftDeleteAsync(int id)
        {
            T entity  = await GetByIdAsync(id);
            entity.DeletedDate = DateTime.Now;
            entity.Status = DataStatus.Deleted;
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync( T newEntity)
        {
            T originalEntity = await GetByIdAsync(newEntity.Id);
            originalEntity.Status = DataStatus.Updated;
            originalEntity.ModifiedDate = DateTime.Now;
            await _repository.UpdateAsync(originalEntity, newEntity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _repository.Where(exp);
        }
    }
}
