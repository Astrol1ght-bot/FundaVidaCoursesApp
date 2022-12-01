using System;
using System.Collections.Generic;

namespace FundaVida.Entity.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public int GroupId { get; set; }

    public bool EnEspera { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
