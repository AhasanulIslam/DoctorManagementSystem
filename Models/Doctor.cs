using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorManagement.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Qualification { get; set; }
        public string JobPlace { get; set; }
        public string Designation { get; set; }
        public string Field { get; set; }


        public ICollection<Appointment> Appointment { get; set; }

          public int? PatientId { get; set; }
        [ForeignKey("PatientId")]

        public Patient Patient { get; set; }

    }
}
   