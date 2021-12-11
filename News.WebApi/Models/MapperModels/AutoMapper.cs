using AutoMapper;
using News.DAL.Classes.NewsClasses;
using News.WebApi.Models.NewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.WebApi.Models.MapperModels
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();

            CreateMap<Tag, TagViewModel>();
            CreateMap<TagViewModel, Tag>();
        }
    }
}
