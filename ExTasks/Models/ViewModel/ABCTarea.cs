using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace ExTasks.Models;

public class ABCTarea
{
    public CTarea oTarea{ get; set; }

    public List<SelectListItem> oListaCategoria { get; set; }

    public List<SelectListItem> oListaPrioridad { get; set; }

}
