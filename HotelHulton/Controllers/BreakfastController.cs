using HotelComponent;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelHulton.Controllers
{
    public class BreakfastController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowBreakfast(int RoomNo, int Capacity)
        {
            List<BREAKFAST> lstBrkfst = new List<BREAKFAST>();
            BreakfastManager objMngr = new BreakfastManager();
            ViewBag.Capacity = Capacity;
            Session["Capacity"] = Capacity;
            Session["RoomNo"] = RoomNo;
            Helper.AddRoomNum(RoomNo);
            Helper.AddCheckInDate(Convert.ToString(Session["ChkInDate"]));
            Helper.AddCheckOutDate(Convert.ToString(Session["ChkOutDate"]));
            lstBrkfst = objMngr.GetBreakfast(Convert.ToInt32(Session["HotelID"]));
            ViewBag.ShowError = false;
            return View(lstBrkfst);
        }
        [HttpPost]
        public ActionResult ShowBreakfast()
        {
            ViewBag.ShowError = false;
            @ViewBag.Capacity = Convert.ToInt32(Session["Capacity"]);
            List<BREAKFAST> lstBrkfst = new List<BREAKFAST>();
            BreakfastManager objMngr = new BreakfastManager();
            lstBrkfst = objMngr.GetBreakfast(Convert.ToInt32(Session["HotelID"]));

            int countOfOrders = 0;
            int sum = 0;

            NameValueCollection nvc = Request.Form;
            foreach (var item in Request.Form.AllKeys)
            {
                foreach (BREAKFAST Bitem in lstBrkfst)
                {
                    if (item == Bitem.BType)
                    {
                        if (nvc[item] != "")
                        {
                            sum = sum + Convert.ToInt32(nvc[item]);
                        }

                    }
                }
            }
            if (sum > Convert.ToInt32(Session["Capacity"]))
            {
                ViewBag.ShowError = true;
                return View(lstBrkfst);
            }
            else if (sum <= Convert.ToInt32(Session["Capacity"]))
            {
                foreach (var item in Request.Form.AllKeys)
                {
                    foreach (BREAKFAST Bitem in lstBrkfst)
                    {
                        if (item == Bitem.BType)
                        {
                            if (nvc[item] != "")
                            {
                                BREAKFAST objBrk = new BREAKFAST();
                                objBrk.HotelID = Convert.ToInt32(Session["HotelID"]);
                                objBrk.BType = Bitem.BType;
                                objBrk.BPrice = Bitem.BPrice;
                                objBrk.Description = Bitem.Description;
                                RRESV_BREAKFAST objRsvBrk = new RRESV_BREAKFAST();
                                objRsvBrk.BType = Bitem.BType;
                                objRsvBrk.HotelID = Convert.ToInt32(Session["HotelID"]);
                                objRsvBrk.RoomNo = Convert.ToInt32(Session["RoomNo"]);
                                objRsvBrk.CheckInDate = Convert.ToDateTime(Session["ChkInDate"]);
                                objRsvBrk.NoOfOrders = Convert.ToInt32(nvc[item]);
                                objBrk.RRESV_BREAKFAST.Add(objRsvBrk);
                                Helper.AddRRBreakfast(objBrk);
                                Helper.AddBreakfast(objRsvBrk);
                            }
                        }
                    }
                }

            }

            return RedirectToAction("ServiceDetails", "Service");
        }
    }
}