using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class PortalCoffeeCustomerManager : BaseCustomerService
    {
        
        public PortalCoffeeCustomerManager(ICustomerDal customerDal) : base(customerDal)
        {
        }

    }
}
