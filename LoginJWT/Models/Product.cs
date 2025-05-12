using System;
using System.Collections.Generic;

namespace LoginJWT.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? Name { get; set; }

    public string? Brand { get; set; }

    public string? Price { get; set; }
}
