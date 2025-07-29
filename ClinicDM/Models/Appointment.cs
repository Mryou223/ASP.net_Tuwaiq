using ClinicDM.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ClinicDM.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime appointmentDate { get; set; }

        public  DateTime CreatedDate { get; set; }

        public int patientId { get; set; }

        public int DoctorId { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        public AppointmentVM ToAppointmentVM()
        {
            return new AppointmentVM
            {
                Id = Id,
                appointmentDate = appointmentDate,
                patientId = patientId,
                DoctorId = DoctorId,
                DoctorName = Doctor?.Name ?? "Unknown",
                RawStatus = Status
                
            };
        }
    }
}
