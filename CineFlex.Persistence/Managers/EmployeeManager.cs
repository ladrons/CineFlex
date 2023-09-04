using CineFlex.Application.Interfaces.Managers;
using CineFlex.Application.Interfaces.Repositories;
using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Managers
{
    public class EmployeeManager : BaseManager<Employee>, IEmployeeManager
    {
        IEmployeeRepository _employeeRep;

        public EmployeeManager(IEmployeeRepository employeeRep) : base(employeeRep)
        {
            _employeeRep = employeeRep;
        }
    }
}