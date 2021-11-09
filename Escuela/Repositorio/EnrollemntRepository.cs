using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class EnrollemntRepository : IRollements
    {
        private ApplicationDbContext bd;

        public EnrollemntRepository(ApplicationDbContext bd)
        {
            this.bd = bd;
        }

        public void Insertar(Erollement erollement)
        {
            bd.Add(erollement);
            bd.SaveChanges(); 
        }

        public List<Erollement> UnionDeTablas()
        {
            var union = bd.Erollements.
               Include(e => e.Student).
               Include(c => c.Course).
               ToList();

            return union;
        }
    }
}
