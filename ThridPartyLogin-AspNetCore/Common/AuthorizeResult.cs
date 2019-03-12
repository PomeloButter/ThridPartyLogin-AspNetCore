﻿using Newtonsoft.Json.Linq;

namespace ThridPartyLogin_AspNetCore.Common
{
    public class AuthorizeResult
    {
        public Code Code { get; set; }

        public string Error { get; set; }

        public JObject Result { get; set; }

        public string Token { get; set; }
     
    }

    public enum Code
    {
        Success,
        Exception,
        UserInfoErrorMsg,
        AccesstokenErrorMsg
    }
}