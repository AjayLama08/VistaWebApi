using System.ComponentModel.DataAnnotations;
using Vista.Web.Data.Vista.Web.Data;


namespace Vista.Web.Data
{
    public class Staff
    {
        public Staff()
        {
        }
        public Staff(int staffId, string lastName, string firstName)
        {
            StaffId = staffId;
            LastName = lastName;
            FirstName = firstName;
        }
        public int StaffId { get; set; }

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        //Placeholder for List of Workshops (many side of one-to-many)
        public List<WorkshopStaff>? Workshops { get; set; }
    }
}
