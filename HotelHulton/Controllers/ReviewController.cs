using HotelComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelHulton.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Review(int HotelID,int RoomNo)
        {
            ViewBag.status = false;
            ROOM_REVIEW review = new ROOM_REVIEW();
            review.HotelID = HotelID;
            review.RoomNo = RoomNo;
            review.CID = ((CUSTOMER)Session["customer"]).CID;
            return View(review);
        }
        [HttpPost]
        public ActionResult Review(ROOM_REVIEW r)
        {
           r.CID= ((CUSTOMER)Session["customer"]).CID;
            ReviewManager obj = new ReviewManager();
            if (obj.isReviewGiven(r))
            {
                ViewBag.status = true;
                ViewBag.error = "You have already Rated this Room";
            }
            else
            {
                obj.AddRoomReview(r);
                return RedirectToAction("ViewReservations", "Home");
            }
            return View();
        }

        public ActionResult BreakFastReview(int HotelID,String BType)
        {
            ViewBag.status = false;
            BREAKFAST_REVIEW breview = new BREAKFAST_REVIEW();
            breview.HotelID = HotelID;
            breview.BType = BType;
            breview.CID = ((CUSTOMER)Session["customer"]).CID;
            return View();
        }

        [HttpPost]
        public ActionResult BreakFastReview(BREAKFAST_REVIEW review)
        {
            review.CID = ((CUSTOMER)Session["customer"]).CID;
            ReviewManager obj = new ReviewManager();
            if(obj.isBFReviewGiven(review))
            {
                ViewBag.status = true;
                ViewBag.error = "You have already Rated this Breakfast for this Hotel";
            }
            else
            {
                obj.AddBreakfastReview(review);
                return RedirectToAction("ViewReservations", "Home");
            }
            return View();
        }
        public ActionResult ServiceReview(int HotelID, String SType)
        {
            ViewBag.status = false;
            SERVICE_REVIEW sreview = new SERVICE_REVIEW();
            sreview.HotelID = HotelID;
            sreview.SType = SType;
            sreview.CID = ((CUSTOMER)Session["customer"]).CID;
            return View();
        }

        [HttpPost]
        public ActionResult ServiceReview(SERVICE_REVIEW review)
        {
            review.CID = ((CUSTOMER)Session["customer"]).CID;
            ReviewManager obj = new ReviewManager();
            if (obj.isSRReviewGiven(review))
            {
                ViewBag.status = true;
                ViewBag.error = "You have already Rated this Service for this Hotel";
            }
            else
            {
                obj.AddServiceReview(review);
                return RedirectToAction("ViewReservations", "Home");
            }
            return View();
        }
    }
}