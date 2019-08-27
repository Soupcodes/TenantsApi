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
    public class PropertyController : ControllerBase
    {
        public readonly TenantContext _context;

        public PropertyController(TenantContext context) => _context = context;

        // GET: api/Property
        [HttpGet]
        public ActionResult<IEnumerable<Property>> GetProperties()
        {
            return _context.PropertyDetails;
        }

        // GET: api/Property/5
        [HttpGet("{id}")]
        public ActionResult<Property> GetPropertyDetails(int id)
        {
            var propertyDetails = _context.PropertyDetails.Find(id);
            if (propertyDetails == null)
            {
                return NotFound();
            }
            return propertyDetails;
        }

        // POST: api/Property
        [HttpPost]
        public ActionResult<Property> PostPropertyDetails(Property property)
        {
            _context.PropertyDetails.Add(property);
            _context.SaveChanges();

            return CreatedAtAction("PostPropertyDetails", new Property { Id = property.Id }, property);
        }

        // PUT: api/Property/5
        [HttpPut("{id}")]
        public ActionResult PutPropertyDetails(int id, Property property)
        {
            if(id != property.Id)
            {
                return BadRequest();
            }
            _context.Entry(property).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Property/5
        [HttpDelete("{id}")]
        public ActionResult<Property> DeletePropertyDetails(int id)
        {
            var propertyDetails = _context.PropertyDetails.Find(id);

            if(propertyDetails == null)
            {
                return NotFound();
            }

            _context.PropertyDetails.Remove(propertyDetails);
            _context.SaveChanges();

            return propertyDetails;
        }
    }
}
