using System;
using System.Collections.Generic;

namespace Test.Service.Data.Models;

public partial class Colegio
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? TipoColegio { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; } = new List<Calificacione>();

    public virtual ICollection<Materium> Materia { get; } = new List<Materium>();
}
