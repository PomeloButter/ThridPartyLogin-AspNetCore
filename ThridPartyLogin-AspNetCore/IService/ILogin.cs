using ThridPartyLogin_AspNetCore.Common;

namespace ThridPartyLogin_AspNetCore.IService
{
    public interface ILogin
    {
        AuthorizeResult Authorize();
    }
}