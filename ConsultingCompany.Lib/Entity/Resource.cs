using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsultingCompany.Lib
{
    public enum ResourceType
    {
        ProjectManager,
        Architect,
        Developer,
        QA
    }

    public class Resource
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [StringLength(30, ErrorMessage = "Name can be no larger than 30 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(30, ErrorMessage = "Name can be no larger than 30 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Position")]
        public ResourceType Type { get; set; }

        [Required(ErrorMessage = "Please enter years of experience")]
        [Display(Name = "Years Of Experience")]
        public int YearsofExperience { get; set; }

       

    }
}
