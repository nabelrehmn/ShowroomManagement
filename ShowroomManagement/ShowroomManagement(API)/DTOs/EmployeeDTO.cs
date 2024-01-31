namespace ShowroomManagement_API_.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string ProfileImagePath { get; set; }
        public int DepartmentId { get; set; }
    }
}
