using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Testing.Models
{
    public class DonorInfo
    {
        #region Data

        [Key]
        [Display(Name = "ID")]
        public string DonorID { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [Display(Name = "Full name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "NIC is required")]
        [Display(Name = "NIC / Passport")]
        public string NIC { get; set; }

        [Display(Name = "Change Authentication")]
        public bool UseAuthentication { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        [Display(Name = "Contact Number")]
        [RegularExpression(@"^(\+?\d{8,15})$", ErrorMessage = "Invalid Contact Number. Please enter a valid phone number in the format +[country code][phone number] or [phone number] with no spaces.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Other Phone Number")]
        [RegularExpression(@"^(\+?\d{8,15})$", ErrorMessage = "Invalid Contact Number. Please enter a valid phone number in the format +[country code][phone number] or [phone number] with no spaces.")]
        public string OtherPhoneNumber { get; set; }

        [Display(Name = "Donation Frequency")]
        [Required(ErrorMessage = "Donation frequency is required")]
        public int? DonationFrequency { get; set; }

        [Display(Name = "Occupation")]
        [Required(ErrorMessage = "Marital Status is required")]
        public string Occupation { get; set; }

        [Display(Name = "Marital Status")]
        [Required(ErrorMessage = "Marital Status is required")]
        public string MaritalStatus { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Location")]

        public string Location { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }


        [Display(Name = "Blood Type")]
        public string BloodType { get; set; }


        #endregion

    }
}
