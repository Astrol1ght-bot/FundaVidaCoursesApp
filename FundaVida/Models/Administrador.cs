using System;
using System.Collections.Generic;

namespace FundaVida.Models;

public partial class Administrador
{
    public int AdministradorId { get; set; }

    public string AdministradorNombre { get; set; } = null!;

    public string AdministradorHashpassword { get; set; } = null!;
}
