using System.ComponentModel.DataAnnotations;

namespace Vista.web.Data
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

        public List<WorkshopStaff>? Staff { get; set; }
    }
}
