using SDTDomainModel.Entities;
using SDTPresentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SDTPresentation.View
{

       /// <summary>
        /// Interaction logic for Filtro.xaml
        /// </summary>
        public partial class ConsultaAluno : UserControl
        {
            public ConsultaAluno()
            {
                InitializeComponent();
            }

            //private void TextBox_LostFocus(object sender, RoutedEventArgs e)
            //{
            //    ConsultaAlunoViewModel x = (ConsultaAlunoViewModel)this.DataContext;
            //    if (!String.IsNullOrEmpty(x.AlunoSelecionado.Nota1) && !String.IsNullOrEmpty(x.AlunoSelecionado.Nota2) && !String.IsNullOrEmpty(x.AlunoSelecionado.Nota3))
            //    {
            //        x.SaveFile();
            //        x.alunosView.Refresh();
            //    }
            //}

        }

}
