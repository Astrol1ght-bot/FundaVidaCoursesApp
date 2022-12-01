using System;
using System.Collections.Generic;

namespace FundaVida.Entity.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Hashedpassword { get; set; } = null!;

    public string Role { get; set; } = null!;
}
