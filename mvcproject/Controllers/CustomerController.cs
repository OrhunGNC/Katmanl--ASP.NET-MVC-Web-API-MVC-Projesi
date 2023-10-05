using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcproject.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;

namespace mvcproject.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            IEnumerable<CustomerModel> responseList;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Customers").Result;
            responseList = response.Content.ReadAsAsync<IEnumerable<CustomerModel>>().Result;
            return View(responseList);
        }
        public ActionResult EY(int id=0)
        {
            if (id == 0)
            {
                return View(new CustomerModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Customers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<CustomerModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult EY(CustomerModel save)
        {
            if (save.CustomerNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Customers", save).Result;

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Customers/" + save.CustomerNo, save).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Customers/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}