using HotelComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelHulton.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditDetails()
        {
            HotelManager obj = new HotelManager();
            List<HOTEL> hotelList = new List<HOTEL>();
            hotelList = obj.GetHotels();
            List<HOTEL> model = hotelList;
            return View(model);
        }
        public ActionResult EditHotel(int id)
        {
            HotelManager obj = new HotelManager();
            var hotels = obj.GetHotels();
            var hotel = hotels.Find((c) => c.HotelID == id);
            return View(hotel);
        }
        [HttpPost]
        public ActionResult EditHotel(HOTEL h)
        {
            HotelManager obj = new HotelManager();
            obj.UpdateHotel(h);
            return RedirectToAction("Index");

        }
        public ActionResult HotelDetail(int id)
        {
            HotelManager obj = new HotelManager();
            var details = obj.getDetails(id);
            details.ROOMs = obj.getDiscountRoom(details.ROOMs.ToList(),id);
            Session["hotelid"] = id;
            return View(details);
        }

        public ActionResult EditRoom(int id)
        {
            HotelManager obj = new HotelManager();
            var room = obj.getRoom(id);
            return View(room);
        }
        [HttpPost]
        public ActionResult EditRoom(ROOM r)
        {
            HotelManager obj = new HotelManager();
            obj.UpdateRooms(r);
            return RedirectToAction("HotelDetails");
        }
        public ActionResult EditBreakfast(int id,String type)
        {
            HotelManager obj = new HotelManager();
            var breakfast = obj.getBreakfast(id,type);
            return View(breakfast);
        }
        [HttpPost]
        public ActionResult EditBreakfast(BREAKFAST b)
        {
            HotelManager obj = new HotelManager();
            obj.UpdateBreakFasts(b);
            return RedirectToAction("EditDetails");
        }
        public ActionResult EditService(int id,String type)
        {
            HotelManager obj = new HotelManager();
            var service= obj.getService(id,type);
            return View(service);
        }
        [HttpPost]
        public ActionResult EditService(SERVICE s)
        {
            HotelManager obj = new HotelManager();
            obj.UpdateServices(s);
            return RedirectToAction("EditDetails");
        }

        public ActionResult CreateHotel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateHotel(HOTEL h)
        {
            HotelManager obj = new HotelManager();
            obj.insertHotel(h);
            return RedirectToAction("EditDetails");
        }
        public ActionResult CreateBreakfast()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBreakfast(BREAKFAST b)
        {
            HotelManager obj = new HotelManager();
            obj.insertBreakfast(b, (int)Session["hotelid"]);
            return RedirectToAction("EditDetails");

        }
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(SERVICE s)
        {
            HotelManager obj = new HotelManager();
            obj.insertService(s, (int)Session["hotelid"]);
            return RedirectToAction("EditDetails");

        }
        public ActionResult CreateRoom()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRoom(ROOM r)
        {
            HotelManager obj = new HotelManager();
            obj.insertRoom(r, (int)Session["hotelid"]);
            return RedirectToAction("EditDetails");
        }
        public ActionResult RoomDiscount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RoomDiscount(int rno,int hid,DISCOUNTED_ROOM r)
        {
            HotelManager obj = new HotelManager();
            obj.insertDiscountRoom(r, hid, rno);
            return RedirectToAction("EditDetails");
        }

        public ActionResult ViewStats()
        {
            return View();
        }

        public ActionResult HRRoomType()
        {
            return View();
        }
        public ActionResult BestCustomers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BestCustomers(String SDate,String EDate)
        {
            AdminManager obj = new AdminManager();
            List<BestCustomer> best = new List<BestCustomer>();
            best = obj.GetBBestCustomer(Convert.ToDateTime(SDate), Convert.ToDateTime(EDate));
            return View("BestCustomersList",best);
        }
        public ActionResult BestBreakfasts()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BestBreakfasts(String SDate,String EDate)
        {
            AdminManager obj = new AdminManager();
            List<BestBreakfast> best = new List<BestBreakfast>();
            best = obj.GetBestBreakfast(Convert.ToDateTime(SDate), Convert.ToDateTime(EDate));
            return View("BestBreakFastsList", best);
        }
        public ActionResult BestServices()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BestServices(String SDate, String EDate)
        {
            AdminManager obj = new AdminManager();
            List<BestService> best = new List<BestService>();
            best = obj.GetService(Convert.ToDateTime(SDate), Convert.ToDateTime(EDate));
            return View("BestServiceList", best);
        }

        public ActionResult BestRooms()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BestRooms(String SDate, String EDate)
        {
            AdminManager obj = new AdminManager();
            List<BestRoomType> best = new List<BestRoomType>();
            best = obj.GetBestRoomType(Convert.ToDateTime(SDate), Convert.ToDateTime(EDate));
            return View("BestRoomsList", best);
        }




    }
}

