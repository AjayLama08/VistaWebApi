using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace Vista.Web.Data
{
    namespace Vista.Web.Data
    {
        public class WorkshopStaff
        {
            public WorkshopStaff()
            {
            }
            public WorkshopStaff(int workshopId, int staffId)
            {
                WorkshopId = workshopId;
                StaffId = staffId;
            }
            public int WorkshopId { get; set; }
            [ValidateNever]
            public Workshop? Workshop { get; set; }
            public int StaffId { get; set; }
            [ValidateNever]
            public Staff? Staff { get; set; }
        }

    }
}