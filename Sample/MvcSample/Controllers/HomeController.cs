using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcSample.Models;
using Newtonsoft.Json;
using ThridPartyLogin_AspNetCore;
using ThridPartyLogin_AspNetCore.IService;

namespace MvcSample.Controllers
{
    public class HomeController : Controller
    {
        private IWeChatLogin _weChatLogin;
        private IQqLogin _qqLogin;
        public HomeController(IWeChatLogin weChatLogin, IQqLogin qqLogin)
        {
            this._weChatLogin = weChatLogin;
            this._qqLogin = qqLogin;
        }

        public IActionResult Index()
        {
            var res= _weChatLogin.Authorize();
            var ress = _qqLogin.Authorize();
            if (res != null && res.Code == 0)
            {
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
            }
            return View();
        }
        RedirectResult RedirectToLogin(object _entity)
        {
            var OAuthResult = JsonConvert.SerializeObject(_entity);

            // 跳转的页面，union参数后面是编码后的用户数据
            var url = "/login?union=" + WebUtility.UrlEncode(OAuthResult);

            return Redirect(url);
        }
        public IActionResult Privacy()
        {
          
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
