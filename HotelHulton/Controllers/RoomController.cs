using HotelComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelHulton.Controllers
{
   
        public class RoomController : Controller
        {
            //
            // GET: /Room/
            public ActionResult Index()
            {
                return View();
            }
            public ActionResult RoomDetails(int HotelID)
            {
                Session["HotelID"] = HotelID;
                Helper.AddHotelID(HotelID);
                ViewBag.ShowRoomDetail = false;
                return View();
            }
            [HttpPost]
            public ActionResult RoomDetails(string ChkInDate, string ChkOutDate)
            {
                Session["ChkInDate"] = ChkInDate;
                Session["ChkOutDate"] = ChkOutDate;
                int NoOfDays = (Convert.ToDateTime(ChkOutDate) - Convert.ToDateTime(ChkInDate)).Days;
                if (NoOfDays == 0)
                {
                    Session["NoOfDays"] = 1;
                }
                Session["NoOfDays"] = NoOfDays;
                ViewBag.ShowRoomDetail = true;
                RoomManager objRoom = new RoomManager();
                List<ROOM> roomDetails = new List<ROOM>();
              List<ROOM> droomDetails = new List<ROOM>();
                roomDetails = objRoom.GetRoomDetails(ChkInDate, ChkOutDate, Convert.ToInt32(Session["HotelID"]));
                droomDetails = objRoom.isRoomDiscount(roomDetails,(int)Session["HotelID"]);
                //Session["disPrice"] = droomDetails.
                ViewBag.RoomTypes = droomDetails;
                return View(droomDetails);
            }
        }

    }