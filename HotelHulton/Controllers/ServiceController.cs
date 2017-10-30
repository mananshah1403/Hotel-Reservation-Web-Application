using HotelComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelHulton.Controllers
{
    public class ServiceController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ServiceDetails()
        {
            List<SERVICE> model = new List<SERVICE>();
            ServiceManager objServ = new ServiceManager();
            model = objServ.GetServices(Convert.ToInt32(Session["HotelID"]));
            ViewBag.Services = model.Select(s => s.SType).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult ServiceDetails(string[] checkboxes)
        {
            List<SERVICE> model = new List<SERVICE>();
            ServiceManager objServ = new ServiceManager();
            model = objServ.GetServices(Convert.ToInt32(Session["HotelID"]));
            List<SERVICE> serTyps = new List<SERVICE>();
            int? TotalSPrice = 0;
            foreach (string value in checkboxes)
            {
                SERVICE obj = new SERVICE();
                RRESV_SERVICE objSrv = new RRESV_SERVICE();
                objSrv.SType = value;
                objSrv.HotelID = Convert.ToInt32(Session["HotelID"]);
                objSrv.RoomNo = Convert.ToInt32(Session["RoomNo"]);
                objSrv.CheckInDate = Convert.ToDateTime(Session["ChkInDate"]);
                obj = model.Where(j => j.SType == value && j.HotelID == Convert.ToInt32(Session["HotelID"])).SingleOrDefault();
                TotalSPrice = TotalSPrice + obj.SPrice;
                Session["TotalSPrice"] = TotalSPrice;
                serTyps.Add(obj);
                Helper.AddService(objSrv);
            }
            Session["Services"] = serTyps;
            return RedirectToAction("OrderDetails", "Order");
        }
    }
}