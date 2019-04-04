# ThridPartyLogin-AspNetCore
[![Build Status](https://dev.azure.com/PomeloButter/ThridPartyLogin-AspNetCore/_apis/build/status/ThridPartyLogin-AspNetCore-ASP.NET%20Core-CI?branchName=master&jobName=Agent%20job%201)](https://dev.azure.com/PomeloButter/ThridPartyLogin-AspNetCore/_build/latest?definitionId=17&branchName=master)

新手练习项目，算是入门.NetCore的小菜鸟，重在学习技术，非常感谢@Seven大佬，学习到了不少知识

Usage
------
第一步：在Startup.cs配置

```csharp
  //先注入HttpContextAccessor
 services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
 
            services.AddWeChatLogin(p =>
            {
                p.ClientId = "";
                p.ClientSecret = "";
            });
            services.AddQqLogin(p =>
            {
                p.ClientId = "";
                p.ClientSecret = "";
            });
            services.AddSinaLogin(p =>
            {
                p.ClientId = "";
                p.ClientSecret = "";
            });
            services.AddFackbookLogin(p =>
            {
                p.ClientId = "";
                p.ClientSecret = "";
            });
```


第二步：添加Controllers/OAuthController.cs
```csharp
public class OAuthController : Controller
    {
        private readonly IFacebookLogin _facebookLogin;
        private readonly IQqLogin _qqLogin;
        private readonly ISinaLogin _sinaLogin;
        private readonly IWeChatLogin _weChatLogin;

        public OAuthController(IWeChatLogin weChatLogin, IQqLogin qqLogin, ISinaLogin sinaLogin,
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
    }
```

第三步：添加5个空页面,页面里不要有代码
```
1，Views/OAuth/QQ.cshtml

2，Views/OAuth/Facebook.cshtml

3，Views/OAuth/Wechat.cshtml

4，Views/OAuth/Webo.cshtml

5，Views/OAuth/Facebook.cshtml
```
源码中SampleMVC里有示例
