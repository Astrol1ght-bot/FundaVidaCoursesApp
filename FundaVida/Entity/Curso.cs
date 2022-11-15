using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundaVida.Entity;

public partial class Curso
{
    public int CursoId { get; set; }

    public string? CursoNombre { get; set; }

    public byte[]? CursoImagen { get; set; }

    public virtual ICollection<Horario> Horarios { get; } = new List<Horario>();

    [NotMapped]
    public IFormFile ImageFile { get; set; }
}
