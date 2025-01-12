﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YumBlazorClean.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
