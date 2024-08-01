using System;
using System.Collections.Generic;

namespace AHCC.API_Net8.DataAccess;

public partial class City
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public long? CountryFk { get; set; }

    public virtual Country? CountryFkNavigation { get; set; }
}
