﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_iViewAdmin_demo
{
    public class JwtSetting
    {
        public  string SecurityKey { get; set; }
        public string Audience { get; set; }
        public  string Issuer { get; set; }
    }
}
