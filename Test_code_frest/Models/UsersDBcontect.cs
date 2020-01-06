using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test_code_frest.Models
{
    public class UsersDBcontect : DbContext
    {
        public UsersDBcontect(): base("DBCS")
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<TapleReseetpassword> TapleReseetpassword { get; set; }
    }
}