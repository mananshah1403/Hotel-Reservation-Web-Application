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
    
    public partial class ROOM_REVIEW
    {
        public int RID { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
        public Nullable<int> CID { get; set; }
        public Nullable<int> HotelID { get; set; }
        public Nullable<int> RoomNo { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        public virtual ROOM ROOM { get; set; }
    }
}
