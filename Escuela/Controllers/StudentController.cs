using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class StudentController : Controller
    {
        private IStudent istudents;
        private ApplicationDbContext context;

        public StudentController(ApplicationDbContext context, IStudent istudents)
        {
            this.context = context;
            this.istudents = istudents;
        }
        public IActionResult ShowStudent()
        {
            var ListarEstudiante = istudents.ListOfStudents();

            return View(ListarEstudiante);
        }
        public IActionResult Ingresar(string Apellidos, string Nombres, string Fechas, int Id)
        {
            ViewBag.Id = Id;
            ViewBag.Apellidos = Apellidos;
            ViewBag.Nombres = Nombres;
            ViewBag.Fechas = Fechas;
            


            return View("Ingresar");
        }
        [HttpPost]
        public IActionResult Guardar(string Apellidos, string Nombres, DateTime Fechas, int Id)
        {
            Students students = new Students();
            if (Id==0)
            {
                students.LastName = Apellidos;
                students.FirstMidName = Nombres;
                students.EnrrollmentsDate = Fechas;
                istudents.Insertar(students);
            }
            else
            {
                int update = Id;
                Students modificar = context.Students.Where(x => x.StudentId == update).FirstOrDefault();
                modificar.LastName = Apellidos;
                modificar.FirstMidName = Nombres;
                modificar.EnrrollmentsDate = Fechas;
                istudents.update(modificar);
            }
            return Redirect("/Student/ShowStudent");
        }

    }
}
