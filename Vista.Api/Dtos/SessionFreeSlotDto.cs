using System.ComponentModel.DataAnnotations;

namespace Vista.Api.Dtos
{
    public class SessionFreeSlotDto
    {
        public int SessionId { get; set; }
        public int TrainerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime SessionDate { get; set; }
        public string TrainerName { get; set; } = null!;
    }
}
