﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }

        public bool IsVarified { get; set; }
        public List<string>? Roles { get; set; }
        public string? JwtToken { get; set; }


    }
}

