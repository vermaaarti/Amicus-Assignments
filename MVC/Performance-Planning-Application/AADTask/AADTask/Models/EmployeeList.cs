namespace AADTask.Models
{
   
    public class EmployeeList
    {
        public int EmployeeId { get; set; }
        // public int DepartmentId { get; set; }
        // public int SalaryInformatonId { get; set; }



        public string? EmployeeName { get; set; }

        public string? Email { get; set; }

        public string? ManagerName { get; set; }

        public string? Department { get; set; }

        public string? PerformanceRating { get; set; }

        public string? PlannerName { get; set; }
        public int IsDeleted { get; set; }
        public int IsModified { get; set; }

      

    }

  /*   public enum PerformanceRating
    {
        Poor,
        Satisfactory,
        Good,
        Excellent
    }*/

}