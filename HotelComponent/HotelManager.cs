using HotelComponent;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelComponent
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
        public List<HOTEL> GetHotels(string Country, string State)
        {
            var country = new SqlParameter("@Country", Country);
            var state = new SqlParameter("@State", State);

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

        public void Update1(CUSTOMER item)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            
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
        public void insertHotel(HOTEL h)
        {
            var HotelID = new SqlParameter("@HotelID", 0);
            HotelID.SqlDbType = System.Data.SqlDbType.Int;
            HotelID.Direction = System.Data.ParameterDirection.Output;
            var street = new SqlParameter("@Street",h.Street);
            var country = new SqlParameter("@Country", h.Country);
            var state = new SqlParameter("@State", h.State);
            var zip = new SqlParameter("@Zip", h.Zip);
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                var hotels = context.Database.ExecuteSqlCommand("SP_INSERT_HOTEL_RECORD @Street,@Country,@State,@Zip,@HotelID OUT",street,country,state,zip,HotelID);
            }
        }
        public void insertBreakfast(BREAKFAST b, int id)
        {
            var hotelid = new SqlParameter("@HotelID", id);
            var btype = new SqlParameter("@BType", b.BType);
            var bprice = new SqlParameter("@BPrice", b.BPrice);
            var desc = new SqlParameter("@Description", b.Description);
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                var breakfast = context.Database.ExecuteSqlCommand("SP_INSERT_BREAKFAST_RECORD @HotelID,@BType,@BPrice,@Description", hotelid, btype, bprice, desc);
            }
        }
        public void insertService(SERVICE s, int id)
        {
            var hotelid = new SqlParameter("@HotelID", id);
            var stype = new SqlParameter("@SType", s.SType);
            var sprice = new SqlParameter("@SPrice", s.SPrice);
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                var services = context.Database.ExecuteSqlCommand("SP_INSERT_SERVICE_RECORD @HotelID,@SType,@SPrice", hotelid, stype, sprice);
            }
        }
        public void insertRoom(ROOM r,int id)
        {
            var hotelid = new SqlParameter("@HotelID", id);
            var roomno = new SqlParameter("@RoomNo", r.RoomNo);
            var rtype = new SqlParameter("@RType", r.RType);
            var price = new SqlParameter("@Price", r.Price);
            var desc = new SqlParameter("@Description", r.Description);
            var capacity = new SqlParameter("@Capacity", r.Capacity);
            var floor = new SqlParameter("@Floor", r.Floor);
            using (HotelTransylvaniaEntities context = new HotelTransylvaniaEntities())
            {
                var rooms = context.Database.ExecuteSqlCommand("SP_INSERT_ROOM_RECORD @HotelID,@RoomNo,@RType,@Price,@Description,@Capacity,@Floor", hotelid, roomno, rtype, price, desc, capacity, floor);
            }
        }
        public void insertDiscountRoom(DISCOUNTED_ROOM r,int hid,int roomNo)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            context.DISCOUNTED_ROOM.ToList().RemoveAll((c) => c.HotelID == hid && c.RoomNo == roomNo);
            var hotelid = new SqlParameter("@HotelID", hid);
            var roomno = new SqlParameter("@RoomNo", roomNo);
            var discount = new SqlParameter("@Discount", r.Discount);
            var sdate = new SqlParameter("@StartDate", r.StartDate);
            var edate = new SqlParameter("@EndDate", r.EndDate);
           
            
                var discountrooms = context.Database.ExecuteSqlCommand("SP_INSERT_DISCOUNT_ROOM_RECORD @HotelID,@RoomNo,@Discount,@StartDate,@EndDate", hotelid, roomno, discount, sdate, edate);
            


        }

        public List<ROOM> getDiscountRoom(List<ROOM> rooms, int hotelid)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();

            var discountedRooms = context.DISCOUNTED_ROOM.ToList().FindAll((c) => c.HotelID == hotelid);
            for (int i = 0; i < discountedRooms.Count; i++)
            {
                for (int j = 0; j < rooms.Count; j++)
                {
                    if (discountedRooms[i].RoomNo == rooms[j].RoomNo)
                    {
                        double? discountFactor = (Convert.ToDouble(discountedRooms[i].Discount) / 100);
                        double? discountedPrice = rooms[j].Price * discountFactor;
                        rooms[j].Price = rooms[j].Price - Convert.ToInt32(discountedPrice);
                    }
                }
            }
            return rooms;

        }
        public List<RESERVATION> getReservations(int id)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            List<RESERVATION> reserves = new List<RESERVATION>();
            reserves = context.RESERVATIONs.ToList().FindAll((c) => c.CID == id);
            return reserves;
            

        }

        public List<ROOM_RESERVATION> details(int id)
        {
            HotelTransylvaniaEntities context = new HotelTransylvaniaEntities();
            List<RESERVATION> reserve = new List<RESERVATION>();
            RESERVATION r = new RESERVATION();
            r = context.RESERVATIONs.ToList().Find((c) => c.InvoiceNo == id);
            r.ROOM_RESERVATION = context.ROOM_RESERVATION.ToList().FindAll((c) => c.InvoiceNo == id);
            return r.ROOM_RESERVATION.ToList();
        }

    }
}
