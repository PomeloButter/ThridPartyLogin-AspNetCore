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
        private readonly IGitHubLogin _gitHubLogin;
        public HomeController(IWeChatLogin weChatLogin, IQqLogin qqLogin, ISinaLogin sinaLogin,
            IFacebookLogin facebookLogin, IGitHubLogin gitHubLogin)
        {
            _weChatLogin = weChatLogin;
            _qqLogin = qqLogin;
            _sinaLogin = sinaLogin;
            _facebookLogin = facebookLogin;
            _gitHubLogin = gitHubLogin;
        }

        public IActionResult QQ()
        {
            var res = _qqLogin.Authorize();
            if (res != null && res?.Code == Code.Success)
            {
                //成功逻辑
            }

            return View();
        }

        public IActionResult Facebook()
        {
            var res = _facebookLogin.Authorize();
            if (res != null && res?.Code == Code.Success)
            {
                //成功逻辑
            }
            return View();
        }

        public IActionResult WeChat()
        {
            var res = _weChatLogin.Authorize();
            if (res != null && res?.Code == Code.Success)
            {
                //成功逻辑
            }
            return View();
        }

        public IActionResult WeiBo()
        {
            var res = _sinaLogin.Authorize();
            if (res != null && res?.Code == Code.Success)
            {
                //成功逻辑
            }
            return View();
        }

        public IActionResult GitHub()
        {
            var res = _gitHubLogin.Authorize();
            if (res!=null&&res?.Code==Code.Success)
            {
                //成功逻辑
                return Content(res.Result.ToString());
            }           
            return View();
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