using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Test.PIK.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.URL = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultWCFConnection"].ConnectionString;
            return View();
        }
        [HttpPost]
        public JsonResult Send(string login, string lastName, string firstName)
        {
           
            List<string> result = new List<string>();
            try
            {
                var contentString = JsonConvert.SerializeObject(new Wcf.UserData() { Login = login, LastName = lastName, FirstName = firstName });

                using (var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
                {
                    var url = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultWCFConnection"].ConnectionString + "/SaveUser";
                    var request = new HttpRequestMessage(HttpMethod.Post, url)
                    {
                        Content = new StringContent(contentString, Encoding.UTF8, "application/json")
                    };

                    var res = client.SendAsync(request).Result;
                    var resultDataObj = new { SaveUserResult = new List<string>() };
                    var obj = JsonConvert.DeserializeAnonymousType(res.Content.ReadAsStringAsync().Result, resultDataObj);
                    result = obj.SaveUserResult;
                }
            }
            catch(Exception ex )
            {
                result = ex.Message.Split(' ').ToList();
            }
                return Json(result);
        }
        public static string Serialize<T>(T obj)
        {
            try
            {
                string retVal = null;

                using (var ms = new MemoryStream())
                {
                    var serializer = new DataContractJsonSerializer(typeof(T));
                    serializer.WriteObject(ms, obj);
                    retVal = Encoding.UTF8.GetString(ms.ToArray());
                }
                return retVal;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}