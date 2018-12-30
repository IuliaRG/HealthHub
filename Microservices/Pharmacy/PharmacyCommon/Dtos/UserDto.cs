using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyCommon.Dtos
{
   public class UserDto
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
