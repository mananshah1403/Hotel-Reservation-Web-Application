using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelComponent
{
    public class AdminManager
    {
        private static System.Data.Entity.SqlServer.SqlProviderServices instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        public List<BestCustomer> GetBBestCustomer(DateTime SDate, DateTime EDate)
        {
            
            List<BestCustomer> bestCustomerEntity = new List<BestCustomer>();
            var Sdate = new SqlParameter("@StartDate", SDate);
            var Edate = new SqlParameter("@EndDate", EDate);
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                bestCustomerEntity = context.Database
                .SqlQuery<BestCustomer>("SP_GET_TOP5_CUSTOMERS  @StartDate,@EndDate",Sdate,Edate ).ToList();
            }
            return bestCustomerEntity;
        }

        public List<BestBreakfast> GetBestBreakfast(DateTime SDate, DateTime EDate)
        {

            List<BestBreakfast> bestBreakfast = new List<BestBreakfast>();
            var Sdate = new SqlParameter("@StartDate", SDate);
            var Edate = new SqlParameter("@EndDate", EDate);
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                // DataTable dt = new DataTable();
                bestBreakfast = context.Database
                .SqlQuery<BestBreakfast>("SP_GET_TOP_BREAKFASTS  @StartDate,@EndDate", Sdate, Edate).ToList();
            }
            return bestBreakfast;
        }

        public List<BestService> GetService(DateTime SDate, DateTime EDate)
        {

            List<BestService> bestServices = new List<BestService>();
            var Sdate = new SqlParameter("@StartDate", SDate);
            var Edate = new SqlParameter("@EndDate", EDate);
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                bestServices = context.Database
                .SqlQuery<BestService>("SP_GET_TOP_SERVICES  @StartDate,@EndDate", Sdate, Edate).ToList();
            }
            return bestServices;
        }

        public List<BestRoomType> GetBestRoomType(DateTime SDate, DateTime EDate)
        {

            List<BestRoomType> bestRTpes = new List<BestRoomType>();
            var Sdate = new SqlParameter("@StartDate", SDate);
            var Edate = new SqlParameter("@EndDate", EDate);
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                bestRTpes = context.Database
                .SqlQuery<BestRoomType>("SP_GET_TOP_ROOMS  @StartDate,@EndDate", Sdate, Edate).ToList();
            }
            return bestRTpes;
        }
    }
}
