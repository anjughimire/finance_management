namespace FinanceManagement.DataContext
{
    public class UserDbContext
    {
        public string connectionString()
        {
            return "Persist Security Info=False;Initial Catalog=Finance_Management_System;Server=.;Trusted_Connection=True;";
        }
    }
  
}
