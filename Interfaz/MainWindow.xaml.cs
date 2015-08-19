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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Arbol;

namespace Interfaz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int Top = 25;
        public const int Left = 400;

        Arbol.Arbol Ar;

        public MainWindow()
        {
            InitializeComponent();
            Ar = new Arbol.Arbol();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Input IP = new Input();
            IP.ShowDialog();
            Ar.Insertar(IP.Resultado);
            Canvas.Children.Clear();
            DibujarNodo(Ar.Raiz, Top, Left);
        }

        private void DibujarNodo(Arbol.Arbol.Nodo Nd, double Top, double Left)
        {
            if (Nd != null)
            {
                Grid Holder = new Grid
                {
                    Width = 50.0,
                    Height = 50.0
                };
                Ellipse Elp = new Ellipse
                {
                    Fill = new SolidColorBrush(Colors.Aqua)
                };
                Holder.Children.Add(Elp);
                TextBlock Txt = new TextBlock
                {
                    Text = Nd.inf.ToString(),
                    Width = 35.0,
                    Height = 35.0,
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Padding = new Thickness(0.0, 8.0, 0.0, 0.0)
                };
                Holder.Children.Add(Txt);
                Holder.SetValue(Canvas.TopProperty, Top);
                Holder.SetValue(Canvas.LeftProperty, Left);
                this.Canvas.Children.Add(Holder);
                this.DibujarNodo(Nd.izq, Top + 50.0, Left - 50.0);
                this.DibujarNodo(Nd.der, Top + 50.0, Left + 50.0);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Input IP = new Input();
            IP.ShowDialog();
            if (Ar.Eliminar(IP.Resultado))
            {
                Canvas.Children.Clear();
                this.DibujarNodo(Ar.Raiz, Top, Left);
            }
            else
            {
                MessageBox.Show("No se ha eliminado el dato.\nPuede que el dato en cuestion no exista\no sea la raiz.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Ar.Limpiar();
            Canvas.Children.Clear();
        }

        private void btnEnOrden_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Ar.EnOrden(Ar.Raiz), "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnPosOrden_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Ar.PosOrden(Ar.Raiz), "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnPreOrden_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Ar.PreOrden(Ar.Raiz), "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnAcerca_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hecho por\nLuisa Restrepo\n  - 201020004010", "Creditos", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
