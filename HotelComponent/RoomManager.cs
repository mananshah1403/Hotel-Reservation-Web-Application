using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelComponent
{
    public class RoomManager
    {
        private static System.Data.Entity.SqlServer.SqlProviderServices instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        public List<string> GetRoomTypes(int HotelID)
        {
            var hotelID = new SqlParameter("@HotelID", HotelID);
            List<string> roomEntity = new List<string>();
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                roomEntity = context.Database
                .SqlQuery<string>("SP_GET_ROOM_TYPES @HotelID", hotelID)
                .ToList();
            }
            return roomEntity;
        }

        public List<ROOM> GetRoomDetails(string ChkInDate, string ChkOutDate, int HotelID)
        {
            var chkInDate = new SqlParameter("@CheckInDate", Convert.ToDateTime(ChkInDate));
            var chkOutDate = new SqlParameter("@CheckOutDate", Convert.ToDateTime(ChkOutDate));
            var hotelID = new SqlParameter("@HotelID", HotelID);
            List<ROOM> roomEntity = new List<ROOM>();
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                roomEntity = context.Database
                .SqlQuery<ROOM>("SP_GET_ROOM_DETAILS @CheckInDate, @CheckOutDate, @HotelID", chkInDate, chkOutDate, hotelID).ToList();
            }
            return roomEntity;
        }

        public List<ROOM> isRoomDiscount(List<ROOM> rooms,int hotelid)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
         
            var discountedRooms = context.DISCOUNTED_ROOM.ToList().FindAll((c) => c.HotelID == hotelid);
            for(int i=0;i<discountedRooms.Count;i++)
            {
                for(int j=0;j<rooms.Count;j++)
                {
                    if(discountedRooms[i].RoomNo == rooms[j].RoomNo)
                    {
                        double? discountFactor = (Convert.ToDouble(discountedRooms[i].Discount) / 100);
                        double? discountedPrice = rooms[j].Price * discountFactor;
                        rooms[j].Price = rooms[j].Price - Convert.ToInt32(discountedPrice);
                    }
                }
            }
            return rooms;

        }
    }
    
}
