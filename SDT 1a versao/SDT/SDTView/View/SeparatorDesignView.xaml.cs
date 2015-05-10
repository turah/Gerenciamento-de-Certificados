using SDTPresentation.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for SeparatorDesignView.xaml
    /// </summary>
    public partial class SeparatorDesignView : Window
    {
        public SeparatorDesignView()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("TEM CERTEZA QUE DESEJA FECHAR O PROGRAMA? ALTERAÇÕES NÃO SALVAS SERÃO PERDIDAS.", "ATENÇÃO!", MessageBoxButton.YesNo, MessageBoxImage.None);
            if (messageBoxResult == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

    }
}
