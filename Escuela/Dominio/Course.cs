using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Dominio
{
    public class Course
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CouserId { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public ICollection<Erollement> Erollements { get; set; }
    }
}
