using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmacyCommon.Entities
{
    public class Pharmacy
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
