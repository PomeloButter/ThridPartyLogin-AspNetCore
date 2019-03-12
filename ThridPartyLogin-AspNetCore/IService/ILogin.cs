namespace ThridPartyLogin_AspNetCore
{
    public interface ILogin
    {
        AuthorizeResult Authorize();
    }
}