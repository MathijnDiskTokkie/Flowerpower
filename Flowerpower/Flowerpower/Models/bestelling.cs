//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Flowerpower.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class bestelling
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bestelling()
        {
            this.winkelmand = new HashSet<winkelmand>();
        }
    
        public int bestellingid { get; set; }
        public Nullable<int> winkelcode { get; set; }
        public Nullable<int> afgehandelddoor { get; set; }
        public Nullable<System.DateTime> bestellinggeplaatst { get; set; }
        public int klant_klantid { get; set; }
        public int winkel_winkelcode { get; set; }
    
        public virtual klant klant { get; set; }
        public virtual medewerkers medewerkers { get; set; }
        public virtual winkel winkel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<winkelmand> winkelmand { get; set; }
    }
}
