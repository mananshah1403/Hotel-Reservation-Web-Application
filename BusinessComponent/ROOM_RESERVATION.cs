//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessComponent
{
    using System;
    using System.Collections.Generic;
    
    public partial class ROOM_RESERVATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROOM_RESERVATION()
        {
            this.RRESV_BREAKFAST = new HashSet<RRESV_BREAKFAST>();
            this.RRESV_SERVICE = new HashSet<RRESV_SERVICE>();
        }
    
        public Nullable<int> InvoiceNo { get; set; }
        public int HotelID { get; set; }
        public int RoomNo { get; set; }
        public System.DateTime CheckInDate { get; set; }
        public Nullable<System.DateTime> CheckOutDate { get; set; }
    
        public virtual RESERVATION RESERVATION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RRESV_BREAKFAST> RRESV_BREAKFAST { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RRESV_SERVICE> RRESV_SERVICE { get; set; }
    }
}
