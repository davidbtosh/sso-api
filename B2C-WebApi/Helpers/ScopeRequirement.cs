﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2CWebApi.Helpers
{
    using Microsoft.AspNetCore.Authorization;

    public class ScopeRequirement : IAuthorizationRequirement
    {
        public ScopeRequirement(string scopeType)
        {
            ScopeType = scopeType;
        }
        public string ScopeType { get; set; }
    }
}
