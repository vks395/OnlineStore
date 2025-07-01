using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using DAL.DataOperation;
namespace BAL
{
    public class UserBAL
    {
        private readonly UserDAL userDal;
        public UserBAL()
        {
            this.userDal = new UserDAL();
        }
        public List<AllUsers> getAllUser()
        {
            try
            {
                List<AllUsers> allUserList = new List<AllUsers>();
                var getAllUserdata = userDal.getAllUser();
                var records = getAllUserdata.GroupBy(u => u.UserId).Select(group => group.First());
                foreach (var item in records)
                {
                    var RoleList = getAllUserdata.Where(m => m.UserId == item.UserId).Select(m => m.RoleName).ToList();

                    AllUsers allUsers = new AllUsers();
                    allUsers.CreateDate = item.CreateDate;
                    allUsers.UserId = item.UserId;
                    allUsers.UserName = item.UserName;
                    allUsers.RoleId = item.RoleId;
                    allUsers.RoleName = string.Join(" , ", RoleList);
                    allUsers.Password = item.Password;
                    allUserList.Add(allUsers);
                }
                return allUserList;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public AllUsers getUserByUserId(string userId)
        {
            try
            {

                var item = userDal.getUserByUserId(userId);
                AllUsers allUsers = new AllUsers();
                allUsers.CreateDate = item.CreateDate;
                allUsers.UserId = item.UserId;
                allUsers.UserName = item.UserName;
                allUsers.RoleId = item.RoleId;
                allUsers.RoleName = item.RoleName;
                allUsers.Password = item.Password;

                return allUsers;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Role> getAllRole()
        {
            try
            {
                var data = userDal.GetAllroles().Select(m => new Role { RoleId = m.RoleId, RoleName = m.RoleName }).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public User getUserLogin(User user)
        {
            try
            {
                return userDal.getUserLogin(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool existingUser(string userId)
        {
            return userDal.existingUser(userId);
        }
        public string createUser(User user)
        {
            try
            {
                return userDal.createUser(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string updateUser(User user)
        {
            try
            {
                return userDal.updateUser(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string DeleteUser(string UserId)
        {

            try
            {
                return userDal.DeleteUser(UserId);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
