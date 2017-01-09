using ERP.Common.Entities;
using ERP.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("ERPContextConnection")
        { }

        public DbSet<User> Users { get; set; }
    }
}
