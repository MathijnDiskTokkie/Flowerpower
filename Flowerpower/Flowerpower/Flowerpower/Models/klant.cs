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
    
    public partial class klant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public klant()
        {
            this.bestelling = new HashSet<bestelling>();
        }
    
        public string naam { get; set; }
        public string achternaam { get; set; }
        public string straatnaam { get; set; }
        public string postcode { get; set; }
        public string tussenvoegsel { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> geboortedatum { get; set; }
        public string woonplaats { get; set; }
        public int klantid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bestelling> bestelling { get; set; }
    }
}