using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelComponent;
namespace HotelComponent
{
    public class BreakfastManager
    {
        private static System.Data.Entity.SqlServer.SqlProviderServices instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        public List<BREAKFAST> GetBreakfast(int HotelID)
        {
            var hotelID = new SqlParameter("@HotelID", HotelID);
            List<BREAKFAST> brkfstEntity = new List<BREAKFAST>();
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                brkfstEntity = context.Database
                .SqlQuery<BREAKFAST>("SP_GET_BREAKFAST  @HotelID", hotelID).ToList();
            }
            return brkfstEntity;
        }
    }
}
