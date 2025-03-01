using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExTasks.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExTasks.Controllers;

public class HomeController : Controller
{
    private readonly ExamenContext _dbcontext;

    public HomeController(ExamenContext context)
    {
        _dbcontext= context;
    }

    public IActionResult Index()
    {
        List<CTarea> lista = _dbcontext.CTareas.Include(c=> c.oprioridad).Include(c => c.ocategoria).ToList();
        HttpContext.Session.SetString("Id",lista.Count.ToString());
        return View(lista);
    }

    [HttpGet]
    public IActionResult tarea_d(int NidTarea)
    {
        ABCTarea otarea = new ABCTarea()
        {
            oTarea = new CTarea(),
            oListaCategoria = _dbcontext.CCategoria.Select(categoria=> new SelectListItem()
            {
                Text = categoria.Vcategoria,
                Value = categoria.NidCategoria.ToString()

            }).ToList(),
            oListaPrioridad = _dbcontext.CPrioridads.Select(prio => new SelectListItem()
            {
                Text = prio.Vprioridad,
                Value = prio.NidPrioridad.ToString()

            }).ToList(),
        };

        if (NidTarea != 0)
        {

            otarea.oTarea = _dbcontext.CTareas.Find(NidTarea);
        }


        return View(otarea);
    }


    [HttpPost]
    public IActionResult tarea_d(ABCTarea tarea)
    {
      
        int id = Convert.ToInt32(HttpContext.Session.GetString("Id"));
        id++;        
        if (String.IsNullOrEmpty(tarea.oTarea.NidTarea.ToString())|| (tarea.oTarea.NidTarea== 0))
        {
            tarea.oTarea.NidTarea = id;
            _dbcontext.CTareas.Add(tarea.oTarea);
            
        }
        else
        {
            _dbcontext.CTareas.Update(tarea.oTarea);
        }

        _dbcontext.SaveChanges();

        return RedirectToAction("Index", "Home");


    }

    [HttpPost]
    public IActionResult Eliminar(short tarea)
    {
        CTarea eliminar = new CTarea();
        eliminar.NidTarea = tarea;
        _dbcontext.CTareas.Remove(eliminar);
        _dbcontext.SaveChanges();

        return RedirectToAction("Index", "Home");
    }



}
