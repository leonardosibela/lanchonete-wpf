using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lanchonete
{
    public partial class MainWindow : Window
    {
        private const double ValorInicialLanche = 5.00;

        private const double ValorBacon = 5.00;
        private const double ValorAlface = 2.00;
        private const double ValorTomate = 1.50;
        private const double ValorCebolaCaramelizada = 4.00;
        private const double ValorMolhoBarbecue = 3.00;

        private const double ValorQueijoCheddar = 2.00;
        private const double ValorQueijoPrato = 2.00;
        private const double ValorQueijoSuico = 2.00;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSelecionarTodos_Click(object sender, RoutedEventArgs e)
        {
            chkBacon.IsChecked = true;
            chkAlface.IsChecked = true;
            chkTomate.IsChecked = true;
            chkCebolaCaramelizada.IsChecked = true;
            chkMolhoBarbecue.IsChecked = true;

            chkCheddar.IsChecked = true;
            chkPrato.IsChecked = true;
            chkSuico.IsChecked = true;
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            chkBacon.IsChecked = false;
            chkAlface.IsChecked = false;
            chkTomate.IsChecked = false;
            chkCebolaCaramelizada.IsChecked = false;
            chkMolhoBarbecue.IsChecked = false;

            chkCheddar.IsChecked = false;
            chkPrato.IsChecked = false;
            chkSuico.IsChecked = false;

            txtNomeLanche.Text = "";
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (todosEstaoChecados())
            {
                MessageBoxResult resultado = MessageBox.Show(
                    "Tem certeza que deseja colocar todos os ingredientes no seu lanche?",
                    "Lanche muito calórico!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (resultado == MessageBoxResult.No)
                {
                    return;
                }
            }

            double valorDoLanche = obterValorDoLanche();

            MessageBox.Show("O " + txtNomeLanche.Text + " custa " + string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valorDoLanche)); 
        }

        private double obterValorDoLanche()
        {
            double valorTotal = ValorInicialLanche;

            if (chkBacon.IsChecked == true)
            {
                valorTotal += ValorBacon;
            }

            if (chkAlface.IsChecked == true)
            {
                valorTotal += ValorAlface;
            }

            if (chkTomate.IsChecked == true)
            {
                valorTotal += ValorTomate;
            }

            if (chkCebolaCaramelizada.IsChecked == true)
            {
                valorTotal += ValorCebolaCaramelizada;
            }

            if (chkMolhoBarbecue.IsChecked == true)
            {
                valorTotal += ValorMolhoBarbecue;
            }

            if (chkCheddar.IsChecked == true)
            {
                valorTotal += ValorQueijoCheddar;
            }

            if (chkPrato.IsChecked == true)
            {
                valorTotal += ValorQueijoPrato;
            }

            if (chkSuico.IsChecked == true)
            {
                valorTotal += ValorQueijoSuico;
            }

            return valorTotal;
        }

        private bool todosEstaoChecados()
        {
            return
                chkBacon.IsChecked == true &&
                chkAlface.IsChecked == true &&
                chkTomate.IsChecked == true &&
                chkCebolaCaramelizada.IsChecked == true &&
                chkMolhoBarbecue.IsChecked == true &&
                chkCheddar.IsChecked == true &&
                chkPrato.IsChecked == true &&
                chkSuico.IsChecked == true;
        }
    }
}