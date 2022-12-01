using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FundaVida.Entity.Models;

public partial class Module
{
    public int ModuleId { get; set; }

    [DisplayName("Nombre del Módulo")]
    public string Name { get; set; } = null!;

    [DisplayName("Semanas")]
    public int Weeks { get; set; }
    [DisplayName("Fecha de Inicio")]
    public DateTime DateIni { get; set; }
    [DisplayName("Fecha de Finalización")]

    public DateTime DateFin { get; set; }
    [DisplayName("Horario")]
    public string Schedule { get; set; } = null!;
    [DisplayName("Total de Horas")]
    public int? TotalHours { get; set; }

    [DisplayName("Curso")]
    public int? CourseId { get; set; }
    [DisplayName("Curso")]
    public virtual Course? Course { get; set; }
}
