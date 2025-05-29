using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers
{
    public class UserRegisterRequestModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} girilmesi zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} en az {2}, en fazla {1} karakter olmalıdır.")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} girilmesi zorunludur.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} en az {2} karakter olmalıdır.")]
        public string Password { get; set; }

        [Display(Name = "E-posta Adresi")]
        [Required(ErrorMessage = "{0} girilmesi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir {0} adresi giriniz.")]
        public string Email { get; set; }
    }
}
