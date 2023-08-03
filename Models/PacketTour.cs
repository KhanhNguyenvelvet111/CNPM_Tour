//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNPM_Tour.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PacketTour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PacketTour()
        {
            this.PhieuDCs = new HashSet<PhieuDC>();
        }
    
        public string MaPT { get; set; }
        public string TenPT { get; set; }
        public Nullable<int> Duration { get; set; }
        public int SLVoucher { get; set; }
        public bool Preserve { get; set; }
        public Nullable<int> PreserveDays { get; set; }
        public string DKDK { get; set; }
        public bool DoiLich { get; set; }
        public string CSDoiLich { get; set; }
        public Nullable<int> GiaGoc_A { get; set; }
        public Nullable<int> GiaTraveloka_A { get; set; }
        public Nullable<int> GiaGoc_C { get; set; }
        public Nullable<int> GiaTraveloka_C { get; set; }
        public string MaTour { get; set; }
        public string STK_NH { get; set; }
    
        public virtual NgayBan NgayBan { get; set; }
        public virtual Tour Tour { get; set; }
        public virtual TKTT TKTT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDC> PhieuDCs { get; set; }
    }
}
