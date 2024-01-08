﻿using BalkonyDAL.Abstract;
using BalkonyDAL.Concrete.EntityFramework.DataManagement;
using BalkonyEntity.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyDAL.Concrete.EntityFramework
{
    public class EfSupplierRepository : EfRepository<Supplier>,ISupplierRepository
    {
        public EfSupplierRepository(DbContext context) : base(context)
        {
        }
    }
}
