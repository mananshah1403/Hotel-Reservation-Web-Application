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
    
    public partial class CUSTOMER
    {
        public CUSTOMER()
        {
            this.BREAKFAST_REVIEW = new HashSet<BREAKFAST_REVIEW>();
            this.RESERVATIONs = new HashSet<RESERVATION>();
            this.ROOM_REVIEW = new HashSet<ROOM_REVIEW>();
            this.SERVICE_REVIEW = new HashSet<SERVICE_REVIEW>();
        }
    
        public int CID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Nullable<int> Phone_No { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<BREAKFAST_REVIEW> BREAKFAST_REVIEW { get; set; }
        public virtual ICollection<RESERVATION> RESERVATIONs { get; set; }
        public virtual ICollection<ROOM_REVIEW> ROOM_REVIEW { get; set; }
        public virtual ICollection<SERVICE_REVIEW> SERVICE_REVIEW { get; set; }
    }
}