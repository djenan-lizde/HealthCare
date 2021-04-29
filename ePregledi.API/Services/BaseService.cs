using AutoMapper;
using ePregledi.API.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ePregledi.API.Services
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> Get();
        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> predicate);
        T GetTByCondition(Expression<Func<T, bool>> predicate);
        T Insert(T entity);
        T GetById(int id);
        T Update(T entity, int Id);
    }
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _entity;
        private readonly IMapper _mapper;

        public BaseService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _entity = context.Set<T>();
            _mapper = mapper;
        }

        public virtual IEnumerable<T> Get()
        {
            var obj = _entity.AsNoTracking().AsEnumerable();
            if (obj == null)
            {
                throw new ArgumentNullException("Entity");
            }
            return obj;
        }
        public virtual IEnumerable<T> GetByCondition(Expression<Func<T, bool>> predicate)
        {
            var obj = _entity.Where(predicate);
            if (obj == null)
            {
                throw new ArgumentNullException("Entity");
            }
            return obj;
        }
        public virtual T GetById(int id)
        {
            var entity = _entity.Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            return entity;
        }

        public virtual T GetTByCondition(Expression<Func<T, bool>> predicate)
        {
            var obj = _entity.FirstOrDefault(predicate);
            if (obj == null)
            {
                throw new ArgumentNullException("Entity");
            }
            return obj;
        }

        public virtual T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }

            var x = _entity.Add(entity);
            _context.SaveChanges();
            return x.Entity;
        }
        public virtual T Update(T entity, int Id)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }

            var e = _context.Set<T>().Find(Id);
            _context.Set<T>().Attach(e);
            _context.Set<T>().Update(e);
            _mapper.Map(entity, e);

            _context.SaveChanges();

            return _mapper.Map<T>(e);
        }
    }
}
