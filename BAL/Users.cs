using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public class Users
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string RoleName { get; set; }
    }
}
