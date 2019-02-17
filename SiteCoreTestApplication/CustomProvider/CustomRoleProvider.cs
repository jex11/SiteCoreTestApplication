using Newtonsoft.Json.Linq;
using RestSharp;
using SiteCoreTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace SiteCoreTestApplication.CustomProvider
{
    public class CustomRoleProvider : RoleProvider
    {
        private string localhostURL = ConfigurationManager.AppSettings["ServerURL"];

        public override string ApplicationName { get; set; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string userName)
        {
            var client = new RestClient(localhostURL);
            var request = new RestRequest("api/account/getrole", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                username = userName
            });
            var response = client.Execute(request);
            JObject json = JObject.Parse(response.Content);
            var user = !string.IsNullOrEmpty(json["AuthorizedUser"].ToString()) ? new JavaScriptSerializer().Deserialize<UserDto>(json["AuthorizedUser"].ToString()) : null;            
            return new string[] { user.UserRoles };
            //List<string> roles = new List<string>();
            //SqlConnection conn = new SqlConnection("Server=tcp:sitecoretest22.database.windows.net,1433;Initial Catalog=SiteCoreTest;Persist Security Info=False;User ID=testjex;Password=aaaa1111?;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //conn.Open();

            //SqlCommand command = new SqlCommand("SELECT r.RoleName FROM [User] u(nolock) INNER JOIN RoleAssignment ra(nolock) ON u.UserID = ra.userID INNER JOIN Roles r(nolock) ON ra.RoleID = r.RoleID WHERE u.UserName = @UserName", conn);
            //command.Parameters.AddWithValue("@UserName", userName);     
            //// int result = command.ExecuteNonQuery();
            //using (SqlDataReader reader = command.ExecuteReader())
            //{
            //    int i = 0;
            //    while(reader.Read())
            //    {
            //        roles.Add(reader.GetValue(i).ToString());
            //        i++;
            //    }
            //}
            //conn.Close();
            //return roles.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}