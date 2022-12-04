using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FundaVida.Entity.Models;

public partial class Student
{
    public int StudentId { get; set; }

    [DisplayName("Nombre")]
    public string Name { get; set; } = null!;
    [DisplayName("Apellidos")]
    public string LastName { get; set; } = null!;
    [DisplayName("Correo")]
    public string Email { get; set; } = null!;
    [DisplayName("Numero Telefónico")]
    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();
}
