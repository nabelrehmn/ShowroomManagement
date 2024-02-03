namespace ShowroomManagement_API_.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public IFormFile ProfileImage { get; set; }
        public int DepartmentId { get; set; }
    }
}
