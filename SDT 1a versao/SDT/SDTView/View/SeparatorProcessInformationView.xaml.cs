using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SDTPresentation.View
{
    /// <summary>
    /// Interaction logic for ProcessInformationView.xaml
    /// </summary>
    public partial class SeparatorProcessInformationView : UserControl
    {
        public SeparatorProcessInformationView()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void PreviewTextInputEventHandler(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumber(e.Text);
        }

        private void PastingEventHandler(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsNumber(text)) e.CancelCommand();
            }
            else e.CancelCommand();
        }

        private static bool IsNumber(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");   // Regex that matches disallowed text
            return !regex.IsMatch(text); ;
        }

        #endregion

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}
    }
}
