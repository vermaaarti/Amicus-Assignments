
namespace AADTask.Models
{
    public class AllEmployee
    {
        public int EmployeMasterId { get; set; }

        public int EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public string? Email { get; set; }

        public string? employeeemail { get; set; }

        public string? ManagerName { get; set; }

        public string? Department { get; set; }

        public string? PerformanceRating { get; set; }

        public string? PlannerName { get; set; }

        /*public enum PerformanceRating
        {
            Poor,
            Satisfactory,
            Good,
            Excellent
        }*/

    }
   /* public enum PerformanceRating
    {
        Poor,
        Satisfactory,
        Good,
        Excellent
    }*/
}
