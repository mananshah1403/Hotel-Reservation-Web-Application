using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelComponent
{
    public class ServiceManager
    {
        private static System.Data.Entity.SqlServer.SqlProviderServices instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        public List<SERVICE> GetServices(int HotelID)
        {
            var hotelID = new SqlParameter("@HotelID", HotelID);
            List<SERVICE> serviceEntity = new List<SERVICE>();
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                serviceEntity = context.Database
                .SqlQuery<SERVICE>("SP_GET_SERVICE @HotelID", hotelID)
                .ToList();
            }
            return serviceEntity;
        }
    }
}
