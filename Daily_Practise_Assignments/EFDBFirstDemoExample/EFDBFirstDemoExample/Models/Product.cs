//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFDBFirstDemoExample.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using EFDBFirstDemoExample.CustomValidation;

    public partial class Product
    {
        [Required(ErrorMessage ="Product name cant be empty")]
        public long ProductId { get; set; }
        [Required(ErrorMessage = "ProductId cant be empty")]
        [RegularExpression(@"^[A-Za-z]*$",ErrorMessage ="Alphabets Only")]
        [MaxLength(20,ErrorMessage="Product name should be max 20 character long")]
        public string ProductName { get; set; }
        [DivisibilityBy10(ErrorMessage ="Price should be multiple of 10")]
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public string AvailabilityStatus { get; set; }
        [Required(ErrorMessage = "Category id cant be empty")]
        public Nullable<long> CategoryId { get; set; }
        [Required(ErrorMessage = "Product name cant be empty")]
        public Nullable<long> BrandId { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Photo { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}
