using CertifyMe.Data;
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
        public Guid Add(CompanyInfo companyInfo)
        {
            try
            {
                var company = new Data.Company(companyInfo.OwnerId)
                {
                    Name = companyInfo.Name,
                    Description = companyInfo.Description,
                };
                return company.Id;
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public List<Company> GetAll()
        {
            return Data.Company.Items.Values.ToList();
        }

        public Company GetById(Guid id)
        {
            if (Data.Company.Items.Keys.Contains(id))
            {
                return Data.Company.Items[id];
            }
            return null;
        }

        public List<Company> GetUserCompanies(Guid userId)
        {
            if (Data.User.Items.ContainsKey(userId))
            {
                return Data.User.Items[userId].Companies;
            }
            return null;
        }

        public bool RemoveById(Guid id)
        {
            if (Data.Company.Items.Keys.Contains(id))
            {
                var events = Data.Company.Items[id].Events;
                var eventsRegistrations = Data.EventRegistration.Items.Where(r => events.Contains(r.Value.Event)).ToList();
                //Remove all registations records
                eventsRegistrations.ForEach(r => Data.EventRegistration.Items.Remove(r.Value.Id));
                //Remove all events
                events.ForEach(e => Data.Event.Items.Remove(e.Id));
                //Remove company
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
