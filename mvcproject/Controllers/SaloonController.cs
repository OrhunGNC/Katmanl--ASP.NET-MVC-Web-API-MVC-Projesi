using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcproject.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace mvcproject.Controllers
{
    public class SaloonController : Controller
    {
        // GET: Saloon
        public ActionResult Index()
        {
            IEnumerable<SaloonModel> responseList;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Saloons").Result;
            responseList = response.Content.ReadAsAsync<IEnumerable<SaloonModel>>().Result;
            return View(responseList);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new SaloonModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Saloons/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<SaloonModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult EY(SaloonModel save)
        {
            if (save.SaloonNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Saloons", save).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Saloons/"+save.SaloonNo,save).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Saloons/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}