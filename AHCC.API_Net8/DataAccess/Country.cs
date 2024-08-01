using System;
using System.Collections.Generic;

namespace AHCC.API_Net8.DataAccess;

public partial class Country
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
