using System.ComponentModel.DataAnnotations;

namespace ShowroomManagement_API_.Data
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}