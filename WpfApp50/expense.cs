//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp50
{
    using System;
    using System.Collections.Generic;
    
    public partial class expense
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string pay_method { get; set; }
        public Nullable<int> employee_id { get; set; }
        public System.DateTime date { get; set; }
    
        public virtual employee employee { get; set; }
    }
}
