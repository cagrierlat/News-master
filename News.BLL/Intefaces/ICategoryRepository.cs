using News.DAL.Classes.NewsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace News.BLL.Intefaces
{
    public interface ICategoryRepository : IBaseAppRepository
    {
        Task<IQueryable<Category>> GetCategoryList(Expression<Func<Category, bool>> where);
    }
}
