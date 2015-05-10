using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDTDomainModel.Enums;
using SDTDomainModel.Entities;
using SDTPresentation.Utils;

namespace SDTPresentation.ViewModel
{
    public class SeparatorGeneralInformationViewModel : ViewModelBase
    {
        public SeparatorGeneralInformationViewModel(SeparatorDesignViewModel separatorDesignViewModel, 
                                                    Aluno generalInformation)
        {
            _generalInformation = generalInformation;
            _separatorDesignViewModel = separatorDesignViewModel;
        }

        private Aluno _generalInformation;
        private SeparatorDesignViewModel _separatorDesignViewModel;

        //public SeparatorGeneralInformation SeparatorGeneralInformation
        //{
        //    get { return _generalInformation; }
        //    set { _generalInformation = value; }
        //}


        private bool _verticalSeparator = true;
        private bool _horizontalSeparator;
        private bool _twoPhases = true;
        private bool _threePhases;

        #region Properties

        public string Nome
        {
            get { return _generalInformation.Nome; }
            set
            {
                _generalInformation.Nome = value;
                RaisePropertyChangedEvent("Nome");
            }
        }

        public string Contato
        {
            get { return _generalInformation.Contato; }
            set
            {
                _generalInformation.Contato = value;
                RaisePropertyChangedEvent("Contato");
            }
        }

        //public string EmailAluno
        //{
        //    get { return _generalInformation.EmailAluno; }
        //    set
        //    {
        //        _generalInformation.EmailAluno = value;
        //        RaisePropertyChangedEvent("EmailAluno");
        //    }
        //}

        //public string TelefoneAluno
        //{
        //    get { return _generalInformation.TelefoneAluno; }
        //    set
        //    {
        //        _generalInformation.TelefoneAluno = value;
        //        RaisePropertyChangedEvent("TelefoneAluno");
        //    }
        //}

        //public string NomeResponsavel1
        //{
        //    get { return _generalInformation.NomeResponsavel1; }
        //    set
        //    {
        //        _generalInformation.NomeResponsavel1 = value;
        //        RaisePropertyChangedEvent("NomeResponsavel1");
        //    }
        //}

        //public string EmailResponsavel1
        //{
        //    get { return _generalInformation.EmailResponsavel1; }
        //    set
        //    {
        //        _generalInformation.EmailResponsavel1 = value;
        //        RaisePropertyChangedEvent("EmailResponsavel1");
        //    }
        //}

        //public string TelefoneResponsavel1
        //{
        //    get { return _generalInformation.TelefoneResponsavel1; }
        //    set
        //    {
        //        _generalInformation.TelefoneResponsavel1 = value;
        //        RaisePropertyChangedEvent("TelefoneResponsavel1");
        //    }
        //}

        //public string NomeResponsavel2
        //{
        //    get { return _generalInformation.NomeResponsavel2; }
        //    set
        //    {
        //        _generalInformation.NomeResponsavel2 = value;
        //        RaisePropertyChangedEvent("NomeResponsavel2");
        //    }
        //}

        //public string EmailResponsavel2
        //{
        //    get { return _generalInformation.EmailResponsavel1; }
        //    set
        //    {
        //        _generalInformation.EmailResponsavel1 = value;
        //        RaisePropertyChangedEvent("EmailResponsavel1");
        //    }
        //}

        //public string TelefoneResponsavel2
        //{
        //    get { return _generalInformation.TelefoneResponsavel2; }
        //    set
        //    {
        //        _generalInformation.TelefoneResponsavel2 = value;
        //        RaisePropertyChangedEvent("TelefoneResponsavel2");
        //    }
        //}


        //public string Turma
        //{
        //    get { return _generalInformation.Livro.Turma; }
        //    set
        //    {
        //        _generalInformation.Livro.Turma = value;
        //        RaisePropertyChangedEvent("Turma");
        //    }
        //}

        //public string Ano
        //{
        //    get { return _generalInformation.Livro.Ano; }
        //    set
        //    {
        //        _generalInformation.Livro.Ano = value;
        //        RaisePropertyChangedEvent("Ano");
        //    }
        //}

        //public string Semestre
        //{
        //    get { return _generalInformation.Livro.Semestre; }
        //    set
        //    {
        //        _generalInformation.Livro.Semestre = value;
        //        RaisePropertyChangedEvent("Semestre");
        //    }
        //}

        //public string Nota1
        //{
        //    get { return _generalInformation.Livro.Nota1; }
        //    set
        //    {
        //        _generalInformation.Livro.Nota1 = value;
        //        RaisePropertyChangedEvent("Nota1");
        //    }
        //}

        //public string Nota2
        //{
        //    get { return _generalInformation.Livro.Nota2; }
        //    set
        //    {
        //        _generalInformation.Livro.Nota2 = value;
        //        RaisePropertyChangedEvent("Nota2");
        //    }
        //}

        //public string Nota3
        //{
        //    get { return _generalInformation.Livro.Nota3; }
        //    set
        //    {
        //        _generalInformation.Livro.Nota3 = value;
        //        RaisePropertyChangedEvent("Nota3");
        //    }
        //}

        //public string Media
        //{
        //    get { return _generalInformation.Livro.Media; }
        //    set
        //    {
        //        _generalInformation.Livro.Media = value;
        //        RaisePropertyChangedEvent("Media");
        //    }
        //}

        //public string StatusCertificado
        //{
        //    get { return _generalInformation.Livro.StatusCertificado; }
        //    set
        //    {
        //        _generalInformation.Livro.StatusCertificado = value;
        //        RaisePropertyChangedEvent("StatusCertificado");
        //    }
        //}

        public string Turma
        {
            get { return _generalInformation.Turma; }
            set
            {
                _generalInformation.Turma = value;
                RaisePropertyChangedEvent("Turma");
            }
        }

        public string Ano
        {
            get { return _generalInformation.Ano; }
            set
            {
                _generalInformation.Ano = value;
                RaisePropertyChangedEvent("Ano");
            }
        }

        public string Semestre
        {
            get { return _generalInformation.Semestre; }
            set
            {
                _generalInformation.Semestre = value;
                RaisePropertyChangedEvent("Semestre");
            }
        }

        public string Nota1
        {
            get { return _generalInformation.Nota1; }
            set
            {
                _generalInformation.Nota1 = value;
                RaisePropertyChangedEvent("Nota1");
            }
        }

        public string Nota2
        {
            get { return _generalInformation.Nota2; }
            set
            {
                _generalInformation.Nota2 = value;
                RaisePropertyChangedEvent("Nota2");
            }
        }

        public string Nota3
        {
            get { return _generalInformation.Nota3; }
            set
            {
                _generalInformation.Nota3 = value;
                RaisePropertyChangedEvent("Nota3");
            }
        }

        public string Media
        {
            get { return _generalInformation.Media; }
            set
            {
                _generalInformation.Media = value;
                RaisePropertyChangedEvent("Media");
            }
        }

        public string StatusCertificado
        {
            get { return _generalInformation.Certificado; }
            set
            {
                _generalInformation.Certificado = value;
                RaisePropertyChangedEvent("Certificado");
            }
        }

        #endregion


    }
}
