using System.ComponentModel.DataAnnotations;

namespace Vista.Api.Data
{
    public class Trainer
    {
        public int TrainerId { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(50)]
        public required string Location { get; set; }

        public List<TrainerCategory>? TrainerCategories { get; set; }

        public List<Session>? Sessions { get; set; }

    }
}
