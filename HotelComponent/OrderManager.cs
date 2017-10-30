using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelComponent
{
    public class OrderManager
    {
        private static System.Data.Entity.SqlServer.SqlProviderServices instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        public ROOM getSelectedRoom(int hotelID, int roomNo)
        {
            var HotelID = new SqlParameter("@HotelID", hotelID);
            var RoomNo = new SqlParameter("@RoomNo", roomNo);
            ROOM roomEntity = new ROOM();
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                roomEntity = context.Database
                .SqlQuery<ROOM>("SP_GET_SELECTED_ROOM @HotelID, @RoomNo", HotelID, RoomNo).First();
            }
            return roomEntity;
        }
    }
}
