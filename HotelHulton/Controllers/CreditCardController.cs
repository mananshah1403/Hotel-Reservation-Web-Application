using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelComponent;

namespace HotelHulton.Controllers
{
    public class CreditCardController : Controller
    {
        //
        // GET: /CreditCard/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreditCardDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreditCardDetails(CREDIT_CARD model)
        {
            CreditCardManager objMngr = new CreditCardManager();
            CUSTOMER c = (CUSTOMER)Session["customer"];
            int cid = c.CID;
            int invoiceNum = objMngr.makePayment(model,cid);
            List<ROOM_RESERVATION> lstRoomRes = new List<ROOM_RESERVATION>();
            for (int i = 0; i <= Helper.GetHotelId().Count; i++)
            {
                ROOM_RESERVATION objRoomRsvtn = new ROOM_RESERVATION();
                objRoomRsvtn.InvoiceNo = invoiceNum;
                objRoomRsvtn.HotelID = Helper.GetHotelId()[Helper.GetHotelId().Count - 1];
                objRoomRsvtn.RoomNo = Helper.GetRoomNum()[Helper.GetRoomNum().Count - 1];
                objRoomRsvtn.CheckInDate = Convert.ToDateTime(Helper.GetCheckInDate()[Helper.GetCheckInDate().Count - 1]);
                objRoomRsvtn.CheckOutDate = Convert.ToDateTime(Helper.GetCheckOutDate()[Helper.GetCheckOutDate().Count - 1]);
                lstRoomRes.Add(objRoomRsvtn);
                Helper.GetHotelId().RemoveAt(Helper.GetHotelId().Count - 1);
                Helper.GetRoomNum().RemoveAt(Helper.GetRoomNum().Count - 1);
                Helper.GetCheckInDate().RemoveAt(Helper.GetCheckInDate().Count - 1);
                Helper.GetCheckOutDate().RemoveAt(Helper.GetCheckOutDate().Count - 1);
            }
            bool success = objMngr.makeReservation(lstRoomRes, Helper.GetBreakfast(), Helper.GetService());
            return RedirectToAction("Index", "Booking");
        }
    }
}