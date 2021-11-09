using Escuela.Dominio;
using Escuela.Models;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICourese icourse;
        private IRollements irollements;
        private IStudent istudent;


        public HomeController(ILogger<HomeController> logger, ICourese icourse, IRollements irollements,
            IStudent istudent)
        {
            this.icourse = icourse;
            this.irollements = irollements;
            this.istudent = istudent;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //for (int i=0; i <= 100; i++) {
            //    Course course = new Course();

            //    course.Title = "Update";
            //    course.Credits = 100;
            //    icourse.Insertar(course);
            //}
            var listado = irollements.UnionDeTablas();


            return View(listado);
        }

        public IActionResult GetAll()
        {

            var DandoFormatoJson = icourse.ListarCursos();


            return Json(new { data = DandoFormatoJson });
        }

        public IActionResult ComboBox()
        {
            {
                var informationOfTheComboBox = icourse.ListarCursos();
                var informationtheComboboxforStudent = istudent.ListOfStudents();

                List<SelectListItem> listaCourse = new List<SelectListItem>();
                List<SelectListItem> listaStudent = new List<SelectListItem>();
                foreach (var iterarinformacion in informationOfTheComboBox)
                {
                    listaCourse.Add(new SelectListItem
                    {
                        Text = iterarinformacion.Title,
                        Value = Convert.ToString
                             (iterarinformacion.CouserId)
                    });

                    ViewBag.estado = listaCourse;
                }
                foreach (var iterarinformacion in informationtheComboboxforStudent)
                {
                    listaStudent.Add(
                           new SelectListItem
                           {
                               Text = iterarinformacion.FirstMidName,
                               Value = Convert.ToString(iterarinformacion.StudentId)
                           });


                    ViewBag.estadoStudents = listaStudent;

                }

                return View();

            }

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
