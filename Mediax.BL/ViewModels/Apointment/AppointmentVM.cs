using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediax.BL.ViewModels.Apointment
{
    public class AppointmentVM
    {
        [Required, MaxLength(50)]
        public string FullName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required, Phone]
        public string Phone { get; set; } = null!;

        [Required]
        public DateTime AppointmentDate { get; set; }

        [MaxLength(500)]
        public string Message { get; set; } = null!;
    }
}
