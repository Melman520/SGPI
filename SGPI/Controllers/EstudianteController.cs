using Microsoft.AspNetCore.Mvc;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class EstudianteController : Controller
    {
        SGPIContext context = new SGPIContext();


        public IActionResult ActualizarUsuario(int? Idusuario)
        {
            ViewBag.genero = context.TblGeneros.ToList();
            ViewBag.programa = context.TblProgramas.ToList();
            ViewBag.documento = context.TblDocumentos.ToList();
            ViewBag.rol = context.TblRols.ToList();
            var usuario = context.TblUsuarios.Find(Idusuario);


            return View(usuario);
        }

        [HttpPost]
        public IActionResult ActualizarUsuario(TblUsuario usuario)
        {
            var usuarioActualizar = context.TblUsuarios
                .Where(consulta =>
                consulta.Idusuario == usuario.Idusuario).FirstOrDefault();
            //TblUsuairo usuarioActualizar = context.TblUsuarios.Find(usuario);
            usuarioActualizar.Iddoc = usuario.Iddoc;
            usuarioActualizar.Idgenero = usuario.Idgenero;
            usuarioActualizar.NumeroDocumento = usuario.NumeroDocumento;
            usuarioActualizar.PrimerNombre = usuario.PrimerNombre;
            usuarioActualizar.SegundoNombre = usuario.SegundoNombre;
            usuarioActualizar.PrimerApellido = usuario.PrimerApellido;
            usuarioActualizar.SegundoApellido = usuario.SegundoApellido;
            usuarioActualizar.Idprograma = usuario.Idprograma;
            usuarioActualizar.Email = usuario.Email;

            ViewBag.idUsuario = usuarioActualizar.Idusuario;

            context.Update(usuarioActualizar);
            context.SaveChanges();
            return Redirect("/Estudiante/Pago/?Idusuario=" + usuarioActualizar.Idusuario);
        }
        public IActionResult Pago()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Pago(TblPago pago, TblEstudiante estudiante, int ? Idusuario) {

            TblUsuario usuario = context.TblUsuarios.Find(Idusuario);

            pago.Estado = true;
            context.TblPagos.Add(pago);
            context.SaveChanges();
            ViewBag.mensaje = "Pago Registrado";

            context.TblEstudiantes.Add(estudiante);
            estudiante.Idpago = pago.Idpago;
            estudiante.Idusuario = usuario.Idusuario;
            estudiante.Archivo = Request.Form["Archivo"];
            estudiante.Egresado = false;

            context.TblEstudiantes.Add(estudiante);
            context.SaveChanges();

            return View();
        }
    }
}