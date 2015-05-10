using SDTDomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDTDomainModel.Entities
{
    public class Aluno
    {
        //public Aluno()
        //{
        //    this.Livro = new Livro();
        //}

        public string Nome { get; set; }

        public string Contato { get; set; }

        //public string EmailAluno { get; set; }

        //public string TelefoneAluno { get; set; }

        //public string NomeResponsavel1 { get; set; }

        //public string EmailResponsavel1 { get; set; }

        //public string TelefoneResponsavel1 { get; set; }

        //public string NomeResponsavel2 { get; set; }

        //public string EmailResponsavel2 { get; set; }

        //public string TelefoneResponsavel2 { get; set; }

        //public Livro Livro { get; set; }

        public string Turma { get; set; }

        public string Ano { get; set; }

        public string Semestre { get; set; }

        public string Nota1 { get; set; }

        public string Nota2 { get; set; }

        public string Nota3 { get; set; }

        public string Media 
        {
            get
            {
                if (!String.IsNullOrEmpty(this.Nota1) && !String.IsNullOrEmpty(this.Nota2) && !String.IsNullOrEmpty(this.Nota3))
                {
                    return ((Int32.Parse(this.Nota1) + Int32.Parse(this.Nota2) + 2 * (Int32.Parse(this.Nota3)))/4).ToString();
                } else { 
                    return String.Empty; 
                }
            }

            set { } 
        
        }

        public string Certificado { get; set; }

    }
}
