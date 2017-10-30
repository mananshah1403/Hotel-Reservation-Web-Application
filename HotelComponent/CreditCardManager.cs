using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelComponent
{
    public class CreditCardManager
    {
        private static System.Data.Entity.SqlServer.SqlProviderServices instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        public int makePayment(CREDIT_CARD model,int id)
        {
            var custID = new SqlParameter("@CustID", id);
            var cNum = new SqlParameter("@CNumber", model.CNumber);
            var cTyp = new SqlParameter("@cType", model.CType);
            var bAddress = new SqlParameter("@Baddress", model.Baddress);
            var code = new SqlParameter("@Code", model.Code);
            var expDate = new SqlParameter("@ExpDate", model.ExpDate);
            var name = new SqlParameter("@Name", model.Name);
            var invoice = new SqlParameter("@Invoice", 0);
            invoice.SqlDbType = System.Data.SqlDbType.Int;
            invoice.Direction = System.Data.ParameterDirection.Output;
            int Inv = 0;
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                int inv = context.Database
                 .ExecuteSqlCommand("SP_INSERT_CREDIT_CARD_DETAIL @CustID, @CNumber, @cType, @Baddress, @Code, @ExpDate, @Name, @Invoice OUT", custID, cNum, cTyp, bAddress, code, expDate, name, invoice);

                Inv = (int)invoice.Value;
            }
            return Inv;
        }

        public bool makeReservation(List<ROOM_RESERVATION> listRoomRsvtn, List<RRESV_BREAKFAST> lstRsvBrk, List<RRESV_SERVICE> lstResServ)
        {
            foreach (ROOM_RESERVATION objRoomRsvtn in listRoomRsvtn)
            {
                var invoiceNum = new SqlParameter("@InvoiceNum", objRoomRsvtn.InvoiceNo);
                var hotelID = new SqlParameter("@HotelID", objRoomRsvtn.HotelID);
                var roomNo = new SqlParameter("@RoomNo", objRoomRsvtn.RoomNo);
                var chkInDt = new SqlParameter("@CheckInDate", objRoomRsvtn.CheckInDate);
                var chkOutDt = new SqlParameter("@CheckOutDate", objRoomRsvtn.CheckOutDate);
                using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
                {
                    context.Database
                        .ExecuteSqlCommand("SP_INSERT_ROOM_RESERVATION_DETAIL @InvoiceNum, @HotelID, @RoomNo, @CheckInDate, @CheckOutDate", invoiceNum, hotelID, roomNo, chkInDt, chkOutDt);
                }
            }
            foreach (RRESV_BREAKFAST brkfst in lstRsvBrk)
            {
                var bType = new SqlParameter("@BType", brkfst.BType);
                var hotlID = new SqlParameter("@HotelID", brkfst.HotelID);
                var roomNum = new SqlParameter("@RoomNo", brkfst.RoomNo);
                var chkInDate = new SqlParameter("@CheckInDate", brkfst.CheckInDate);
                var noOfOrdrs = new SqlParameter("@NoOfOrders", brkfst.NoOfOrders);
                using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
                {
                    context.Database
                        .ExecuteSqlCommand("SP_INSERT_BREAKFAST_RESERVATION_DETAIL @BType, @HotelID, @RoomNo, @CheckInDate, @NoOfOrders", bType, hotlID, roomNum, chkInDate, noOfOrdrs);
                }
            }

            foreach (RRESV_SERVICE srvc in lstResServ)
            {
                var sType = new SqlParameter("@SType", srvc.SType);
                var hotlID = new SqlParameter("@HotelID", srvc.HotelID);
                var roomNum = new SqlParameter("@RoomNo", srvc.RoomNo);
                var chkInDate = new SqlParameter("@CheckInDate", srvc.CheckInDate);

                using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
                {
                    context.Database
                        .ExecuteSqlCommand("SP_INSERT_SERVICE_RESERVATION_DETAIL @SType, @HotelID, @RoomNo, @CheckInDate", sType, hotlID, roomNum, chkInDate);
                }
            }
            return true;
        }
    }
}
