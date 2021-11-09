using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class CourseRepositorio : ICourese
    {
        private ApplicationDbContext app  ;

        public CourseRepositorio(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Buscar(Course c)
        {
            app.Courses.Find(c);
           
        }

        public void Delete(Course c)
        {
            app.Courses.Remove(c);
        }

        public void Insertar(Course c)
        {

            app.Add(c);
            app.SaveChanges();
            
        }

        public ICollection<Course> ListarCursos()
        {

           return app.Courses.ToList();

        }

        public void update(Course course)
        {
            app.Update(course);
            app.SaveChanges();
        }
    }
}
