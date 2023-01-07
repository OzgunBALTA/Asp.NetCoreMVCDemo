﻿using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserDetailsDto : UserBase, IDto
    {
        public int UserId { get; set; }
        public string Claim { get; set; }
    }
}
