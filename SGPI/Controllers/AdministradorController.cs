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
            string numeroDoc = Request.Form["documento"].ToString();
            string pass = Request.Form["clave"].ToString();
            var usuarioLogin = context.TblUsuarios
                .Where(consulta =>
                consulta.NumeroDocumento == numeroDoc &&
                consulta.Clave == pass).FirstOrDefault();

            if (usuarioLogin != null)
            {
                //Administrador
                if (usuarioLogin.Idrol == 1)
                {
                    ViewBag.mensaje = ("Administrador");
                }
                //Coordinador
                else if (usuarioLogin.Idrol == 2)
                {
                    ViewBag.mensaje = ("Coordinador");
                }
                //Estudiante
                else if (usuarioLogin.Idrol == 3)
                {
                    ViewBag.mensaje = ("Estudiante");
                }
                //Rol inexistente
                else
                {
                    ViewBag.mensaje = ("Error al iniciar");
                }
            }
            else
            {
                ViewBag.mensaje = ("Usuario o contraseña incorrectos");
            }

            return View();
            
        }
        public IActionResult OlvidarContrasena() 
        {
            return View();
        }

        public IActionResult CrearUsuario()
        {
            return View();
        }

        public IActionResult BuscarUsuario()
        {
            return View();
        }

        public IActionResult EliminarUsuario()
        {
            return View();
        }
        
        public IActionResult EditarUsuario()
        {
            return View();
        }

        public IActionResult Reportes()
        {
            return View();
        }
    }
}