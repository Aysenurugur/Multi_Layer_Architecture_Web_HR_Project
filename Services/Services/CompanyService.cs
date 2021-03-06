using Core.AbstractUnitOfWork;
using Core.Entities;
using Core.Entities.Identity;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork unitOfWork;

        public CompanyService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task CreateCompany(Company newCompany)
        {
            newCompany.IsActive = true;
            await unitOfWork.Company.AddAsync(newCompany);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await unitOfWork.Company.GetAllAsync();
        }

        public async Task<Company> GetCompanyById(Guid id)
        {
            return await unitOfWork.Company.GetByIDAsync(id);
        }

        public async Task UpdateCompany(Company company)
        {
            unitOfWork.Company.Update(company);
            await unitOfWork.CommitAsync();
        }

        public async Task<bool> DeactivateCompany(Guid companyId)
        {
            Company company = await unitOfWork.Company.GetByIDAsync(companyId);
            company.IsActive = false;
            return await unitOfWork.CommitAsync() > 0;
        }

        public async Task<IEnumerable<User>> GetEmployeesByCompanyId(Guid companyId)
        {
            List<User> employees = unitOfWork.User.List(x => x.CompanyID == companyId).ToList();
            return await Task.FromResult(employees);

        }
        
    }
}
