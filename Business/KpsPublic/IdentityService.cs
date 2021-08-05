using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Entities;
using IdentityInquiry;

namespace Business.KpsPublic
{
    public class IdentityService:IIdentityCheckService
    {
        public bool CheckIdentityPerson(Customer customer)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

            return client.TCKimlikNoDogrulaAsync(Convert.ToInt64(customer.IdentityNumber), customer.FirstName, customer.LastName, Convert.ToInt32(customer.DateOfBirth.Year))
                .Result.Body.TCKimlikNoDogrulaResult;
        }
    }
}
