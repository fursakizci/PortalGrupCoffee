using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager :BaseCustomerService
    {

        public CustomerManager(ICustomerDal customerDal) : base(customerDal)
        {
        }
       
    }
}
