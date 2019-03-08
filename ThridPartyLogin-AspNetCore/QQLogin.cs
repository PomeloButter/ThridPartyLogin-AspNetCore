using Microsoft.AspNetCore.Http;

namespace ThridPartyLogin_AspNetCore
{
    public class QqLogin:LoginBase,ILogin
    {
        public QqLogin(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
        }
        public AuthorizeResult Authorize()
        {
            throw new System.NotImplementedException();
        }


    }
}