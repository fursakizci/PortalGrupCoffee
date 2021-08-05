using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IIdentityCheckService
    {
        bool CheckIdentityPerson(Customer customer);
    }
}
