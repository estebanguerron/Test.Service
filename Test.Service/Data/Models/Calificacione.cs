using System;
using System.Collections.Generic;

namespace Test.Service.Data.Models;

public partial class Calificacione
{
    public int Id { get; set; }

    public int? IdColegio { get; set; }

    public int? IdMateria { get; set; }

    public int? IdUsuario { get; set; }

    public decimal? Calificacion { get; set; }

    public virtual Colegio? IdColegioNavigation { get; set; }

    public virtual Materium? IdMateriaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
