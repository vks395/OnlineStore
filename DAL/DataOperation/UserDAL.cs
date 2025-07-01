using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.DataOperation
{
    public class UserDAL
    {
        private readonly OnlineStoreDbEntities dbEntities;
        public UserDAL() { 
            this.dbEntities = new OnlineStoreDbEntities();
        }
        public List<Role> GetAllroles()
        {
            return dbEntities.Roles.ToList();
        }
    
        public List<GetAllUsers_Result> getAllUser()
        {

            return dbEntities.GetAllUsers().ToList();
        }
        public User getUserLogin(User user)
        {
            return dbEntities.Users.Where(m=>m.UserId==user.UserId && m.Password==user.Password).FirstOrDefault();
        }
        public GetAllUsers_Result getUserByUserId(string userId)
        {
            return dbEntities.GetAllUsers().Where(m=>m.UserId== userId).FirstOrDefault();
        }
        public bool existingUser(string userId)
        {
            var records= dbEntities.Users.Where(m => m.UserId == userId).FirstOrDefault();
            if(records==null) return false;
            return true;
        }
        public string createUser(User user) { 
            if(!existingUser(user.UserId)) {
                dbEntities.Users.Add(user); //New user Data saving

                UserRole ur = new UserRole();
                ur.UserId = user.UserId;
                ur.RoleId = user.RoleId;
                dbEntities.UserRoles.Add(ur); //role Mapping
                dbEntities.SaveChanges();
                return "New User Added successfully !";
            }
            else
            {
                return "User Already Exist !";
            }
        }

        public string updateUser(User user)
        {
            if (existingUser(user.UserId))
            {
                User objuser = new User();
                var old = dbEntities.Users.Find(user.UserId);
                objuser.UserId = user.UserId;
                objuser.UserName = user.UserName;
                objuser.RoleId = user.RoleId;
                objuser.Password = user.Password;
                dbEntities.Entry(old).State = EntityState.Detached;
                dbEntities.Entry(objuser).State = EntityState.Modified;

                //UserRole ur = new UserRole();
                //var checkExistRole = dbEntities.UserRoles.Where(m => m.UserId == user.UserId && m.RoleId == user.RoleId).FirstOrDefault();
                //if(checkExistRole==null)
                //{

                //}


                dbEntities.SaveChanges();
                return "User Updated successfully !";
            }
            else
            {
                return "User Not Found !";
            }
        }
        public string DeleteUser(string UserId)
        {
            if (existingUser(UserId))
            {
                var records = dbEntities.Users.Where(m => m.UserId ==UserId).FirstOrDefault();
                dbEntities.Users.Remove(records);
                var recordsUR = dbEntities.UserRoles.Where(m => m.UserId == UserId).ToList();
                dbEntities.UserRoles.RemoveRange(recordsUR);
                dbEntities.SaveChanges();
                return "User deleted successfully !";
            }
            else
            {
                return "User Not Found !";
            }
        }
    }
}
