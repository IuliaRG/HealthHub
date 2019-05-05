using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalCommon.Entities
{
   public class Salon
    {
        [Key]
        public int SalonId { get; set; }

        public string Number { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
