using Microsoft.AspNetCore.Http;
using ThridPartyLogin_AspNetCore.Entity;

namespace ThridPartyLogin_AspNetCore.Service
{
    public class LoginBase
    {
        private const string Code = "code";
        protected static CredentialSetting Credential;
        protected readonly HttpContext HttpContext;

        protected LoginBase(IHttpContextAccessor contextAccessor)
        {
            HttpContext = contextAccessor.HttpContext;
        }

        protected string AuthorizeCode
        {
            get
            {
                var result = HttpContext.Request.Query[Code].ToString();

                return !string.IsNullOrEmpty(result) ? result : string.Empty;
            }
        }

        protected string RedirectUri =>
            $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.Path.Value}";
    }
}