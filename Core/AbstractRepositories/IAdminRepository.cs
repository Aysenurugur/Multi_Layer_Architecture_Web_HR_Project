using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AbstractRepositories
{
    public interface IAdminRepository
    {
        Task<bool> ActivateCompany(int companyID);
    }
}
