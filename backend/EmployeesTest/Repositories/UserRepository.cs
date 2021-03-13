namespace EmployeesTest.Repositories
{
    using EmployeesTest.Context;
    using EmployeesTest.Models;
    using System.Linq;

    public class UserRepository
    {
        private AppDbContext dbContext;
        public UserRepository(AppDbContext context)
        {
            this.dbContext = context;
        }

        public bool GetDataUser(Users users) 
        {
            bool result = false;
            var user = this.dbContext.Users.FirstOrDefault(x => x.UserName.Equals(users.EmployeeId) && x.Password.Equals(users.Password));
            if (user.EmployeeId > 0) 
            {
                result = true;
            }
            return result;
        }
    }
}
