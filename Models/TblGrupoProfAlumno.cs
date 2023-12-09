using System;
using System.Collections.Generic;

namespace ControlEscolar.Models;

public partial class TblGrupoProfAlumno
{
    public int IdGrupoProfAlumno { get; set; }

    public int? FidGrupo { get; set; }

    public int? FidProfesor { get; set; }

    public int? FidAlumno { get; set; }

    public virtual TblAlumno? FidAlumnoNavigation { get; set; }

    public virtual TblGrupo? FidGrupoNavigation { get; set; }

    public virtual TblProfesor? FidProfesorNavigation { get; set; }

    public virtual ICollection<TblCalificacione> TblCalificaciones { get; set; } = new List<TblCalificacione>();
}
