using System.ComponentModel.DataAnnotations;

namespace MicroIhale.UI.ViewModel
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage ="UserName is Required")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "FirstName is Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Buyer is Required")]
        [Display(Name = "Is Buyer")]
        public bool IsBuyer { get; set; }
        [Required(ErrorMessage = "Seller is Required")]
        [Display(Name = "Is Seller")]
        public bool IsSeller { get; set; }

        public int UserSelectTypeId { get; set; }
    }
}
