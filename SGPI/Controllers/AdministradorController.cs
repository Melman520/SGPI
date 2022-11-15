using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
using System.Drawing.Printing;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        SGPIContext context = new SGPIContext();

        public IActionResult Login()
        {
            /*
            TblPrograma prog = new TblPrograma();
            prog.Idprograma = 12123;
            prog.Programa = "Gestion TI";
            context.Add(prog);
            */

            /*
            List<TblPrograma> programas = new List<TblPrograma>();
            programas = context.TblProgramas.ToList();
            foreach (var item in programas)
            {
                Console.WriteLine(item.Programa);
            }
            */

            //Create
            /*
             * TblUsuario usr = new TblUsuario();
            usr.PrimerNombre = "Mauricio";
            usr.SegundoNombre = string.Empty;
            usr.PrimerApellido = "Amariles";
            usr.SegundoApellido = "Camacho";
            usr.Email = "mauricio.amariles@tdea.edu.co";
            usr.Iddoc = 1;
            usr.Idgenero = 1;
            usr.Idrol = 1;
            usr.Idprograma = 102735;
            usr.NumeroDocumento = "123456789";
            usr.Clave = "123456789";
            context.Add(usr);
            context.SaveChanges();
            */

            //Buscar
            /*
            TblUsuario usuario = new TblUsuario();
            usuario = context.TblUsuarios
                .Single(b => b.NumeroDocumento == "123456789");
            */

            //Listar usuarios
            /*
            List<TblUsuario> usuarios = new List<TblUsuario>();
            usuarios = context.TblUsuarios.ToList();
            */

            return View();
        }

        [HttpPost]
        public IActionResult Login(TblUsuario user) 
        {
            string numeroDoc = user.NumeroDocumento;
            string pass = user.Clave;
            var usuarioLogin = context.TblUsuarios
                .Where(consulta =>
                consulta.NumeroDocumento == numeroDoc &&
                consulta.Clave == pass).FirstOrDefault();

            if (usuarioLogin != null)
            {
                //Administrador
                if (usuarioLogin.Idrol == 1)
                {
                    return Redirect("Administrador/CrearUsuario");
                }
                //Coordinador
                else if (usuarioLogin.Idrol == 2)
                {
                    return Redirect("Coordinador/Buscar");
                }
                //Estudiante
                else if (usuarioLogin.Idrol == 3)
                {
                    return Redirect("Estudiante/ActualizarUsuario/?Idusuario="+usuarioLogin.Idusuario);
                }
                //Rol inexistente
                else
                {
                    ViewBag.mensaje = ("Error al iniciar");
                }
            }
            else
            {
                ViewBag.mensaje = ("Error");
            }

            return View();
            
        }
        public IActionResult OlvidarContrasena() 
        {
            return View();
        }

        public IActionResult CrearUsuario()
        {
            ViewBag.genero = context.TblGeneros.ToList();
            ViewBag.programa = context.TblProgramas.ToList();
            ViewBag.documento = context.TblDocumentos.ToList();
            ViewBag.rol = context.TblRols.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CrearUsuario(TblUsuario usuario) {
            context.TblUsuarios.Add(usuario);
            context.SaveChanges();
            ViewBag.mensaje = "Usuario Creado";

            ViewBag.genero = context.TblGeneros.ToList();
            ViewBag.programa = context.TblProgramas.ToList();
            ViewBag.documento = context.TblDocumentos.ToList();
            ViewBag.rol = context.TblRols.ToList();

            return View();
        }


        public IActionResult BuscarUsuario()
        {
            ViewBag.encontrado = 2;
            return View();
        }

        [HttpPost]
        public IActionResult BuscarUsuario(TblUsuario usuario) {
            String numeroDoc = usuario.NumeroDocumento;

            var user = context.TblUsuarios.
                Where(consulta => consulta.NumeroDocumento == numeroDoc).FirstOrDefault();

            if (user != null)
            {
                ViewBag.encontrado = 0;
                return View(user);
            }
            else
            {
                ViewBag.encontrado = 1;
                return View();
            }
        }

        public IActionResult EditarUsuario(int ? Idusuario)
        {

            
            TblUsuario usuario = context.TblUsuarios.Find(Idusuario);
            

            if (usuario != null)
            {
                ViewBag.genero = context.TblGeneros.ToList();
                ViewBag.programa = context.TblProgramas.ToList();
                ViewBag.documento = context.TblDocumentos.ToList();
                ViewBag.rol = context.TblRols.ToList();
                return View(usuario);
            }
            else
            {
                return Redirect("/Administrador/BuscarUsuario");
            }
        }

        [HttpPost]
        public IActionResult EditarUsuario(TblUsuario usuario)
        {
            context.Update(usuario);
            context.SaveChanges();
            return Redirect("/Administrador/BuscarUsuario");
        }

        

        
        public IActionResult EliminarUsuario(int ? Idusuario)
        {
            TblUsuario user = context.TblUsuarios.Find(Idusuario);
            if (user != null) 
            {
                context.Remove(user);
                context.SaveChanges();
            }
            return Redirect("/Administrador/BuscarUsuario");
        }
        [HttpPost]
        public IActionResult EliminarUsuario()
        {
            return View();
        }
        public IActionResult Reportes()
        {
            return View();
        }
    }
}