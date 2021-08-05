using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class StarbuckCustomerManager : BaseCustomerService
    {
       
        private IIdentityCheckService _identityCheckService;
        private ICustomerDal _customerDal;

        public StarbuckCustomerManager(ICustomerDal customerDal, IIdentityCheckService identityCheckService) : base(customerDal)
        {
            _identityCheckService = identityCheckService;
            _customerDal = customerDal;
        }

        public override bool Create(Customer customer)
        {
            if (_identityCheckService.CheckIdentityPerson(customer))
            {
                if (!_customerDal.GetAll(p => p.IdentityNumber == customer.IdentityNumber).Any())
                {
                    return base.Create(customer);
                }
            }
            return false;
        }

        public override bool Update(Customer customer)
        {
            if (_identityCheckService.CheckIdentityPerson(customer))
            {
                if (!_customerDal.GetAll(p => p.IdentityNumber == customer.IdentityNumber).Any())
                {
                    return base.Update(customer);
                }
            }
            return false;
        }
    }
}
