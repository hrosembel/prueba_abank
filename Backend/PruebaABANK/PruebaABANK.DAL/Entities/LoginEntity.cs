﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaABANK.DAL.Entities
{
    public class LoginEntity
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
