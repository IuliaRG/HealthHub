﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HospitalCommon.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string UserName { get; set; }

        public string LastName { get; set; }
        
        public string Address { get; set; }

        public string City { get; set; }

        public ICollection<Tenant> Tenants { get; } = new List<Tenant>();
    }
}
