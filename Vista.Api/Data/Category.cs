using System.ComponentModel.DataAnnotations;

namespace Vista.Api.Data
{
    public class Category
    {
        [Key]  // Since name (CategoryCode) does not include "Id",
               // we have to use an annotation (could also specify
               // this using FluitAPI) 
        [MaxLength(15)]
        public required string CategoryCode { get; set; }

        [Required]
        [MaxLength(30)]
        public required string CategoryName { get; set; }

        public List<TrainerCategory>? TrainerCategories { get; set; }

    }
}
