//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Väderapplikation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NewWeather
    {
        public int ID { get; set; }
        public string place { get; set; }
        public Nullable<decimal> longitude { get; set; }
        public Nullable<decimal> latitude { get; set; }
        public Nullable<System.DateTime> day1day { get; set; }
        public Nullable<decimal> day1temp { get; set; }
        public Nullable<System.DateTime> day2day { get; set; }
        public Nullable<decimal> day2temp { get; set; }
        public Nullable<System.DateTime> day3day { get; set; }
        public Nullable<decimal> day3temp { get; set; }
        public Nullable<System.DateTime> day4day { get; set; }
        public Nullable<decimal> day4temp { get; set; }
        public Nullable<System.DateTime> day5day { get; set; }
        public Nullable<decimal> day5temp { get; set; }
       
        public int owner { get; set; }
    
        public virtual NewUser NewUser { get; set; }
    }
}
