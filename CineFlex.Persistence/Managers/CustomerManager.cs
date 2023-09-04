﻿using CineFlex.Application.Interfaces.Managers;
using CineFlex.Application.Interfaces.Repositories;
using CineFlex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Managers
{
    public class CustomerManager : BaseManager<Customer>, ICustomerManager
    {
        ICustomerRepository _customerRep;

        public CustomerManager(ICustomerRepository customerRep) : base(customerRep)
        {
            _customerRep = customerRep;
        }

        //-----//-----//

        


        //Privates Methods
        








    }
}