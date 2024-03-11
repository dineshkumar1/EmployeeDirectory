using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL {
    public class EmployeeDB(DbContextOptions<EmployeeDB> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
