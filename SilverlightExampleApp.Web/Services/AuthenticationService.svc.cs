using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Security;

namespace SilverlightExampleApp.Web.Services
{
    [ServiceContract(Namespace = "")]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AuthenticationService
    {
        [OperationContract]
        public bool Authenticate(string username, string password)
        {
            if (ValidateLogin(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return true;
            }
            return false;
        }

        [OperationContract]
        public bool LogOut()
        {
            FormsAuthentication.SignOut();   
            return true;
        }

        public bool ValidateLogin(string username, string password)
        {
            return username == "stevenh" && password == "password";
        }
    }
}
