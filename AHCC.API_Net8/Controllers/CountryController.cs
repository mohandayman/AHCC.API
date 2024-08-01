using AHCC.API_Net8.DataAccess;
using AHCC.API_Net8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AHCC.API_Net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly CountryCityContext _context;
        public CountryController(CountryCityContext context)
        {
           _context = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Country>> GetAll()
        {
            var countriesWithCities = _context.Countries.Include(c => c.Cities).ToList();
            return Ok(countriesWithCities);
        }

        [HttpGet("GetByID/{id}")]
        public ActionResult<Country> GeyByID(int id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPut("Update/{id}")]
        public IActionResult UpdateCountry( long id, [FromForm] CountryModel countrymodel)
        {
           
            var existingCountry = _context.Countries.FirstOrDefault(c=>c.Id == id);
            if (existingCountry == null)
            {
                return NotFound();
            }

            existingCountry.Name = countrymodel.Name;
            existingCountry.NameAr = countrymodel.NameAr;

            _context.SaveChanges();

            return NoContent();
        }


        [HttpPost("AddCountry")]
        public ActionResult<Country> AddCountry([FromForm] CountryModel countrymodel)
        {
            var country = new Country() {Name = countrymodel.Name , NameAr = countrymodel.NameAr };
            _context.Countries.Add(country);
            _context.SaveChanges();

            return Ok(country);
        }

        [HttpDelete("DeleteCountry{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var country = _context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
