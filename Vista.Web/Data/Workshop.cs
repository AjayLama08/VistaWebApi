using System.ComponentModel.DataAnnotations;
using Vista.Web.Data.Vista.Web.Data;

namespace Vista.Web.Data
{
    public class Workshop
    {
        public Workshop()
        {
        }
        public Workshop(int workshopId, string name, DateTime dateAndTime)
        {
            WorkshopId = workshopId;
            Name = name;
            DateAndTime = dateAndTime;
        }
        public int WorkshopId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public DateTime DateAndTime { get; set; }
        [Required]
        public string CategoryCode { get; set; } = string.Empty;
        public string? BookingRef { get; set; }

        // Placeholder for List of Staff (many side of one-to-many)
        public List<WorkshopStaff>? Staff { get; set; }
    }
}
