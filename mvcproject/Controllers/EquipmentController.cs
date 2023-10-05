using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcproject.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Ajax.Utilities;

namespace mvcproject.Controllers
{
    public class EquipmentController : Controller
    {
        // GET: Equipment
        public ActionResult Index()
        {
            IEnumerable<EquipmentModel> responseList;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Equipments").Result;
            responseList = response.Content.ReadAsAsync<IEnumerable<EquipmentModel>>().Result;
            return View(responseList);
        }
        public ActionResult EY(int id=0)
        {
            if (id == 0)
            {
                return View(new EquipmentModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Equipments/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<EquipmentModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(EquipmentModel save)
        {
            if (save.EquipmentNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Equipments", save).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Equipments/" + save.EquipmentNo, save).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Equipments/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}