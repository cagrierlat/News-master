using News.DAL.Classes.BaseClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace News.BLL.Intefaces
{
    public interface IBaseAppRepository
    {
        Task<T> Add<T>(T _object) where T : BaseObject;
        Task<ICollection<T>> AddRange<T>(ICollection<T> _objectList) where T : BaseObject;
        Task<T> Update<T>(T _object) where T : BaseObject;
        Task<int> UpdateRange<T>(ICollection<T> _objectList) where T : BaseObject;
        Task<int> Delete<T>(int ID) where T : BaseObject;
        Task<int> DeleteRange<T>(IQueryable<T> _objectList) where T : BaseObject;
        Task<T> Find<T>(Expression<Func<T, bool>> where) where T : BaseObject;
        Task<T> FindNonDeletedAndActive<T>(Expression<Func<T, bool>> where) where T : BaseObject;
        bool Any<T>(Expression<Func<T, bool>> where) where T : BaseObject;
        bool AnyNonDeletedAndActive<T>(Expression<Func<T, bool>> where) where T : BaseObject;
        Task<IQueryable<T>> GetQueryable<T>(Expression<Func<T, bool>> where) where T : BaseObject;
        Task<T> GetByID<T>(int ID) where T : BaseObject;
        Task<IQueryable<T>> GetNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseObject;
        int Count<T>(Expression<Func<T, bool>> expression) where T : BaseObject;
        Task<IQueryable<T>> GetNonDeletedAndPaginate<T>(int pageID, int PageSize) where T : BaseObject;
        void RemoveRange<T>([NotNullAttribute] params object[] entities);
        void RemoveRange<T>([NotNullAttribute] IEnumerable<object> entities);
        Task<int> Remove<T>(int id) where T : BaseObject;
        Task<T> Remove<T>(Expression<Func<T, bool>> expression) where T : BaseObject;
        Task<string> ClearTurkishCharacter(string _dirtyText);
        string FirstCharToUpper(string input);
        Task<int> SaveChange();
        Task<List<T>> GetAll<T>() where T : BaseObject;
    }
}
