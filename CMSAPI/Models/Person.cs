using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CMSAPI.Models
{
    public class Person : IdentityUser
    {
        public string Picture { get; set; }
        public string Joined { get; set; }

        public Project Project { get; set; }
    }

}
