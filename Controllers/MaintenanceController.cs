using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TenantsApi.Models;

namespace TenantsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        public readonly TenantContext _context;

        public MaintenanceController(TenantContext context) => _context = context;

        // GET: api/Maintenance
        [HttpGet]
        public ActionResult<IEnumerable<Maintenance>> GetMaintenanceIssues()
        {
            return _context.MaintenanceDetails;
        }

        // GET: api/Maintenance/5
        [HttpGet("{id}")]
        public ActionResult<Maintenance> GetMaintenanceDetails(int id)
        {
            var maintenanceDetails = _context.MaintenanceDetails.Find(id);
            if (maintenanceDetails == null)
            {
                return NotFound();
            }
            return maintenanceDetails;
        }

        // POST: api/Maintenance
        [HttpPost]
        public ActionResult<Maintenance> PostMaintenanceDetails([FromBody] Maintenance maintenance)
        {
            _context.MaintenanceDetails.Add(maintenance);
            _context.SaveChanges();

            return CreatedAtAction("PostMaintenanceDetails", new Maintenance { Id = maintenance.Id }, maintenance);
        }

        // PUT: api/Maintenance/5
        [HttpPut("{id}")]
        public ActionResult PutMaintenanceDetails(int id, Maintenance maintenance)
        {
            if (id != maintenance.Id)
            {
                return BadRequest();
            }
            _context.Entry(maintenance).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Maintenance/5
        [HttpDelete("{id}")]
        public ActionResult<Maintenance> DeleteMaintenanceDetails(int id)
        {
            var maintenanceDetails = _context.MaintenanceDetails.Find(id);

            if (maintenanceDetails == null)
            {
                return NotFound();
            }

            _context.MaintenanceDetails.Remove(maintenanceDetails);
            _context.SaveChanges();

            return maintenanceDetails;
        }
    }
}
