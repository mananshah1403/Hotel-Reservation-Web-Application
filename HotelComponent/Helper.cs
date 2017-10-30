using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelComponent
{
    public static class Helper
    {
        static List<RRESV_BREAKFAST> lstRsvBrk;
        static List<RRESV_SERVICE> resSrv;
        static List<BREAKFAST> lstRRBrk;
        static List<int> lstHotelID;
        static List<int> lstRoomNum;
        static List<string> lstcheckInDate;
        static List<string> lstcheckOutDate;

        static Helper()
        {
            lstHotelID = new List<int>();
            lstRoomNum = new List<int>();
            lstcheckInDate = new List<string>();
            lstcheckOutDate = new List<string>();
            lstRsvBrk = new List<RRESV_BREAKFAST>();
            resSrv = new List<RRESV_SERVICE>();
            lstRRBrk = new List<BREAKFAST>();
        }
        public static void AddHotelID(int value)
        {
            lstHotelID.Add(value);
        }
        public static void AddRoomNum(int value)
        {
            lstRoomNum.Add(value);
        }
        public static void AddCheckInDate(string value)
        {
            lstcheckInDate.Add(value);
        }
        public static void AddCheckOutDate(string value)
        {
            lstcheckOutDate.Add(value);
        }
        public static void AddBreakfast(RRESV_BREAKFAST value)
        {
            lstRsvBrk.Add(value);
        }
        public static void AddRRBreakfast(BREAKFAST value)
        {
            lstRRBrk.Add(value);
        }
        public static void AddService(RRESV_SERVICE value)
        {
            resSrv.Add(value);
        }

        public static List<int> GetHotelId()
        {
            return lstHotelID;
        }
        public static List<int> GetRoomNum()
        {
            return lstRoomNum;
        }
        public static List<string> GetCheckInDate()
        {
            return lstcheckInDate;
        }
        public static List<string> GetCheckOutDate()
        {
            return lstcheckOutDate;
        }
        public static List<RRESV_SERVICE> GetService()
        {
            return resSrv;
        }
        public static List<RRESV_BREAKFAST> GetBreakfast()
        {
            return lstRsvBrk;
        }
        public static List<BREAKFAST> GetRRBreakfast()
        {
            return lstRRBrk;
        }
    }
}
