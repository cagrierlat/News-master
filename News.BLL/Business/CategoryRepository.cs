using Microsoft.AspNetCore.Http;
using News.BLL.Intefaces;
using News.DAL.Classes.NewsClasses;
using News.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace News.BLL.Business
{
    public class CategoryRepository : BaseAppRepository, ICategoryRepository
    {
        private NewsDataContext context;
        private IHttpContextAccessor contextAccessor;
        public CategoryRepository(NewsDataContext _context, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor, _context)
        {
            context = _context;
            contextAccessor = httpContextAccessor;
        }
        public async Task<IQueryable<Category>> GetCategoryList(Expression<Func<Category, bool>> where)
        {
            try
            {
                return await GetQueryable(where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
