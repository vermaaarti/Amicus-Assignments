namespace MVCAssignment2.Models
{
    public class DetailedInformation
    {

        public DetailedInformation(EmployeeInfo employeeInfo, OfficeInfo officeInfo) {
            EmployeeInfo = employeeInfo;
            OfficeInfo = officeInfo;
        }

        public EmployeeInfo EmployeeInfo { get; set; }

        public OfficeInfo OfficeInfo { get; set; }
    }
}
