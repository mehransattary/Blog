using Common;
using Data.Context;
using Entities;
using IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly AppDbContext DbContext;
        public DbSet<TEntity> Entities { get; }
        public virtual IQueryable<TEntity> Table => Entities;
        //ردیاب رو خاموش میکنیم وسرعت اجرا ها الا میره
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public Repository(AppDbContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>(); // City => Cities
        }

        #region Async Method
        public virtual async Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
        {
            return await Entities.FindAsync(ids, cancellationToken);
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            await Entities.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {

            Entities.Update(entity);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            Entities.UpdateRange(entities);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {

            Entities.Remove(entity);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken);
        }
        public virtual async Task DeleteBehaviorRestrictAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {

             Entities.Update(entity);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken);
        }
        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            Entities.RemoveRange(entities);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken);
        }
       
        #endregion

        #region Sync Methods
        public virtual TEntity GetById(params object[] ids)
        {
            return Entities.Find(ids);
        }

        public virtual void Add(TEntity entity, bool saveNow = true)
        {

            Entities.Add(entity);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Entities.AddRange(entities);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity, bool saveNow = true)
        {

            Entities.Update(entity);
            DbContext.SaveChanges();
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Entities.UpdateRange(entities);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity, bool saveNow = true)
        {

            Entities.Remove(entity);
            if (saveNow)
                DbContext.SaveChanges();
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true)
        {
            Entities.RemoveRange(entities);
            if (saveNow)
                DbContext.SaveChanges();
        }


        public string AddImage(string imageName, string pathnameFolder, IFormFile file, CancellationToken cancellationToken, int? with = 0, int? height = 0)
        {
            string filePath = "";
            if (file.Length > 0)
            {
                filePath = MyImages.FilePath(imageName, pathnameFolder, file);
            }
            return filePath;
        }
        public string AddVideo(string videoName, string pathnameFolder, IFormFile file, CancellationToken cancellationToken, int? with = 0, int? height = 0)
        {
            string filePath = "";
            if (file.Length > 0)
            {
                filePath = MyVideos.FilePath(videoName, pathnameFolder, file, with.Value, height.Value);
            }
            return filePath;
        }
        public string AddFile(string Name, string pathnameFolder, IFormFile file, CancellationToken cancellationToken, int? with = 0, int? height = 0)
        {
            string filePath = "";
            if (file.Length > 0)
            {
                filePath = MyFiles.FilePath(Name, pathnameFolder, file, with.Value, height.Value);
            }
            return filePath;
        }
        #endregion

  
    }
}
