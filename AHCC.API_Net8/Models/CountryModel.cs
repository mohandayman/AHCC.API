using AHCC.API_Net8.DataAccess;

namespace AHCC.API_Net8.Models
{
    public class CountryModel
    {
        public string? Name { get; set; }

        public string? NameAr { get; set; }
        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }
}
