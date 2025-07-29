using ClinicDM.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ClinicDM.ViewModels
{
    public class AppointmentVM
    {
        public int Id { get; set; }

        public DateTime appointmentDate { get; set; }

        public int patientId { get; set; }

        public int DoctorId { get; set; }

        public string DoctorName { get; set; } = null!;


        public string RawStatus { get; set; } = null!;

        public string Status =>
            RawStatus == Statuses.Scheduled.ToString() && appointmentDate < DateTime.Now
            ? "Did not show" : RawStatus;




    }
}
