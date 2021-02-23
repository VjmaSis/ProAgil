using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProAgil.Domen.Identity
{
    public class User : IdentityUser<int>
    {
        [StringLength(150)]
        public string FullName { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
