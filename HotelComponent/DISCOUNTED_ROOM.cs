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
    
    public partial class DISCOUNTED_ROOM
    {
        public int HotelID { get; set; }
        public int RoomNo { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual ROOM ROOM { get; set; }
    }
}
