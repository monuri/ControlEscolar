using System;
using System.Collections.Generic;

namespace ControlEscolar.Models;

public partial class TblGrupo
{
    public int IdGrupo { get; set; }

    public string? NombreGrupo { get; set; }

    public int? Grado { get; set; }

    public virtual ICollection<TblCicloGrupoMaterium> TblCicloGrupoMateria { get; set; } = new List<TblCicloGrupoMaterium>();

    public virtual ICollection<TblGrupoProfAlumno> TblGrupoProfAlumnos { get; set; } = new List<TblGrupoProfAlumno>();
}
