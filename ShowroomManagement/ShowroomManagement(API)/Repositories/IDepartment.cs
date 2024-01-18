using ShowroomManagement_API_.DTOs;

namespace ShowroomManagement_API_.Repositories
{
    public interface IDepartment
    {
        public Task<ResponseDTO> GetDepartments();

        public Task<ResponseDTO> AddDepartment(DepartmentDTO DepartmentDTO);
    }
}



