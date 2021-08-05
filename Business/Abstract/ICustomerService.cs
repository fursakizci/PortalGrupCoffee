using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        bool Create(Customer customer);
        bool Update(Customer customer);
        void Delete(Customer customer);
        List<Customer> GetAllCustomers();
        Customer GetById(int id);
        
    }
}
