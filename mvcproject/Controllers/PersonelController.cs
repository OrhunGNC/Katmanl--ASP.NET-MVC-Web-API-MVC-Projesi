using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcproject.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;
using Microsoft.Ajax.Utilities;

namespace mvcproject.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        public ActionResult Index()
        {
            IEnumerable<PersonelModel> responseList;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Personels").Result;
            responseList = response.Content.ReadAsAsync<IEnumerable<PersonelModel>>().Result;

            return View(responseList);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new PersonelModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Personels/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<PersonelModel>().Result) ;
            }
        }
        [HttpPost]
        public ActionResult EY(PersonelModel save)
        {
            if (save.PersonelNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Personels", save).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Personels/"+save.PersonelNo,save).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Personels/"+id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}