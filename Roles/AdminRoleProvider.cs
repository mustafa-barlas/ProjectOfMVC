
using DataAccessLayer.Concrete;
using System.Linq;

namespace MvcProjeKampii.Roles

{
    public class AdminRoleProvider // : RoleProvider
    {
        public  string[] GetRolesForUser(string userName)
        {
            Context c = new Context();
            var x = c.Admins.FirstOrDefault(y => y.AdminUserName == userName);
            return new string[] { x.AdminRole };
            {
              // x.AdminRole
            }
        }
    }
}
