using FinanceManagement.DataAccess;
using FinanceManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagement.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : Controller
    {
        UsersDLL usersDLL = new UsersDLL();

        [HttpPost]
        public object saveUpdateUser([FromBody] UserModel users)
        {
            
            string msg=usersDLL.saveUpdateUser(users);
            return msg;
        }

        [HttpGet("{id}")]
        public object getAllUser( int id)
        {

            return usersDLL.SelectEmployee(id);
        }
        //[HttpGet("{id}")]
        //public object getbyUserId()
        //{
        //    return "";
        //} 

        [HttpDelete]
        public object deleteUser()
        {
            return "";
        }

    }
}
