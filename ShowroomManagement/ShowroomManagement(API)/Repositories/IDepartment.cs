using ShowroomManagement_API_.DTOs;

namespace ShowroomManagement_API_.Repositories
{
    public interface IDepartment
    {
        public Task<ResponseDTO> GetDepartments();

        public Task<ResponseDTO> AddDepartment(DepartmentDTO DepartmentDTO);

        public Task<ResponseDTO> DeleteDepartment(int ID);

        public Task<ResponseDTO> UpdateDepartment(DepartmentDTO DepartmentDTO);
    }
}

