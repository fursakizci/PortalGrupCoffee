using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal compnayDal)
        {
            _companyDal = compnayDal;
        }
        public Company GetById(int id)
        {
           return _companyDal.GetById(id);
        }
    }
}
