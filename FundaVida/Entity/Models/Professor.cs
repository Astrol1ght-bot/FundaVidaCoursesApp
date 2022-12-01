using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundaVida.Entity.Models;

public partial class Professor
{
    public int ProfessorId { get; set; }
    [DisplayName("Nombre")]
    public string Name { get; set; } = null!;
    [DisplayName("Apellidos")]
    public string LastName { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; } = new List<Course>();

    [NotMapped]
    [DisplayName("Profesor")]
    public string FullName => $"{Name} {LastName}";
}
