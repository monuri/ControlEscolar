using System;
using System.Collections.Generic;

namespace ControlEscolar.Models;

public partial class TblMaterium
{
    public int IdMateria { get; set; }

    public string? NombreMateria { get; set; }

    public virtual ICollection<TblCicloGrupoMaterium> TblCicloGrupoMateria { get; set; } = new List<TblCicloGrupoMaterium>();
}
