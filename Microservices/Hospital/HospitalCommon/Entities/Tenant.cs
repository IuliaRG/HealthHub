using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalCommon.Entities
{
    public class Tenant
    {
        public int TenantId { get; set; }

        public string DatabaseName { get; set; }

        public ICollection<User> Users { get; } = new List<User>();
    }
}
