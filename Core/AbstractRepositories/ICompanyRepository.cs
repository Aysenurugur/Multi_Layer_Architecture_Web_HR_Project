using Core.AbstractRepositories.Generic;
using Core.Entities;
using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.AbstractRepositories
{
    public interface ICompanyRepository : ICrudRepository<Company>
    {
    }
}
