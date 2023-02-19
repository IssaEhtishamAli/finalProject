using Microsoft.EntityFrameworkCore;
using skillServices.BOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillServices.DAL.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<UsersRegBOL> userReg { get; set; }
        public DbSet<UserType> usertype { get; set; }
    }
}
