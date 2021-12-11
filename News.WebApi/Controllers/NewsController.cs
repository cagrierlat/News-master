using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using News.DAL.Classes.NewsClasses;
using System.IO;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using News.BLL.Intefaces.UnitWork;
using AutoMapper;
using News.WebApi.StringInformations;
using News.DAL.DataContext;
using News.WebApi.Models.NewsModels;
using static News.DAL.Classes.NewsClasses.New;

namespace News.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class NewsController : ControllerBase
    {
        private NewsDataContext context;
        private readonly IUnitWork uow;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ConnectionStringInformations _connectionStringInformations;
        public NewsController(IUnitWork _uow, IMapper _mapper, IHttpContextAccessor httpContextAccessor, NewsDataContext _context, ConnectionStringInformations connectionStringInformations)
        {
            uow = _uow;
            mapper = _mapper;
            context = _context;
            _httpContextAccessor = httpContextAccessor;
            _connectionStringInformations = connectionStringInformations;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNews()
        {
            var client = new RestClient("https://www.trthaber.com/xml_mobile.php?tur=xml_genel&selectEx=okunmaadedi,yorumSay&id=HABERID_BURAYA_GELECEK&commentList=show");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            //client.Authenticator = new HttpBasicAuthenticator("x1", "654321");
            IRestResponse response = client.Execute(request);

            XmlSerializer serializer = new XmlSerializer(typeof(Haberler));
            var allOfList = new Haberler();
            using (StringReader reader = new StringReader(response.Content))
            {
                try
                {
                    allOfList = (Haberler)serializer.Deserialize(reader);

                    foreach (var item in allOfList.Haber)
                    {
                        item.HaberAciklama = item.HaberAciklama.ToString();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return Ok(allOfList.Haber);
        }
        [HttpGet("[action]")]
        public async Task<object> GetCategoryList()
        {
            try
            {
                IEnumerable<Category> model = await uow.CategoryRepository.GetCategoryList(x => x.active == true);
                var mapModel = mapper.Map<List<CategoryViewModel>>(model);
                var result = mapModel.OrderByDescending(x => x.id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddCategory([FromForm] CategoryViewModel values)
        {
            try
            {
                values.id = 0;
                values.active = true;
                var result = await uow.CategoryRepository.Add(mapper.Map<Category>(values));
                await uow.CategoryRepository.SaveChange();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCategory([FromForm] CategoryViewModel values)
        {
            try
            {
                var model = await uow.CategoryRepository.GetByID<Category>(values.id);
                model.description = values.description;

                await uow.CategoryRepository.Update(model);
                await uow.CategoryRepository.SaveChange();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("DeleteCategory/{key}")]
        public async Task<IActionResult> DeleteCategory(int key)
        {
            try
            {
                var model = await uow.CategoryRepository.GetByID<Category>(key);

                //eğer kategoriye bağlı haber varsa silme

                model.active = false;

                await uow.CategoryRepository.Update(model);
                await uow.CategoryRepository.SaveChange();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]")]
        public async Task<object> GetTagList()
        {
            try
            {
                IEnumerable<Tag> model = await uow.TagRepository.GetTagList(x => x.active == true);
                var mapModel = mapper.Map<List<TagViewModel>>(model);
                var result = mapModel.OrderByDescending(x => x.id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddTag([FromForm] TagViewModel values)
        {
            try
            {
                values.id = 0;
                values.active = true;
                var result = await uow.TagRepository.Add(mapper.Map<Tag>(values));
                await uow.CategoryRepository.SaveChange();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateTag([FromForm] TagViewModel values)
        {
            try
            {
                var model = await uow.TagRepository.GetByID<Tag>(values.id);
                model.description = values.description;

                await uow.TagRepository.Update(model);
                await uow.TagRepository.SaveChange();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("DeleteTag/{key}")]
        public async Task<IActionResult> DeleteTag(int key)
        {
            try
            {
                var model = await uow.TagRepository.GetByID<Tag>(key);

                //eğer kategoriye bağlı haber varsa silme

                model.active = false;

                await uow.TagRepository.Update(model);
                await uow.TagRepository.SaveChange();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
