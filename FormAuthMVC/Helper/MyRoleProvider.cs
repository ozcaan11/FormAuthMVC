using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using FormAuthMVC.Models;

namespace FormAuthMVC.Helper
{
    public class MyRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var roles = new List<string>();

            using (var db = new mydb())
            {
                var user = db.Users.FirstOrDefault(x => x.Username == username);
                if (user?.IsAdmin != null && user.IsAdmin.Value)
                {
                    roles.Add("Admin");
                }
                if (user?.IsVip != null && user.IsVip.Value)
                {
                    roles.Add("Vip");
                }
            }
            return roles.ToArray();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}