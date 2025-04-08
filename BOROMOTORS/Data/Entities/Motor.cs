namespace BOROMOTORS.Models
{
    public class Motor
    {
        public int Id { get; set; }  // Уникален идентификатор
        public string? Model { get; set; }  // Модел на мотора
        public string? Manufacturer { get; set; }  // Производител
        public string? Type { get; set; }  // Тип на мотора (например: кросов, спортен и т.н.)
        public decimal PricePerDay { get; set; }  // Цена на ден за наем
        public string? Description { get; set; }  // Описание на мотора
        public bool IsAvailable { get; set; }  // Доступен ли е моторът за наем
    }
}