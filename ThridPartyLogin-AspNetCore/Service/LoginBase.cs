using Microsoft.AspNetCore.Http;
using ThridPartyLogin_AspNetCore.Common;

namespace ThridPartyLogin_AspNetCore.Service
{
    public class LoginBase
    {
        public readonly HttpContext HttpContext;
        public static CredentialSetting Credential;
        private const string Code = "code";
        public LoginBase(IHttpContextAccessor contextAccessor)
        {
            HttpContext = contextAccessor.HttpContext;
        }
        protected string AuthorizeCode
        {
            get
            {
                var result = HttpContext.Request.Query[Code].ToString();

                if (!string.IsNullOrEmpty(result)) return result;

                return string.Empty;
            }
        }
        protected string RedirectUri => $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}+{HttpContext.Request.Path.Value}";
    }
}