using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class InputDetailContext:DbContext
        
    {
        public InputDetailContext(DbContextOptions<InputDetailContext> options):base(options)
        {

        }
        public DbSet<InputDetail> InputDetails { get; set; }
    }
}
