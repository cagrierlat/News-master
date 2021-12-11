using Microsoft.AspNetCore.Http;
using News.BLL.Intefaces;
using News.BLL.Intefaces.UnitWork;
using News.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BLL.Business.UnitWork
{
    public class UnitWork : IUnitWork
    {
        IHttpContextAccessor httpContextAccessor;
        private readonly NewsDataContext context;
        public UnitWork(IHttpContextAccessor _httpContextAccessor, NewsDataContext _context)
        {
            httpContextAccessor = _httpContextAccessor;
            context = _context ?? throw new ArgumentNullException("context can not be null");
        }

        private IBaseAppRepository _BaseAppRepository;
        public IBaseAppRepository BaseAppRepository
        {
            get => _BaseAppRepository ?? (_BaseAppRepository = new BaseAppRepository(httpContextAccessor, context));
        }

        private ICategoryRepository _CategoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get => _CategoryRepository ?? (_CategoryRepository = new CategoryRepository(context, httpContextAccessor));
        }

        private ITagRepository _TagRepository;
        public ITagRepository TagRepository
        {
            get => _TagRepository ?? (_TagRepository = new TagRepository(context, httpContextAccessor));
        }
    }
}
