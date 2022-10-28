using Microsoft.AspNetCore.Mvc;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class CoordinadorController : Controller
    {
        SGPIContext context = new SGPIContext();
        public IActionResult Buscar()
        {
            return View();
        }

        public IActionResult ProgramarAsignatura()
        {
            return View();
        }

        public IActionResult Homologacion()
        {
            return View();
        }

        public IActionResult Entrevistas()
        {
            return View();
        }
        public IActionResult Reportes()
        {
            ViewBag.genero = context.TblGeneros.ToList();
            ViewBag.programa = context.TblProgramas.ToList();
            ViewBag.documento = context.TblDocumentos.ToList();
            ViewBag.rol = context.TblRols.ToList();
            return View();
        }
    }
}
