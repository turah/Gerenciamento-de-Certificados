using SDTDomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using SDTBusiness.Registers;
using System.Windows;
using SDTPresentation.Utils;

namespace SDTPresentation.ViewModel
{
    public class ConsultaAlunoViewModel: ViewModelBase
    {
       #region filtro

        public ConsultaAlunoViewModel()
        {
            listaAlunos = new ObservableCollection<Aluno>();
            this.CarregarArquivo();

            alunosView = CollectionViewSource.GetDefaultView(listaAlunos);
            alunosView.Filter = FiltroAgenda;
        }

        private void CarregarArquivo()
        {
            string JsonResult = FileViewModel.Open();

            if (JsonResult != null)
            {
                ObservableCollection<Aluno> listaAlunosDoArquivo = new ObservableCollection<Aluno>();

                try
                {
                    listaAlunosDoArquivo = JsonResult.FromJson<ObservableCollection<Aluno>>();
                }
                catch (Exception)
                {
                    MessageBox.Show(WarningMessage.UNEXPECTEDFILEFORMAT, WarningMessage.ERROR, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                try
                {
                    foreach (Aluno item in listaAlunosDoArquivo)
                    {
                        listaAlunos.Add(item);
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        public ObservableCollection<Aluno> listaAlunos;
        public ICollectionView alunosView;

        private string _filtroPorNome;
        private string _filtroPorTurma;
        private string _filtroPorAno;

        public ICollectionView Alunos
        {
            get { return alunosView; }
        }

         public string FiltroPorNome
        {
            get { return _filtroPorNome; }
            set
            {
                _filtroPorNome = value;
                RaisePropertyChangedEvent("FiltroPorNome");
                alunosView.Refresh();
            }
        }

        public string FiltroPorTurma
        {
            get { return _filtroPorTurma; }
            set
            {
                _filtroPorTurma = value;
                RaisePropertyChangedEvent("FiltroPorTurma");
                alunosView.Refresh();
            }
        }

        public string FiltroPorAno
        {
            get { return _filtroPorAno; }
            set
            {
                _filtroPorAno = value;
                RaisePropertyChangedEvent("FiltroPorAno");
                alunosView.Refresh();
            }
        }

        private bool FiltroAgenda(object item)
        {
            Aluno atividade = item as Aluno;

            bool retorno = true;

            if (string.IsNullOrEmpty(FiltroPorNome) && string.IsNullOrEmpty(FiltroPorAno) && string.IsNullOrEmpty(FiltroPorTurma))
            {
                return true;
            } else {
                if (!string.IsNullOrEmpty(FiltroPorNome))
                {
                    retorno = !string.IsNullOrEmpty(atividade.Nome) && atividade.Nome.ToUpper().Contains(FiltroPorNome.ToUpper());

                } if (retorno && !string.IsNullOrEmpty(FiltroPorAno))
                {
                    retorno = !string.IsNullOrEmpty(atividade.Ano) && atividade.Ano.ToUpper().Contains(FiltroPorAno.ToUpper());
                }
                if (retorno  && !string.IsNullOrEmpty(FiltroPorTurma))
                {
                    retorno =  !string.IsNullOrEmpty(atividade.Turma) && atividade.Turma.ToUpper().Contains(FiltroPorTurma.ToUpper());
                }

                return retorno;
            }
        }

        #endregion

        #region CRUD

        private Aluno alunoSelecionado;
        public Aluno AlunoSelecionado
        {
            get { return alunoSelecionado; }
            set
            {
                alunoSelecionado = value;
                RaisePropertyChangedEvent("AlunoSelecionado");
            }
        }

        private int indiceAlunoSelecionado;
        public int IndiceAlunoSelecionado
        {
            get { return indiceAlunoSelecionado; }
            set
            {
                indiceAlunoSelecionado = value;
                RaisePropertyChangedEvent("IndiceAlunoSelecionado");
            }
        }

        public ICommand RemoverItemSelecionadoCommand
        {
            get { return new DelegateCommand(RemoverItemSelecionado); }
        }

        public void RemoverItemSelecionado()
        {
            if (IndiceAlunoSelecionado >= 0)
                listaAlunos.Remove(AlunoSelecionado);
        }

        public ICommand AdicionarNovoItemAListaCommand
        {
            get { return new DelegateCommand(AdicionarNovoItemALista); }
        }

        public void AdicionarNovoItemALista()
        {
            //cria um no elemento
            Aluno novoAluno = new Aluno();
            //adiciona na lista
            listaAlunos.Add(novoAluno);
            //seleciona o elemento criado
            AlunoSelecionado = novoAluno;
        }

        #endregion


        public ICommand Save
        {
            get { return new DelegateCommand(SaveFile); }
        }

        public ICommand AtualizarMedia
        {
            get { return new DelegateCommand(SaveFileNoMessage); }
        }


        public void SaveFile()
        {
            FileViewModel.Save(listaAlunos.ToJson(), true);
            alunosView.Refresh();
        }


        public void SaveFileNoMessage()
        {
            FileViewModel.Save(listaAlunos.ToJson(), false);
            alunosView.Refresh();
        }
      }
}