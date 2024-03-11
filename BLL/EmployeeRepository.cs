using DLL;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class EmployeeRepository : IEmployeeRepository {

        private readonly EmployeeDB employeeDB;

        public EmployeeRepository(EmployeeDB employeeDB) {
            this.employeeDB = employeeDB;
        }

        public async Task<IEnumerable<Employee>> GetEmployees() {
                return await employeeDB.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int employeeId) {
            return await employeeDB.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public async Task<Employee> AddEmployee(Employee employee) {
                var result = await employeeDB.Employees.AddAsync(employee);
                await employeeDB.SaveChangesAsync();
                return result.Entity;
        }

        public async Task<Employee?> UpdateEmployee(Employee employee) {
            var result = await employeeDB.Employees
                .FirstOrDefaultAsync(e => e.Id == employee.Id);

            if (result != null) {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                await employeeDB.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async void DeleteEmployee(int employeeId) {
            var result = await employeeDB.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId);
            if (result != null) {
                employeeDB.Employees.Remove(result);
                await employeeDB.SaveChangesAsync();
            }
        }
    }
}
