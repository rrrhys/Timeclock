//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class entry
    {
        public System.DateTime time_from { get; set; }
        public System.DateTime time_to { get; set; }
        public decimal hours { get; set; }
        public System.Guid job_number_id { get; set; }
        public System.Guid work_type_id { get; set; }
        public string comments { get; set; }
        public System.Guid user_id { get; set; }
        public System.Guid id { get; set; }
    }
}
