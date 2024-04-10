using FinanceManagement.DataContext;
using FinanceManagement.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace FinanceManagement.DataAccess
{
    public class UsersDLL
    {
        
        UserDbContext userDbContext = new UserDbContext();
        public string saveUpdateUser(UserModel user)
        {
            using (SqlConnection con = new SqlConnection(userDbContext.connectionString()))
            {
                try
                {
                    con.Open();
                    SqlParameter param;
                    SqlCommand cmd = new SqlCommand("sp_Add_User", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", user.user_id);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    param = cmd.Parameters.Add("@msg", SqlDbType.NVarChar, 50);
                    param.Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    param = cmd.Parameters["@msg"];
                    user.msg = param.SqlValue.ToString();
                    user.isSuccess= true;
                }
                catch (Exception ex)
                {
                    user.isSuccess = false;
                    user.msg = ex.Message;
                }
                return user.msg;
            }
        }
        public object SelectEmployee(int user_id)
        {
             string sp = "";
            if(user_id > 0)
            {
                sp = "sp_get_UserById";
            }
            else
            {
                sp = "sp_get_AllUser";
            }

            List<UserModel> lst = new List<UserModel>();
            using SqlConnection con = new SqlConnection(userDbContext.connectionString());
            {
                 DataTable dt = new DataTable();
                 
                try
                {
                    con.Open();
                     SqlCommand cmd = new SqlCommand(sp, con);
                     cmd.CommandType = CommandType.StoredProcedure;
                    if (user_id> 0){
                        cmd.Parameters.AddWithValue("@id", user_id);
                    } 
                    SqlDataReader myReader = cmd.ExecuteReader(); 
                    while (myReader.Read())
                    {
                        UserModel model = new UserModel();
                        model.user_id = myReader.GetInt32(0);
                        model.Name = myReader.GetString(1);
                        model.Email = myReader.GetString(2);
                        model.Password = myReader.GetString(3);
                        lst.Add(model); 
                    }
                }
                catch (Exception ex)
                {
                   
                }
                
            };
            return lst;
        }
    }
}
