﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyEntity.DTO.Login
{
    public class LoginDTOResponse
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string Token { get; set; }

    }
}
