using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponent
{
    public class HotelManager
    {
        private static System.Data.Entity.SqlServer.SqlProviderServices instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        public List<HOTEL> GetHotels()
        {
            var country = new SqlParameter("@Country", 'C');
            var state = new SqlParameter("@State", 'S');
            List<HOTEL> hotelEntity = new List<HOTEL>();
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                hotelEntity = context.Database
                .SqlQuery<HOTEL>("SP_GET_HOTEL @Country, @State", country, state)
                .ToList();
            }
            return hotelEntity;
        }

        public List<string> GetCountries()
        {
            List<string> country = new List<string>();
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                country = context.Database
                .SqlQuery<string>("SP_GET_COUNTRIES")
                .ToList();
            }
            return country;
        }
        public void Register(CUSTOMER c)
        {

            var CID = new SqlParameter("@CustID", 0);
            CID.SqlDbType = System.Data.SqlDbType.Int;
            CID.Direction = System.Data.ParameterDirection.Output;
            var firstname = new SqlParameter("@FName", c.FirstName);
            var lastname = new SqlParameter("@LName", c.LastName);
            var middlename = new SqlParameter("@MName", c.MiddleName);
            var email = new SqlParameter("@Email", c.Email);
            var Address = new SqlParameter("@Address", c.Address);
            var PhoneNo = new SqlParameter("@PhoneNo", c.Phone_No);
            var Password = new SqlParameter("@Password", c.Password);
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                var customers = context.Database.ExecuteSqlCommand("SP_INSERT_CUSTOMER_RECORD @FName,@MName,@LName,@Address,@PhoneNo,@Email,@Password,@CustID OUT", firstname, middlename, lastname, Address, PhoneNo, email, Password, CID);
            }
        }
        public CUSTOMER isValidUser(String email, String pass)
        {
            List<CUSTOMER> cust = new List<CUSTOMER>();
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            foreach (var c in context.CUSTOMERs.ToList())
            {
                cust.Add(c);
            }
            context.Dispose();
            var customer = cust.Find((c) => c.Email == email && c.Password == pass);
            return customer;
        }

        public void Update(CUSTOMER item)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            context.CUSTOMERs.Attach(item);
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public CUSTOMER getCustomer(int id)
        {
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                var customers = context.CUSTOMERs.ToList();
                var customer = customers.Find((c) => c.CID == id);
                return customer;
            }

        }
        public void UpdateHotel(HOTEL h)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            context.HOTELs.Attach(h);
            context.Entry(h).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void UpdateRooms(ROOM r)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            context.ROOMs.Attach(r);
            context.Entry(r).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void UpdateBreakFasts(BREAKFAST b)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            context.BREAKFASTs.Attach(b);
            context.Entry(b).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void UpdateServices(SERVICE s)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            context.SERVICEs.Attach(s);
            context.Entry(s).State = EntityState.Modified;
            context.SaveChanges();
        }
        public HOTEL getDetails(int id)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            return context.HOTELs.ToList().Find((c) => c.HotelID == id);
        }

        public ROOM getRoom(int id)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            return context.ROOMs.ToList().Find((c) => c.RoomNo == id);
        }
        public BREAKFAST getBreakfast(int id, String type)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            return context.BREAKFASTs.ToList().Find((c) => c.BType == type && c.HotelID == id);
        }
        public SERVICE getService(int id, String type)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            return context.SERVICEs.ToList().Find((c) => c.HotelID == id && c.SType == type);
        }




    }
}
