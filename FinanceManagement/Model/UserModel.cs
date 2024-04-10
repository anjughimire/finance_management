using FinanceManagement.Common;

namespace FinanceManagement.Model
{
    public class UserModel : ResponseModel
    {
        public int user_id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
