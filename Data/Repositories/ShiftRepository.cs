﻿using Core.AbstractRepositories;
using Core.Entities;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    class ShiftRepository : CrudRepository<Shift> , IShiftRepository
    {
        public ShiftRepository(ProjectIdentityDbContext context) : base(context)
        {
            
        }
        private ProjectIdentityDbContext DbContext
        {
            get { return context as ProjectIdentityDbContext; }
        }
        

    }
}
