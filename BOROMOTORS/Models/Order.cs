using System;
using System.ComponentModel.DataAnnotations;

namespace BOROMOTORS.Models.Admin
{
    public class Order
    {
       


        [Required]
        public string UserId { get; set; } // За връзка с потребителя

        [Required]
        public string BikeModel { get; set; } // Име на мотора

        [Required]
        public decimal Price { get; set; } // Цена на поръчката

        public string Status { get; set; } = "Обработва се"; // Статус на поръчката

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
