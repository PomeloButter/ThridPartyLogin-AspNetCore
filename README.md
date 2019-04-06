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
             services.AddGitHubLogin(p =>
            {
                p.ClientId = "";
                p.ClientSecret = "";
            });
```


第二步：添加Controllers/OAuthController.cs(controller名字根据你自己的业务场景取名，看你心情取名 哈哈哈)
```csharp
public class OAuthController : Controller
    {
         private readonly IFacebookLogin _facebookLogin;
        private readonly IQqLogin _qqLogin;
        private readonly ISinaLogin _sinaLogin;
        private readonly IWeChatLogin _weChatLogin;
        private readonly IGitHubLogin _gitHubLogin;
        public OAuthController(IWeChatLogin weChatLogin, IQqLogin qqLogin, ISinaLogin sinaLogin,
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
              
            }           
            return View();
        }
    }
```

第三步：添加5个空页面,页面里不要有代码,防止方法异常时抛出
```
1，Views/OAuth/QQ.cshtml

2，Views/OAuth/Facebook.cshtml

3，Views/OAuth/Wechat.cshtml

4，Views/OAuth/Webo.cshtml

5，Views/OAuth/GitHub.cshtml
```
<p>回调地址的填写:<p>
例如GitHub:我们是在OAuth/Github方法中调用，那么填写回调地址就是：http://www.xxx.com/OAuth/Github
 
