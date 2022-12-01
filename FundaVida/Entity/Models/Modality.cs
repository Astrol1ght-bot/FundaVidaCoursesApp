using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FundaVida.Entity.Models;

public partial class Modality
{
    public int ModalityId { get; set; }
    [DisplayName("Modalidad")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; } = new List<Course>();
}
