using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain.Models
{
    public class Employee : BaseUser
    {
        public DateTime BirthDate { get; set; }


        public Employee()
        {
            Role = Enums.UserRole.Employee;
        }
    }
}