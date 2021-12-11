using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using News.BLL.Intefaces;
using News.DAL.Classes.BaseClasses;
using News.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace News.BLL.Business
{
    public class BaseAppRepository : IBaseAppRepository
    {
        private IHttpContextAccessor contextAccessor;
        private NewsDataContext context;

        public BaseAppRepository(IHttpContextAccessor httpContextAccessor, NewsDataContext _context)
        {
            contextAccessor = httpContextAccessor;
            context = _context;
        }
        public async Task<T> Add<T>(T _object) where T : BaseObject
        {
            try
            {
                context.Set<T>().Add(_object);
                return _object;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ICollection<T>> AddRange<T>(ICollection<T> _objectList) where T : BaseObject
        {
            //foreach (var item in _objectList)
            //{
            //    item.CreatedOn = DateTime.Now;
            //    item.LastModifiedOn = DateTime.Now;
            //    item.ObjectStatus = ObjectStatus.NonDeleted;
            //    item.Status = Status.Active;
            //    item.CreatedBy = session.ID;
            //    item.LastModifiedBy = session.ID;
            //}

            await context.AddRangeAsync(_objectList);
            return _objectList;
        }
        public bool Any<T>(Expression<Func<T, bool>> where) where T : BaseObject
        {
            try
            {
                return context.Set<T>().Any(where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AnyNonDeletedAndActive<T>(Expression<Func<T, bool>> where) where T : BaseObject
        {
            throw new NotImplementedException();
        }
        public async Task<string> ClearTurkishCharacter(string _dirtyText)
        {
            var unaccentedText = String.Join("", _dirtyText.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark));
            return unaccentedText.Replace("ı", "i");

        }
        public int Count<T>(Expression<Func<T, bool>> expression) where T : BaseObject
        {
            try
            {
                return context.Set<T>().Count(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Task<int> Delete<T>(int ID) where T : BaseObject
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteRange<T>(IQueryable<T> _objectList) where T : BaseObject
        {
            throw new NotImplementedException();
        }
        public async Task<T> Find<T>(Expression<Func<T, bool>> where) where T : BaseObject
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(where);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<T> FindNonDeletedAndActive<T>(Expression<Func<T, bool>> where) where T : BaseObject
        {
            throw new NotImplementedException();
        }
        public string FirstCharToUpper(string input)
        {
            string[] words = input.Trim().Split(null);
            var newString = "";
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == string.Empty || words[i] == null)
                    continue;

                if (i > 0)
                    newString += " ";

                words[i] = words[i].First().ToString().ToUpper() + words[i].ToLower().Substring(1);

                newString += words[i];
            }

            return newString;

        }
        public async Task<List<T>> GetAll<T>() where T : BaseObject
        {
            try
            {
                return await context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<T> GetByID<T>(int ID) where T : BaseObject
        {
            try
            {
                return await Find<T>(t => t.id == ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<IQueryable<T>> GetNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseObject
        {
            throw new NotImplementedException();
        }
        public async Task<IQueryable<T>> GetNonDeletedAndPaginate<T>(int pageID, int PageSize) where T : BaseObject
        {
            try
            {
                //pageID--;
                //return context.Set<T>().Where(t => t.ObjectStatus == ObjectStatus.NonDeleted && t.Status == Status.Active).Skip(pageID * PageSize).Take(PageSize);

                pageID--;
                return context.Set<T>().Skip(pageID * PageSize).Take(PageSize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IQueryable<T>> GetQueryable<T>(Expression<Func<T, bool>> where) where T : BaseObject
        {
            try
            {
                return context.Set<T>().Where(where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> Remove<T>(int id) where T : BaseObject
        {
            try
            {
                var model = await GetByID<T>(id);
                context.Remove(model);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<T> Remove<T>(Expression<Func<T, bool>> expression) where T : BaseObject
        {
            try
            {
                var model = await Find<T>(expression);
                context.Remove(model);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async void RemoveRange<T>([NotNull] params object[] entities)
        {
            try
            {
                context.RemoveRange(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async void RemoveRange<T>([NotNull] IEnumerable<object> entities)
        {
            try
            {
                context.RemoveRange(entities);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> SaveChange()
        {
            return await context.SaveChangesAsync();
        }
        public async Task<T> Update<T>(T _object) where T : BaseObject
        {
            try
            {
                //_object.LastModifiedOn = DateTime.Now;
                //_object.LastModifiedBy = session.ID;
                //_object.ObjectStatus = ObjectStatus.NonDeleted;
                //_object.Status = Status.Active;

                context.Update(_object);
                return _object;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> UpdateRange<T>(ICollection<T> _objectList) where T : BaseObject
        {
            try
            {
                //foreach (var item in _objectList)
                //{​​​​​​​
                //    item.LastModifiedOn = DateTime.Now;
                //    item.ObjectStatus = ObjectStatus.NonDeleted;
                //    item.Status = Status.Active;
                //    item.LastModifiedBy = session.ID;
                //}​​​​​​​
                context.UpdateRange(_objectList);
                return _objectList.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
