using System;
using System.Collections.Generic;

namespace ControlEscolar.Models;

public partial class TblCalificacione
{
    public int IdCalificaciones { get; set; }

    public int? FidGrupoProfAlumno { get; set; }

    public int? FidTipoCalificacion { get; set; }

    public int? Calificacion { get; set; }

    public virtual TblGrupoProfAlumno? FidGrupoProfAlumnoNavigation { get; set; }

    public virtual TblTipoCalificacion? FidTipoCalificacionNavigation { get; set; }
}
