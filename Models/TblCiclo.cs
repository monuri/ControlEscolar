using System;
using System.Collections.Generic;

namespace ControlEscolar.Models;

public partial class TblCiclo
{
    public int IdCiclo { get; set; }

    public string? NombreCiclo { get; set; }

    public int? CveCiclo { get; set; }

    public virtual ICollection<TblCicloGrupoMaterium> TblCicloGrupoMateria { get; set; } = new List<TblCicloGrupoMaterium>();
}
