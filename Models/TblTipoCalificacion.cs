using System;
using System.Collections.Generic;

namespace ControlEscolar.Models;

public partial class TblTipoCalificacion
{
    public int IdTipoCal { get; set; }

    public string? DescripcionCal { get; set; }

    public virtual ICollection<TblCalificacione> TblCalificaciones { get; set; } = new List<TblCalificacione>();
}
