using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAndRestaurantCheck_EF_Core.Data
{
    public class CafeContext :DbContext
    {
        public CafeContext()
           : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBulder)
        {
            if (!optionsBulder.IsConfigured)
            {
                optionsBulder.UseSqlServer(
                    connectionString: @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = CafeDb; Integrated Security = True;"
                    );
            }
        }
    }
}
