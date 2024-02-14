using ShowroomManagement_API_.DTOs;

namespace ShowroomManagement_API_.Repositories
{
    public interface IEmployee
    {
        public Task<ResponseDTO> AddEmployee(EmployeeDTO EmployeeDTO);
        public Task<ResponseDTO> DeleteEmployee(int ID);
        public Task<ResponseDTO> UpdateEmployee(EmployeeDTO EmployeeDTO);
    }
}
