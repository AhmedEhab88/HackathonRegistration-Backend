using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistrationDbContext
{
    public class HackathonRegistrationContext : DbContext
    {
        public HackathonRegistrationContext(DbContextOptions options) : base(options)
        {
        }
    }
}
