//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelComponent
{
    using System;
    using System.Collections.Generic;
    
    public partial class RRESV_SERVICE
    {
        public string SType { get; set; }
        public int HotelID { get; set; }
        public int RoomNo { get; set; }
        public System.DateTime CheckInDate { get; set; }
    
        public virtual ROOM_RESERVATION ROOM_RESERVATION { get; set; }
        public virtual SERVICE SERVICE { get; set; }
    }
}