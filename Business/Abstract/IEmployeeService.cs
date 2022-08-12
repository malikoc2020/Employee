﻿using Business.DTO;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IQueryable<Employee> EmployeesAsQueryable();
        ReturnObjectDTO GetEmployee(int id);
        List<EmployeeDTO> GetAllEmployees();
        ReturnObjectDTO AddEmployee(EmployeeDTO employee);
        ReturnObjectDTO UpdateEmployee(int id, EmployeeDTO employee, string updatedBy = "");
        ReturnObjectDTO SoftDeleteEmployee(int id, EmployeeDTO employee, string updatedBy = "");
        ReturnObjectDTO HardDeleteEmployee(int id, string updatedBy = "");
    }
}
