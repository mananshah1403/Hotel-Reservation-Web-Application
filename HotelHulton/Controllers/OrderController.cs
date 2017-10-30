using HotelComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelHulton.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderDetails()
        {
            #region Room
            ROOM objRoom = new ROOM();
            OrderManager roomMgr = new OrderManager();
            objRoom = roomMgr.getSelectedRoom(Convert.ToInt32(Session["HotelID"]), Convert.ToInt32(Session["RoomNo"]));
            List<ROOM> lstRoom = new List<ROOM>();
            lstRoom.Add(objRoom);
            RoomManager rmngr = new RoomManager();
            ROOM disRoom = (rmngr.isRoomDiscount(lstRoom, Convert.ToInt32(Session["HotelID"]))).First();
            @ViewBag.RoomNo = disRoom.RoomNo;
            @ViewBag.RoomType = disRoom.RType;
            @ViewBag.Desc = disRoom.Description;
            @ViewBag.Price = disRoom.Price;
            @ViewBag.Capacity = disRoom.Capacity;
            #endregion
            #region Breakfast
            List<BREAKFAST> lst = Helper.GetRRBreakfast();
            int? TotalBPrice = 0;
            foreach (BREAKFAST item in lst)
            {
                item.Description = (item.RRESV_BREAKFAST.First().NoOfOrders).ToString();
                TotalBPrice = TotalBPrice + item.BPrice;
            }
            ViewBag.BrkFast = lst;
            
            #endregion
            #region Service
            List<SERVICE> srvList = new List<SERVICE>();
            srvList = (List<SERVICE>)Session["Services"];
            ViewBag.Services = srvList;
            #endregion
            int? TotalPayment = Convert.ToInt32(Session["NoOfDays"]) * disRoom.Price + TotalBPrice + Convert.ToInt32(Session["TotalSPrice"]);
            ViewBag.TotalPayment = TotalPayment;
            return View();
        }

        [HttpPost]
        public ActionResult OrderDetails(string submit)
        {
            if (submit == "Book Another Room")
            {
                #region sessionFlush
                Session["One"] = "";
                Session["Two"] = "";
                Session["Three"] = "";
                Session["Four"] = "";
                Session["Five"] = "";
                Session["Six"] = "";
                Session["Seven"] = "";
                #endregion
                return RedirectToAction("ShowHotels", "Home");
            }

            return RedirectToAction("CreditCardDetails", "CreditCard");
        }
    }

}