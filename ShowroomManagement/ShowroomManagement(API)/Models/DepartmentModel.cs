﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<ResponseDTO> AddDepartment(DepartmentDTO DepartmentDTO)
        {
            var Response = new ResponseDTO();

            try
            {
                var Department = new Department() {
                    Name = DepartmentDTO.Name,
                    Description = DepartmentDTO.Description
                };

                await Db_Context.Departments.AddAsync(Department);
                await Db_Context.SaveChangesAsync();

                return Response.Response = "Department Created Successfully";
            }
            catch (Exception ex)
            {
                Response.ErrorMessage = ex.Message;
            }

            return Response;
        }

        public async Task<ResponseDTO> DeleteDepartment(int ID)
        {
            var Response = new ResponseDTO();

            try
            {
                var Data = await Db_Context.Departments.Where(x => x.Id == ID).FirstOrDefaultAsync();
                if (Data != null)
                {
                    Db_Context.Departments.Remove(Data);
                    await Db_Context.SaveChangesAsync();
                }
                Response.Response = "Department Deleted Successfully";
            }
            catch(Exception ex)
            {
                Response.ErrorMessage = ex.Message;
            }

            return Response;
        }

        public async Task<ResponseDTO> GetDepartmentById(int ID)
        {
            var Response = new ResponseDTO();

            try
            {
                var Department = await Db_Context.Departments.Where(x => x.Id == ID).FirstOrDefaultAsync();
                if (Department == null) {
                    Response.StatusCode = 404;
                }
                else
                {
                    Response.Response = Department;
                }
            }
            catch(Exception ex)
            {
                Response.ErrorMessage = ex.Message;
            }

            return Response;
        }

        public async Task<ResponseDTO> UpdateDepartment(DepartmentDTO DepartmentDTO)
        {
            var Response = new ResponseDTO();

            try
            {
                var Record = await Db_Context.Departments.Where(x => x.Id == DepartmentDTO.ID).FirstOrDefaultAsync();
                
                if (Record != null)
                {
                    Record.Name = DepartmentDTO.Name;
                    Record.Description = DepartmentDTO.Description;

                    Db_Context.Departments.Update(Record);
                    await Db_Context.SaveChangesAsync();
                }

                return Response.Response = "Department has been updated";
            }
            catch (Exception ex)
            {
                Response.ErrorMessage = ex.Message;
            }

            return Response;
        }

    }
}



