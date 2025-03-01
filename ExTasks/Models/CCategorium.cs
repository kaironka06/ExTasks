using System;
using System.Collections.Generic;

namespace ExTasks.Models;

public partial class CCategorium
{
    public short NidCategoria { get; set; }

    public string Vcategoria { get; set; } = null!;

    public bool? Bactivo { get; set; }

    public virtual ICollection<CTarea> CTareas { get; set; } = new List<CTarea>();
}
