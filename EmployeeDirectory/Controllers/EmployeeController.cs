using BLL;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace EmployeeDirectory.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {

        private readonly IEmployeeRepository EmployeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.EmployeeRepository = employeeRepository;
        }


        [HttpGet]
        [SwaggerOperation("GetEmployee")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public Task<IEnumerable<Employee>> Get() {
            return  EmployeeRepository.GetEmployees();
        }


        [HttpPost]
        [SwaggerOperation("AddEmployee")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public Task<Employee> Post(Employee employee) {
            return EmployeeRepository.AddEmployee(employee);
        }

        [HttpPut]
        [SwaggerOperation("UpdateEmployee")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public Task<Employee> Put(Employee employee) {
            return EmployeeRepository.UpdateEmployee(employee);
        }

        [HttpGet("{id}")]
        [SwaggerOperation("GetEmployeeById")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public Task<Employee> Get(int employeeId) {
            return EmployeeRepository.GetEmployee(employeeId);
        }

        [HttpDelete]
        [SwaggerOperation("DeleteEmployee")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public void Delete(int employeeId) {
            EmployeeRepository.DeleteEmployee(employeeId);
        }

    }
}
