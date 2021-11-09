using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class StudentRepository : IStudent
    {
        private ApplicationDbContext app;

        public StudentRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Insertar(Students studiante)
        {
            app.Add(studiante);
            app.SaveChanges();
        }

        public List<Students> ListOfStudents()
        {
            return app.Students.ToList();
        }

        public void update(Students studiante)
        {
            app.Update(studiante);
            app.SaveChanges();
        }
    }
}
