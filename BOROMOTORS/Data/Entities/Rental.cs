using System;
using System.ComponentModel.DataAnnotations;

namespace BOROMOTORS.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public int MotorId { get; set; }

        [Required]
        public string? CustomerName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }
    }
}
