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
    
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            this.LT_Tour = new HashSet<LT_Tour>();
            this.PacketTours = new HashSet<PacketTour>();
            this.Pictures = new HashSet<Picture>();
            this.NgonNgus = new HashSet<NgonNgu>();
        }
    
        public string MaTour { get; set; }
        public string TenTour { get; set; }
        public string DiaDiem { get; set; }
        public string MoTa { get; set; }
        public string TTVC { get; set; }
        public Nullable<bool> forsale { get; set; }
        public string BannerUrl { get; set; }
        public string MaDT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LT_Tour> LT_Tour { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PacketTour> PacketTours { get; set; }
        public virtual Partner Partner { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture> Pictures { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NgonNgu> NgonNgus { get; set; }
    }
}