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
using ThridPartyLogin_AspNetCore.Common;
using ThridPartyLogin_AspNetCore.IService;

namespace MvcSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeChatLogin _weChatLogin;
        private readonly IQqLogin _qqLogin;
        private readonly ISinaLogin _sinaLogin;
        private readonly IFacebookLogin _facebookLogin;

        public HomeController(IWeChatLogin weChatLogin, IQqLogin qqLogin,ISinaLogin sinaLogin,IFacebookLogin facebookLogin)
        {
            this._weChatLogin = weChatLogin;
            this._qqLogin = qqLogin;
            this._sinaLogin = sinaLogin;
            this._facebookLogin = facebookLogin;
        }

        public IActionResult Index()
        {
            var res= _weChatLogin.Authorize();
            if (res != null && res.Code == Code.Success)
            {
                //成功的处理逻辑
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
