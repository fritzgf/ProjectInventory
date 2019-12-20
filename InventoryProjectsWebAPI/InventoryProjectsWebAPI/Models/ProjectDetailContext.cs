using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryProjectsWebAPI.Models
{
    public class ProjectDetailContext : DbContext
    {
        public ProjectDetailContext(DbContextOptions<ProjectDetailContext> options) : base(options)
        {

        }

        public DbSet<ProjectDetail> ProjectDetails { get; set; }
    }
}
