using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundaVida.Entity.Models;

public partial class Course
{
    [DisplayName("ID")]
    public int CourseId { get; set; }
    [DisplayName("Nombre")]
    public string Name { get; set; } = null!;
    [DisplayName("Descripción")]
    public string Description { get; set; } = null!;
    [DisplayName("Profesor ID")]
    public int? ProfessorId { get; set; }
    [DisplayName("Modalidad ID")]
    public int ModalityId { get; set; }
    [DisplayName("Imágen")]
    public byte[]? ImageData { get; set; } = null!;
    public int? MaxEnrollments { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();
    [DisplayName("Modalidad")]
    [ForeignKey("ModalityId")]
    public virtual Modality? Modality { get; set; } = null!;

    public virtual ICollection<Module> Modules { get; } = new List<Module>();
    [DisplayName("Profesor")]
    [ForeignKey("ProfessorId")]
    public virtual Professor? Professor { get; set; }

    [NotMapped]
    [DisplayName("Imágen")]
    public IFormFile ImageFile { get; set; }
}
