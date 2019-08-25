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
    public class LandlordsController : ControllerBase
    {
        public readonly TenantContext _context;

        public LandlordsController(TenantContext context) => _context = context;

        // GET: api/Landlords
        [HttpGet]
        public ActionResult<IEnumerable<Landlord>> GetLandlords()
        {
            return _context.LandlordDetails;
        }

        // GET: api/Landlords/5
        [HttpGet("{id}")]
        public ActionResult<Landlord> GetLandlordDetails(int id)
        {
            var landlordDetails = _context.LandlordDetails.Find(id);
            if (landlordDetails == null)
            {
                return NotFound();
            }
            return landlordDetails;
        }

        // POST: api/Landlords
        [HttpPost]
        public ActionResult<Landlord> PostLandlordDetails(Landlord landlord)
        {
            _context.LandlordDetails.Add(landlord);
            _context.SaveChanges();

            return CreatedAtAction("PostLandlordDetails", new Landlord { Id = landlord.Id }, landlord);
        }

        // PUT: api/Landlords/5
        [HttpPut("{id}")]
        public ActionResult PutLandlordDetails(int id, Landlord landlord)
        {
            if(id != landlord.Id)
            {
                return BadRequest();
            }
            _context.Entry(landlord).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Landlord> DeleteLandlordDetails(int id)
        {
            var landlordDetails = _context.LandlordDetails.Find(id);

            if(landlordDetails == null)
            {
                return NotFound();
            }

            _context.LandlordDetails.Remove(landlordDetails);
            _context.SaveChanges();

            return landlordDetails;
        }
    }
}
