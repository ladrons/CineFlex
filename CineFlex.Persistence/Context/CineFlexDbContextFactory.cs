using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Context
{
    public class CineFlexDbContextFactory : DesignTimeDbContextFactory<CineFlexDbContext>
    {
        protected override CineFlexDbContext CreateNewInstance(DbContextOptions<CineFlexDbContext> options)
        {
            return new CineFlexDbContext(options);
        }
    }
}