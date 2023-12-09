﻿using System;
using System.Collections.Generic;

namespace ControlEscolar.Models;

public partial class TblAlumno
{
    public int IdAlumno { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<TblGrupoProfAlumno> TblGrupoProfAlumnos { get; set; } = new List<TblGrupoProfAlumno>();
}
