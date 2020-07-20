using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineExam.Context;
using OnlineExam.Interfaces;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OnlineExam.Services
{
    public class RepositoryService<TEntity> : IRepositoryService<TEntity> where TEntity : class
    {
        private DatabaseContext _context;
        private DbSet<TEntity> _dbSet;

        public RepositoryService(DatabaseContext context)
        {
            if (context != null)
            {
                _context = context;
                _dbSet = _context.Set<TEntity>();
            }
        }

        public int Commit()
        {
            var commitVal = 0;

            try
            {
                commitVal = _context.SaveChanges();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return commitVal;
        }

        public async Task<int> CommitAsync()
        {
            var commitVal = 0;

            try
            {
                commitVal = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return commitVal;
        }

        public TEntity Delete(TEntity entityToDelete)
        {
            try
            {
                if (Get().FirstOrDefault() != null)
                {
                    if (_context.Entry(entityToDelete).State == EntityState.Detached)
                    {
                        _dbSet.Attach(entityToDelete);
                    }
                    _dbSet.Remove(entityToDelete);
                    return entityToDelete;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public TEntity Delete(object id)
        {
            try
            {
                TEntity entityToDelete = _dbSet.Find(id);
                Delete(entityToDelete);

                return entityToDelete;
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public ICollection<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "", bool noTracking = false)
        {
            IQueryable<TEntity> query = _dbSet;

            try
            {
                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (noTracking)
                {
                    query = query.AsNoTracking();
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "", bool noTracking = false)
        {
            IQueryable<TEntity> query = _dbSet;

            try
            {
                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (noTracking)
                {
                    query = query.AsNoTracking();
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public TEntity GetById(object id)
        {
            TEntity entity = null;

            try
            {
                entity = _dbSet.Find(id);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return entity;
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {

            TEntity entity = null;

            try
            {
                entity = await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return entity;
        }

        public TEntity Insert(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public ICollection<TEntity> Insert(ICollection<TEntity> entities)
        {
            try
            {
                _dbSet.AddRange(entities);
                return entities;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task<ICollection<TEntity>> InsertAsync(ICollection<TEntity> entities)
        {
            try
            {
                await _dbSet.AddRangeAsync(entities);
                return entities;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                return entity;
            }
            catch (InvalidOperationException ex)
            {
                // Tracking is happening when I use '.Inlcude()' and I have no idea how to overcome this, so just skip it for now
                // I tried AsNoTracking but still ... no success

                // Now it's working wtf?
                // Still not removing it
                // I dont' need sleep I need answers ... 1:12AM

                // It occurred again
                // Added context to the application class... not happening anymore
                Console.WriteLine(ex.Message);
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public ICollection<TEntity> Update(ICollection<TEntity> entities)
        {
            try
            {
                _dbSet.UpdateRange(entities);
                return entities;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
