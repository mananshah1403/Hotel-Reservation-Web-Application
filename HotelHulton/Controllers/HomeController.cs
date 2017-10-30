using HotelComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelHulton.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(CUSTOMER c)
        {
            HotelManager obj = new HotelManager();
            obj.Register(c);
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(CUSTOMER c )
        {
           
            HotelManager obj = new HotelManager();
            var customer = obj.isValidUser(c.Email, c.Password);
            if (customer != null)
            {
                if (customer.Email == "admin@admin.com")
                {
                    Session["customer"] = customer;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    Session["customer"] = customer;
                    return RedirectToAction("ShowHotels");
                }
                
            }
            else
            {
                ViewBag.Message = "Login not valid";
                return View();
            }


        }
        public ActionResult ViewCustomerDetails()
        {
            if (Session["customer"] != null)
            {
                var customer = Session["customer"];
                return View(customer);
            }
            else
                return RedirectToAction("Login");
        }

        public ActionResult Edit(int id)
        {
            if (Session["customer"] != null)
            {
                var customer = Session["customer"];
                return View(customer);
            }
            else
                return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult Edit(CUSTOMER c)
        {
            HotelManager obj = new HotelManager();
            obj.Update(c);
            Session["customer"] = c;
            return RedirectToAction("ViewCustomerDetails");
        }

        public ActionResult CreateHotel()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowHotels()
        {
            if (Session["customer"] != null)
            {
                HotelManager obj = new HotelManager();
                List<string> countryList = new List<string>();
                List<HOTEL> model = new List<HOTEL>();
                string country = "C";
                string state = "S";
                List<HOTEL> hotelList = new List<HOTEL>();
                hotelList = obj.GetHotels(country, state);
                model = hotelList;
                return View(model);
            }
            else
                return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult ShowHotels(string Country, string State)
        {

            HotelManager obj = new HotelManager();
            List<string> countryList = new List<string>();
            List<HOTEL> model = new List<HOTEL>();
            string country = "C";
            string state = "S";
            if (Convert.ToString(Request["Country"]) != "")
            {
                country = Convert.ToString(Request["Country"]);
            }
            if (Convert.ToString(Request["State"]) != "")
            {
                state = Convert.ToString(Request["State"]);
            }
            if (ModelState.IsValid)
            {
                List<HOTEL> hotelList = new List<HOTEL>();
                hotelList = obj.GetHotels(country, state);
                model = hotelList;
            }
            return View(model);
        }
        public ActionResult ViewReservations()
        {
            HotelManager obj = new HotelManager();
            List<RESERVATION> r = new List<RESERVATION>();
            CUSTOMER c = (CUSTOMER)Session["customer"];
            r = obj.getReservations(c.CID);
            return View(r);
        }
        public ActionResult ReservationDetails(int id)
        {
            HotelManager obj = new HotelManager();
            List<ROOM_RESERVATION> r = new List<ROOM_RESERVATION>();
            r = obj.details(id);
            return View(r);
        }


    }
}