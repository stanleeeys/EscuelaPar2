using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class EnrollemntController : Controller
    {
        private ApplicationDbContext context;
        private ICourese icourese;
        private IRollements irollements;
        private IStudent istudent;

        public EnrollemntController(ApplicationDbContext context, ICourese icourese, IRollements irollements, IStudent istudent)
        {
            this.context = context;
            this.icourese = icourese;
            this.irollements = irollements;
            this.istudent = istudent;
        }
        public IActionResult JoinTbl()
        {
            var ListEnrollemnt = irollements.UnionDeTablas();
            return View(ListEnrollemnt);
        }
        public IActionResult Combo()
        {
            var informationOfTheComboBox = icourese.ListarCursos();
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
        public IActionResult ObtenerInf()
        {
            return View("Combo");
        }
        public IActionResult Guardar(Erollement enrollemnt)
        {
            Erollement enrollement = new Erollement();
            enrollemnt.CourseID = enrollemnt.CourseID;
            enrollemnt.StudentID = enrollemnt.StudentID;
            enrollemnt.Grade = enrollemnt.Grade;
            irollements.Insertar(enrollemnt);
            return Redirect("/Enrollemnt/JoinTbl");
        }

    }
}
