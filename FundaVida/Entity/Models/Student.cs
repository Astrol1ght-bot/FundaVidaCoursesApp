using System;
using System.Collections.Generic;

namespace FundaVida.Entity.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();
}
