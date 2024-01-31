using ShowroomManagement_API_.Data;
using ShowroomManagement_API_.Repositories;

namespace ShowroomManagement_API_.Models
{
    public class EmployeeModel : IEmployee
    {
        private readonly ApplicationDbContext DB_Context;
        public EmployeeModel(ApplicationDbContext DBContext)
        {
            this.DB_Context = DBContext;
        }
    }
}
