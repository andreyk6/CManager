using CertifyMe.Service.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CertifyMe.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CompanyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CompanyService.svc or CompanyService.svc.cs at the Solution Explorer and start debugging.
    public class CompanyService : ICompanyService
    {
        public Guid Add(Company company)
        {
            if (Data.Company.Items.Keys.Contains(company.Id))
            {
                return Guid.Empty;
            }

            try
            {
                var companyModel = new Data.Company(company.OwnerId)
                {
                    Name = company.Name,
                    Description = company.Description,
                };
                return companyModel.Id;
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public List<Company> GetAll()
        {
            return Data.Company.Items.Values.Select(c => c.ToCompanyContract()).ToList();
        }

        public Company GetById(Guid id)
        {
            if (Data.Company.Items.Keys.Contains(id))
            {
                return Data.Company.Items[id].ToCompanyContract();
            }
            return null;
        }

        public List<Company> GetUserCompanies(Guid userId)
        {
            if (Data.Company.Items.Keys.Contains(userId))
            {
                return Data.User.Items[userId].Companies.Select(c => c.ToCompanyContract()).ToList();
            }
            return null;
        }

        public bool RemoveById(Guid id)
        {
            if (Data.Company.Items.Keys.Contains(id))
            {
                return Data.Company.Items.Remove(id);
            }
            return false;
        }

        public bool Update(Company company)
        {
            if (Data.Company.Items.Keys.Contains(company.Id))
            {
                Data.Company.Items[company.Id].Name = company.Name;
                Data.Company.Items[company.Id].Description = company.Description;
                return true;
            }
            return false;
        }
    }
}
