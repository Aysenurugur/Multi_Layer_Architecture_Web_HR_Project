using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetCompanyById(Guid id);
        Task CreateCompany(Company company);
        Task UpdateCompany(Company company);
        Task<bool> DeactivateCompany(Guid companyId);
    }
}
