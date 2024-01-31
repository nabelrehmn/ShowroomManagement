﻿using Microsoft.AspNetCore.Mvc;
using ShowroomManagement_API_.Repositories;

namespace ShowroomManagement_API_.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee Service;
        public EmployeeController(IEmployee _Service)
        {
            this.Service = _Service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}