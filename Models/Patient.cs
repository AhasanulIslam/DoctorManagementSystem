using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoctorManagement.Models
{
    public class Patient
    {
        [Key]
        public int  PatientId { get; set; }
        public string PatientName { get; set; }
        public string Password { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }


        public ICollection<Doctor> Doctor { get; set; }
        public ICollection<Appointment> Appointment { get; set; }

        

    }
}