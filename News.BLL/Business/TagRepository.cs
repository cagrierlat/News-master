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
    public class TagRepository : BaseAppRepository, ITagRepository
    {
        private NewsDataContext context;
        private IHttpContextAccessor contextAccessor;
        public TagRepository(NewsDataContext _context, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor, _context)
        {
            context = _context;
            contextAccessor = httpContextAccessor;
        }
        public async Task<IQueryable<Tag>> GetTagList(Expression<Func<Tag, bool>> where)
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
