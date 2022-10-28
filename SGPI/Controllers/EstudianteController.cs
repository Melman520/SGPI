using Microsoft.AspNetCore.Mvc;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class EstudianteController : Controller
    {
        SGPIContext context = new SGPIContext();
        public IActionResult ActualizarUsuario()
        {
            ViewBag.genero = context.TblGeneros.ToList();
            ViewBag.programa = context.TblProgramas.ToList();
            ViewBag.documento = context.TblDocumentos.ToList();
            ViewBag.rol = context.TblRols.ToList();
            return View();
        }

        public IActionResult Pago() 
        {
            return View();
        }

        
    }
}