using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MvcSample.Models;
using Newtonsoft.Json;
using ThridPartyLogin_AspNetCore.Common;
using ThridPartyLogin_AspNetCore.IService;

namespace MvcSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFacebookLogin _facebookLogin;
        private readonly IQqLogin _qqLogin;
        private readonly ISinaLogin _sinaLogin;
        private readonly IWeChatLogin _weChatLogin;

        public HomeController(IWeChatLogin weChatLogin, IQqLogin qqLogin, ISinaLogin sinaLogin,
            IFacebookLogin facebookLogin)
        {
            _weChatLogin = weChatLogin;
            _qqLogin = qqLogin;
            _sinaLogin = sinaLogin;
            _facebookLogin = facebookLogin;
        }

        public IActionResult QQ()
        {

            var res = _qqLogin.Authorize();
            if (res != null && res.Code == 0)
            {
                return RedirectToLogin(new
                {
                    channel = "qq",
                    code = 0,
                    user = new
                    {
                        uid = res.Result.Value<string>("openid"),
                        name = res.Result.Value<string>("nickname"),
                        img = res.Result.Value<string>("figureurl"),
                        token = res.Token
                    }
                });
            }

            return View();
        }

        public IActionResult Facebook()
        {
            var res = _facebookLogin.Authorize();
            if (res != null && res.Code == 0)
            {
                return RedirectToLogin(new
                {
                    channel = "facebook",
                    code = 0,
                    user = new
                    {
                        uid = res.Result.Value<string>("id"),
                        name = res.Result.Value<string>("name"),
                        img = res.Result["picture"]["data"].Value<string>("url"),
                        token = res.Token
                    }
                });
               
            }
            return View();
        }

        public IActionResult WeChat()
        {
            var res = _weChatLogin.Authorize();
            if (res != null && res.Code == Code.Success)
                return RedirectToLogin(new
                {
                    channel = "wechat",
                    code = 0,
                    user = new
                    {
                        uid = res.Result.Value<string>("uid"),
                        name = res.Result.Value<string>("nickname"),
                        img = res.Result.Value<string>("headimgurl"),
                        token = res.Token
                    }
                });
            return View();
        }
        public IActionResult WeiBo()
        {
            var res = _sinaLogin.Authorize();
            if (res != null && res.Code == Code.Success)
                return RedirectToLogin(new
                {
                    channel = "wechat",
                    code = 0,
                    user = new
                    {
                        uid = res.Result.Value<string>("uid"),
                        name = res.Result.Value<string>("nickname"),
                        img = res.Result.Value<string>("headimgurl"),
                        token = res.Token
                    }
                });
            return View();
        }
        private RedirectResult RedirectToLogin(object entity)
        {
            var oAuthResult = JsonConvert.SerializeObject(entity);

            // 跳转的页面，union参数后面是编码后的用户数据
            var url = "/login?union=" + WebUtility.UrlEncode(oAuthResult);

            return Redirect(url);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}