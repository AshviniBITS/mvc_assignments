using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomValidationAssignment.CustomValidation;

namespace CustomValidationAssignment.Models
{
    [HobbiesValidation(ErrorMessage="At least 1 and max 4 hobbies should be selected")]
    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
        public string Mobile { get; set; }
        public bool Photography { get; set; }
        public bool Gardening { get; set; }
        public bool Dance { get; set; }
        public bool Hiking { get; set; }
        public bool Painting { get; set; }
    }
}