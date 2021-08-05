using Business.KpsPublic;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public abstract class BaseCustomerService:ICustomerService
    {
        private ICustomerDal _customerDal;
       
        public BaseCustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public virtual bool Create(Customer customer)
        {
                _customerDal.Add(customer);
                return true;
        }

        public virtual bool Update(Customer customer)
        {
            _customerDal.Update(customer);
            return true;
        }
        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
        }
        public List<Customer> GetAllCustomers()
        {
            return _customerDal.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerDal.GetById(id);
        }
    }
}
