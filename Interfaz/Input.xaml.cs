using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Interfaz
{
    /// <summary>
    /// Interaction logic for Input.xaml
    /// </summary>
    public partial class Input : Window
    {
        Boolean CanClose = false;
        public int Resultado;

        public Input()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !CanClose;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            int Res;
            if (Int32.TryParse(txtNumero.Text, out Res))
            {
                Resultado = Res;
                CanClose = true;
                Close();
            }
        }
    }
}
