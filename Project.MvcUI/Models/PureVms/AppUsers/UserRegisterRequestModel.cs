namespace Project.MvcUI.Models.PureVms.AppUsers
{
    public class UserRegisterRequestModel
    {

        //TODO: Client-side validation eklenmeli
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
