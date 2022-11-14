using back_gestion_tareas.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace back_gestion_tareas.Controllers
{
    [EnableCors("All")]
    [Route("[controller]")]
    [ApiController]
    public class TareaController : Controller
    {
        private readonly AppDBContext _context;

        public TareaController(AppDBContext context)
        {
            this._context = context;
        }

        // GET: api/<ReclamoController>
        [HttpGet]
        public IActionResult Get()
        {
            var _tarea = from Tarea in _context.Tareas
                           select new
                           {
                              NombreTarea= Tarea.Nombre,
                              EstadoTarea= Tarea.Estado
                           };

            if (_tarea == null)
            {
                return NotFound();
            }

            return Ok(_tarea);
        }
    }
}
