using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using News.BLL.Intefaces.UnitWork;
using News.DAL.Classes.NewsClasses;
using News.Presentation.Models;
using News.Presentation.StringInformations;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static News.DAL.Classes.NewsClasses.New;

namespace News.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConnectionStringInformations _connectionStringInformations;
        private readonly IUnitWork uow;

        public HomeController(ILogger<HomeController> logger, ConnectionStringInformations connectionStringInformations, IUnitWork _uow)
        {
            _logger = logger;
            _connectionStringInformations = connectionStringInformations;
            uow = _uow;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["APIURL"] = _connectionStringInformations.APIBaseURLConnection;
            return View();
        }
        [HttpGet]
        public IActionResult Descriptions()
        {
            ViewData["APIURL"] = _connectionStringInformations.APIBaseURLConnection;
            return View();
        }
        [HttpGet]
        public IActionResult Statistics()
        {
            ViewData["APIURL"] = _connectionStringInformations.APIBaseURLConnection;
            return View();
        }
        [HttpGet]
        public async Task<object> GetNews()
        {
            List<StatisticViewModel> modelList = new List<StatisticViewModel>();

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

                    #region rapor modeli
                    int turkiyeCount = 0, sporCount = 0, gundemCount = 0, ekonomiCount = 0, dunyaCount = 0;
                    foreach (var item in allOfList.Haber)
                    {
                        //okunma sayılarına rastegel sayı ata
                        Random number = new Random();
                        item.Okunmaadedi = number.Next(10);

                        switch (item.HaberKategorisi)
                        {
                            case "Türkiye":
                                turkiyeCount += item.Okunmaadedi;
                                break;
                            case "Spor":
                                sporCount += item.Okunmaadedi;
                                break;
                            case "Gündem":
                                gundemCount += item.Okunmaadedi;
                                break;
                            case "Ekonomi":
                                ekonomiCount += item.Okunmaadedi;
                                break;
                            case "Dünya":
                                dunyaCount += item.Okunmaadedi;
                                break;
                            default:
                                break;
                        }
                    }
                    var kategoriList = await uow.CategoryRepository.GetAll<Category>();
                   
                    foreach (var item in kategoriList)
                    {
                        var model = new StatisticViewModel();
                        switch (item.description)
                        {
                            case "Türkiye":
                                model.kategori = item.description;
                                model.okunmaSayisi = turkiyeCount;
                                modelList.Add(model);
                                break;
                            case "Spor":
                                model.kategori = item.description;
                                model.okunmaSayisi = sporCount;
                                modelList.Add(model);
                                break;
                            case "Gündem":
                                model.kategori = item.description;
                                model.okunmaSayisi = gundemCount;
                                modelList.Add(model);
                                break;
                            case "Ekonomi":
                                model.kategori = item.description;
                                model.okunmaSayisi = ekonomiCount;
                                modelList.Add(model);
                                break;
                            case "Dünya":
                                model.kategori = item.description;
                                model.okunmaSayisi = dunyaCount;
                                modelList.Add(model);
                                break;
                            default:
                                break;
                        }
                    }

                    #endregion

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return modelList;
        }
    }
}
