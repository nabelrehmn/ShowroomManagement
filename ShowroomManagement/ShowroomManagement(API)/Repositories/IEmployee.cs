using ShowroomManagement_API_.DTOs;

namespace ShowroomManagement_API_.Repositories
{
    public interface IEmployee
    {
        public Task<ResponseDTO> AddEmployee(EmployeeDTO EmployeeDTO);
    }
}
