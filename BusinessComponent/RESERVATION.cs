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
    
    public partial class RESERVATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RESERVATION()
        {
            this.ROOM_RESERVATION = new HashSet<ROOM_RESERVATION>();
        }
    
        public int InvoiceNo { get; set; }
        public Nullable<int> CID { get; set; }
        public Nullable<int> CNumber { get; set; }
        public Nullable<System.DateTime> RDate { get; set; }
    
        public virtual CREDIT_CARD CREDIT_CARD { get; set; }
        public virtual CUSTOMER CUSTOMER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROOM_RESERVATION> ROOM_RESERVATION { get; set; }
    }
}