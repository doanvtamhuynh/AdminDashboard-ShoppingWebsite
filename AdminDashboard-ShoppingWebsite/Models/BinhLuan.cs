//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminDashboard_ShoppingWebsite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BinhLuan
    {
        public int commentID { get; set; }
        public int userID { get; set; }
        public int sanphamID { get; set; }
        public string noidung { get; set; }
    
        public virtual SanPham SanPham { get; set; }
        public virtual User User { get; set; }
    }
}