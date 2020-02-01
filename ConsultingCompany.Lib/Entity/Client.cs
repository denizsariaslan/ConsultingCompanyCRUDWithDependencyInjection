using System.ComponentModel.DataAnnotations;

namespace ConsultingCompany.Lib
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        [StringLength(30, ErrorMessage = "Name can be no larger than 30 characters")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Contact first name is required")]
        [StringLength(30, ErrorMessage = "Name can be no larger than 30 characters")]
        [Display(Name = "Contact First Name")]
        public string ContactFirstName { get; set; }
        [Required(ErrorMessage = "Contact last name is required")]
        [StringLength(30, ErrorMessage = "Name can be no larger than 30 characters")]
        [Display(Name = "Contact Last Name")]
        public string ContactLastName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        //[DisplayFormat(NullDisplayText = "")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Zip code can be numeric")]
        [StringLength(10, ErrorMessage = "Zip code can be no larger than 10 characters")]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }
    }
}