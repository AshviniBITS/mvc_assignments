using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFDBFirstDemoExample.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public string AvailabilityStatus { get; set; }
        public Nullable<long> CategoryId { get; set; }
        public Nullable<long> BrandId { get; set; }
        public Nullable<bool> Active { get; set; }
         
        /// 
        /// </summary>

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}