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
    public class CourseController : Controller
    {
        private ICourese icourese;
        private ApplicationDbContext context;

        public CourseController(ApplicationDbContext context, ICourese icourese)
        {
            this.context = context;
            this.icourese = icourese;
        }
        public IActionResult ShowCourse()
        {
            var ListarCourse = icourese.ListarCursos();

            return View(ListarCourse);
        }
        public IActionResult Ingresar(string Title, int Credits, int Id)
        {
            ViewBag.Id = Id;
            ViewBag.Title = Title;
            ViewBag.Credits = Credits;
            

            return View("Ingresar");
        }
        [HttpPost]
        public IActionResult Guardar(int Id, string Title, int Credits)
        {
            Course courese = new Course();
            if (Id== 0)
            {
                courese.Title = Title;
                courese.Credits = Credits;
                icourese.Insertar(courese);
            }
            else
            {
                int update = Id;
                Course modificar = context.Courses.Where(x => x.CouserId == update).FirstOrDefault();
                courese.Title = Title;
                courese.Credits = Credits;
                icourese.Insertar(courese);
                icourese.update(modificar);
            }
            return Redirect("/Course/ShowCourse");
        }
    }
}
