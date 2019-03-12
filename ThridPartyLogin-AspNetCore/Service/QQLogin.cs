using Microsoft.AspNetCore.Http;
using ThridPartyLogin_AspNetCore.Common;
using ThridPartyLogin_AspNetCore.IService;

namespace ThridPartyLogin_AspNetCore.Service
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