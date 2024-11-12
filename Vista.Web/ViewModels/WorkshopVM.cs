using System.ComponentModel.DataAnnotations;

namespace Vista.Web.ViewModels
{
    public class WorkshopVM
    {
        public int WorkshopId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateAndTime { get; set; }

        [Required]
        public string CategoryCode { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string? BookingRef { get; set; }
    }
}
