using System;
using System.Collections.Generic;

namespace FundaVida.Entity.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();
}
