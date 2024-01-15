using Microsoft.EntityFrameworkCore;
using ShowroomManagement_API_.Data;
using ShowroomManagement_API_.DTOs;
using ShowroomManagement_API_.Repositories;
using System.ComponentModel.DataAnnotations;

namespace ShowroomManagement_API_.Models
{
    public class DepartmentModel : IDepartment
    {
        private readonly ApplicationDbContext Db_Context;
        public DepartmentModel(ApplicationDbContext DbContext)
        {
            this.Db_Context = DbContext;
        }
        public async Task<ResponseDTO> GetDepartments()
        {
            var Response = new ResponseDTO();

            try
            {
                Response.Response = await Db_Context.Departments.ToListAsync();
            }
            catch (Exception ex)
            {
                Response.ErrorMessage = ex.Message;
            }

            return Response;
        }
    }
}