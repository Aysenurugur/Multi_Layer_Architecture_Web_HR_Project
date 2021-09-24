using Core.AbstractUnitOfWork;
using Core.Entities;
using Core.Models;
using Core.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    class AdminService : IAdminService
    {
        Admin admin;
        IUnitOfWork unitOfWork;
        public AdminService(IOptions<Admin> options, IUnitOfWork unitOfWork)
        {
            this.admin = options.Value;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AdminLoginAsync(string email, string password)
        {
            if (email == admin.Email && password == admin.Password) { return await Task.FromResult(true); } //admin giriş yapmış ise API DE YAP BURAYI
            return await Task.FromResult(false);
        }
        public bool SetCompanyStatus(Guid companyId, bool status)
        {
            Company company = unitOfWork.Company.GetByIDAsync(companyId);
            company.IsActive = status;
            return unitOfWork.Company.Update(company);
        }
    }
}
