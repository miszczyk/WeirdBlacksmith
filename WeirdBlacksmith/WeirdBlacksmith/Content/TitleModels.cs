//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeirdBlacksmith.Content
{
    using System;
    using System.Collections.Generic;
    
    public partial class TitleModels
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TitleModels()
        {
            this.WeaponsModels = new HashSet<WeaponsModels>();
        }
    
        public int Id { get; set; }
        public string OwnedBy { get; set; }
        public string Title { get; set; }
        public string CurrentUserRole { get; set; }
        public int WeaponsCount { get; set; }
        public string AspNetUsersId { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WeaponsModels> WeaponsModels { get; set; }
    }
}