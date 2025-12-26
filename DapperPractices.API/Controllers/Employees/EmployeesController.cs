using Dapper;
using DapperPractices.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperPractices.API.Controllers.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public EmployeesController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDetailsOfAll()
        {
            var sql = "SELECT EmployeeId, FirstName FROM Employees";

            using var connection = _context.CreateConnection();
            var data = await connection.QueryAsync(sql);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailsById(int id)
        {
            var sql = "SELECT EmployeeId, FirstName FROM Employees WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            var data = await connection.QuerySingleOrDefaultAsync(sql, new { Id = id });

            return Ok(data);
        }
    }
}
