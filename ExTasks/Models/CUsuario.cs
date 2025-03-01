using System;
using System.Collections.Generic;

namespace ExTasks.Models;

public partial class CUsuario
{
    public string VidUsuario { get; set; } = null!;

    public string VapPaterno { get; set; } = null!;

    public string? Vapmaterno { get; set; }

    public string Vnombre { get; set; } = null!;

    public string? VsegundoNombre { get; set; }

    public string Vpassword { get; set; } = null!;
}
