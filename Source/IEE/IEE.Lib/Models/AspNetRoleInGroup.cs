//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IEE.Lib.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetRoleInGroup
    {
        public int GroupId { get; set; }
        public string RoleId { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual AspNetGroupUser AspNetGroupUser { get; set; }
        public virtual AspNetRole AspNetRole { get; set; }
    }
}
