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
    
    public partial class ROOM
    {
        public ROOM()
        {
            this.ROOM_REVIEW = new HashSet<ROOM_REVIEW>();
        }
    
        public int HotelID { get; set; }
        public int RoomNo { get; set; }
        public string RType { get; set; }
        public Nullable<int> Price { get; set; }
        public string Description { get; set; }
        public Nullable<int> Floor { get; set; }
        public Nullable<int> Capacity { get; set; }
    
        public virtual DISCOUNTED_ROOM DISCOUNTED_ROOM { get; set; }
        public virtual HOTEL HOTEL { get; set; }
        public virtual ICollection<ROOM_REVIEW> ROOM_REVIEW { get; set; }
    }
}