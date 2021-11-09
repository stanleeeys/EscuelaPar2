using Escuela.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Servicio
{
    public interface ICourese
    {


        void Insertar(Course c);

        void Delete(Course c);

        void Buscar(Course c);

        ICollection<Course> ListarCursos();

        void update(Course course);


    }
}
