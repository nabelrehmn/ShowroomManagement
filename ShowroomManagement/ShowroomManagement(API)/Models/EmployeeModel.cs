using ShowroomManagement_API_.Data;
using ShowroomManagement_API_.DTOs;
using ShowroomManagement_API_.Repositories;
using System.IO;
using System.Net;

namespace ShowroomManagement_API_.Models
{
    public class EmployeeModel : IEmployee
    {
        private readonly ApplicationDbContext DB_Context;
        private IWebHostEnvironment _WebHostEnvironment;
        public EmployeeModel(ApplicationDbContext DBContext,IWebHostEnvironment WebHostEnvironment)
        {
            this.DB_Context = DBContext;
            this._WebHostEnvironment = WebHostEnvironment;
        }

        public async Task<ResponseDTO> AddEmployee(EmployeeDTO EmployeeDTO)
        {
            var Response = new ResponseDTO();

            try
            {
                string path = null;
                if (EmployeeDTO.ProfileImage != null)
                {
                    var FileName = EmployeeDTO.ProfileImage.FileName;
                    path = Path.Combine(_WebHostEnvironment.WebRootPath,"Uploads");
                    using (Stream stream = new FileStream(path,FileMode.Create)) 
                    {
                        await EmployeeDTO.ProfileImage.CopyToAsync(stream);
                    }
                }

                var Employee = new Employee()
                {
                    Name = EmployeeDTO.Name,
                    CNIC = EmployeeDTO.CNIC,
                    Email = EmployeeDTO.Email,
                    Address = EmployeeDTO.Address,
                    ContactNumber = EmployeeDTO.ContactNumber,
                    DepartmentId = EmployeeDTO.DepartmentId,
                    ProfileImagePath = path
                };

                await DB_Context.Employees.AddAsync(Employee);
                await DB_Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Response.Response = ex.Message;
            }

            return Response;
        }
    }
}






