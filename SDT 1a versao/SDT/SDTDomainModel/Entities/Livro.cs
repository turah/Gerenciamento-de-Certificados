using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDTDomainModel.Entities
{
    public class Livro
    {
        public string Turma { get; set; }

        public string Ano { get; set; }

        public string Semestre { get; set; }

        public string Nota1 { get; set; }

        public string Nota2 { get; set; }

        public string Nota3 { get; set; }

        public string Media { get; set; }

        public string StatusCertificado { get; set; }
    }
}
