using System.ComponentModel.DataAnnotations;

namespace Vista.Api.Data
{
    public class TrainerCategory
    {
        // Has a composite (compound) key that is defined in the TrainersDbConext

        [Required]
        public int TrainerId { get; set; }

        [MaxLength(15)]
        public required string CategoryCode { get; set; }

        public Trainer? Trainer { get; set; }

        public Category? Category { get; set; }
        // See TrainersDbConext for Foreign Key (Fluent API) definition

    }
}
