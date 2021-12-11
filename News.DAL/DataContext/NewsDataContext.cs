using Microsoft.EntityFrameworkCore;
using News.DAL.Classes.NewsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.DataContext
{
    public class NewsDataContext : DbContext
    {
        public NewsDataContext(DbContextOptions<NewsDataContext> options) : base(options)
        {
        }

        public DbSet<Category> Siparises { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
