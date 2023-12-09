using System;
using System.Collections.Generic;

namespace ControlEscolar.Models;

public partial class TblCicloGrupoMaterium
{
    public int IdCicloxGrupoxMateria { get; set; }

    public int? FidCiclo { get; set; }

    public int? FidGrupo { get; set; }

    public int? FidMateria { get; set; }

    public virtual TblCiclo? FidCicloNavigation { get; set; }

    public virtual TblGrupo? FidGrupoNavigation { get; set; }

    public virtual TblMaterium? FidMateriaNavigation { get; set; }
}
