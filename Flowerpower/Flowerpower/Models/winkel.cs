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
    
    public partial class winkel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public winkel()
        {
            this.bestelling = new HashSet<bestelling>();
            this.medewerkers = new HashSet<medewerkers>();
        }
    
        public int winkelcode { get; set; }
        public string winkelnaam { get; set; }
        public string winkelstraatnaam { get; set; }
        public string winkelpostcode { get; set; }
        public string winkelstad { get; set; }
        public Nullable<int> winkeltelefoonnummer { get; set; }
        public string winkelmail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bestelling> bestelling { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<medewerkers> medewerkers { get; set; }
    }
}
