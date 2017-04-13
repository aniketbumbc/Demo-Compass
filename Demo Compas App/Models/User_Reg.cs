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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public partial class User_Reg
    {
        public int UserId { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage ="Can Not Empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Can Not Empty")]
        public string Password { get; set; }
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ComPassword { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Station { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
        public string Loginerror { get; set; }
    }
}
