﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfSBIFS.MVVM.Model
{
    public class LoginJson : IJson
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
