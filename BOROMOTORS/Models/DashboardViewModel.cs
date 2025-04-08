using System;

namespace BOROMOTORS.Models
{
    public class DashboardViewModel
    {
        public int TotalBikes { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal CheapestBike { get; set; }
        public string TopManufacturer { get; set; }
    }
}