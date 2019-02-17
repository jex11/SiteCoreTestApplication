using Newtonsoft.Json.Linq;
using RestSharp;
using SiteCoreTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace SiteCoreTestApplication.CustomProvider
{
    public class CustomMembershipProvider : MembershipProvider
    {
        private string localhostURL = ConfigurationManager.AppSettings["ServerURL"];

        public UserDto GetUserByEmail(string email, string password, out bool isSuccess)
        {
            isSuccess = false;
            var client = new RestClient(localhostURL);
            var request = new RestRequest("api/account/login", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                email = email,
                password = password
            });
            var response = client.Execute(request);
            JObject json = JObject.Parse(response.Content);
            var user = !string.IsNullOrEmpty(json["AuthorizedUser"].ToString()) ? new JavaScriptSerializer().Deserialize<UserDto>(json["AuthorizedUser"].ToString()) : null;
            isSuccess = user != null;
            return isSuccess ?  user : null;           
        }

        public UserDto CreateNewUser(string username, string email, string password, out bool isSuccess)
        {
            isSuccess = false;
            var client = new RestClient("http://localhost:51121/");
            var request = new RestRequest("api/account/register", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                username = username,
                email = email,
                password = password
            });
            var response = client.Execute(request);
            JObject json = JObject.Parse(response.Content);
            var user = !string.IsNullOrEmpty(json["AuthorizedUser"].ToString()) ? new JavaScriptSerializer().Deserialize<UserDto>(json["AuthorizedUser"].ToString()) : null;
            isSuccess = user != null;
            return user;
        }

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }          

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        } 

        public override string ApplicationName { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public override int MaxInvalidPasswordAttempts { get { throw new NotImplementedException(); } }

        public override int PasswordAttemptWindow { get { throw new NotImplementedException(); } }

        public override bool RequiresUniqueEmail { get { throw new NotImplementedException(); } }

        public override MembershipPasswordFormat PasswordFormat { get { throw new NotImplementedException(); } }

        public override int MinRequiredPasswordLength { get { throw new NotImplementedException(); } }

        public override int MinRequiredNonAlphanumericCharacters { get { throw new NotImplementedException(); } }

        public override string PasswordStrengthRegularExpression { get { throw new NotImplementedException(); } }

        public override bool EnablePasswordRetrieval { get { throw new NotImplementedException(); } }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {        
            var client = new RestClient(localhostURL);
            var request = new RestRequest("api/account/register", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                username = username,
                email = email,
                password = password
            });
            var response = client.Execute(request);
            JObject json = JObject.Parse(response.Content);
            var user = !string.IsNullOrEmpty(json["AuthorizedUser"].ToString()) ? new JavaScriptSerializer().Deserialize<UserDto>(json["AuthorizedUser"].ToString()) : null;
            status = MembershipCreateStatus.Success;

            return null;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string userEmail, string userPassword)
        {
            return false;
            //var client = new RestClient("http://localhost:51121/");
            //var request = new RestRequest("api/account/", Method.POST);
            //request.RequestFormat = DataFormat.Json;
            //request.AddJsonBody(new
            //{
            //    email = userEmail,
            //    password = userPassword
            //});
            //var response = client.Execute(request);
            //JObject json = JObject.Parse(response.Content);
            //var user = !string.IsNullOrEmpty(json["AuthorizedUser"].ToString()) ? new JavaScriptSerializer().Deserialize<UserDto>(json["AuthorizedUser"].ToString()) : null;
            //return user != null;
        }
    }
}