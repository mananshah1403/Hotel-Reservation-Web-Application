using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelComponent;
namespace HotelComponent
{
    public class ReviewManager
    {
        private static System.Data.Entity.SqlServer.SqlProviderServices instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        public void AddRoomReview(ROOM_REVIEW r)
        {
            var hotelid = new SqlParameter("@HotelID", r.HotelID);
            var roomno = new SqlParameter("@RoomNo", r.RoomNo);
            var rating = new SqlParameter("@Rating", r.Rating);
            var text = new SqlParameter("@Text", r.Text);
            var custid = new SqlParameter("@CID", r.CID);
            //var RID = new SqlParameter("@RID", 0);
            //RID.SqlDbType = System.Data.SqlDbType.Int;
            //RID.Direction = System.Data.ParameterDirection.Output;
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                context.Database.ExecuteSqlCommand("SP_INSERT_ROOM_REVIEW @Rating,@Text,@CID,@HotelID,@RoomNo", rating, text, custid, hotelid, roomno);
            }

        }

        public bool isReviewGiven(ROOM_REVIEW r)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            var roomReviews = context.ROOM_REVIEW.ToList();
            var review = roomReviews.Find((c) => c.CID == r.CID && c.HotelID == r.HotelID && c.RoomNo == r.RoomNo);
            if (review != null)
            {
                return true;
            }
            else
                return false;
        }

        public void AddBreakfastReview(BREAKFAST_REVIEW r)
        {
            var hotelid = new SqlParameter("@HotelID", r.HotelID);
            var btype = new SqlParameter("@BType", r.BType);
            var rating = new SqlParameter("@Rating", r.Rating);
            var text = new SqlParameter("@BFText", r.Text.ToString());
            var custid = new SqlParameter("@CID", r.CID);
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
 
                context.Database.ExecuteSqlCommand("SP_INSERT_BREAKFAST_REVIEW @HotelID,@BType,@CID,@BFText,@Rating", hotelid, btype, custid, text, rating);
            }

        }
        public bool isBFReviewGiven(BREAKFAST_REVIEW r)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            var bfreview = context.BREAKFAST_REVIEW.ToList();
            var breview = bfreview.Find((c) => c.CID == r.CID && c.HotelID == r.HotelID && c.BType == r.BType);
            if (breview != null)
                return true;
            else
                return false;
        }
        public void AddServiceReview(SERVICE_REVIEW r)
        {
            var hotelid = new SqlParameter("@HotelID", r.HotelID);
            var stype = new SqlParameter("@SType", r.SType.ToString());
            var rating = new SqlParameter("@Rating", Convert.ToInt32(r.Rating));
            var custid = new SqlParameter("@CID", r.CID);
            var text = new SqlParameter("@Text", r.Text);
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
            context.Database.ExecuteSqlCommand("SP_INSERT_SERVICE_REVIEW @HotelID,@SType,@CID,@Rating,@Text", hotelid, stype, custid,rating,text);
            }

        }
        public bool isSRReviewGiven(SERVICE_REVIEW r)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            var srreview = context.SERVICE_REVIEW.ToList();
            var sreview = srreview.Find((c) => c.CID == r.CID && c.HotelID == r.HotelID && c.SType == r.SType);
            if (sreview != null)
                return true;
            else
                return false;
        }
    }
}
