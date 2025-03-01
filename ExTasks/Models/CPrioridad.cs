using System;
using System.Collections.Generic;

namespace ExTasks.Models;

public partial class CPrioridad
{
    public short NidPrioridad { get; set; }

    public string Vprioridad { get; set; } = null!;

    public bool? Bactivo { get; set; }

    public virtual ICollection<CTarea> CTareas { get; set; } = new List<CTarea>();
}
