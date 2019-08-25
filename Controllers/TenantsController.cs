using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TenantsApi.Models;


namespace TenantsApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {

        public readonly TenantContext _context;

        public TenantsController(TenantContext context) => _context = context;

        //GET: /api/tenants
        [HttpGet]
        public ActionResult<IEnumerable<Tenant>> GetTenants()
        {

            return _context.TenantDetails;
        }

        //GET /api/tenants/{id}
        [HttpGet("{id}")]
        public ActionResult<Tenant> GetTenantDetails(int id)
        {
            var tenantDetails = _context.TenantDetails.Find(id);

            if (tenantDetails == null)
            {
                return NotFound();
            }
            return tenantDetails;
        }

        //POST /api/tenants
        [HttpPost]
        public ActionResult<Tenant> PostTenantDetails(Tenant tenant)
        {
            _context.TenantDetails.Add(tenant);
            _context.SaveChanges();

            return CreatedAtAction("PostTenantDetails", new Tenant { Id = tenant.Id }, tenant);
        }

        //PUT /api/tenants/{id}
        [HttpPut("{id}")]
        public ActionResult PutTenantDetails(int id, Tenant tenant)
        {
            if (id != tenant.Id)
            {
                return BadRequest();
            }

            //When you update the object by id, ef does that in the dbContext - needs to be told the resource already exists for put
            _context.Entry(tenant).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //DELETE /api/tenants/{id}

        [HttpDelete("{id}")]
        public ActionResult<Tenant> DeleteTenantDetails(int id)
        {
            var tenantDetails = _context.TenantDetails.Find(id);

            if (tenantDetails == null)
            {
                return NotFound();
            }

            _context.TenantDetails.Remove(tenantDetails);
            _context.SaveChanges();

            return tenantDetails;
        }
    }
}