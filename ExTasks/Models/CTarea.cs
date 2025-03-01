using System;
using System.Collections.Generic;

namespace ExTasks.Models;

public partial class CTarea
{
    public int NidTarea { get; set; }

    public string Vtarea { get; set; } = null!;

    public short? NidCategoria { get; set; }

    public short? NidPrioridad { get; set; }

    public bool? Bactivo { get; set; }

    public virtual CCategorium? ocategoria { get; set; }

    public virtual CPrioridad? oprioridad { get; set; }
}
