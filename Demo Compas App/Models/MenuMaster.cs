//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo_Compas_App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MenuMaster
    {
        public MenuMaster()
        {
            this.RoleMappMasters = new HashSet<RoleMappMaster>();
        }
    
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public Nullable<bool> MenuStatus { get; set; }
        public string MenuController { get; set; }
    
        public virtual ICollection<RoleMappMaster> RoleMappMasters { get; set; }
    }
}
