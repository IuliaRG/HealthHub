using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalCommon.Entities
{
   public class UserInTenant
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int TenantId { get; set; }

        public Tenant Tenant { get; set; }
    }
}
