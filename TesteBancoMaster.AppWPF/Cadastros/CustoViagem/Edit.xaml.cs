using System;
using System.Windows;
using System.Windows.Controls;
using TesteBancoMaster.AppWPF.Api;
using TesteBancoMaster.AppWPF.Api.Modelos;
using TesteBancoMaster.AppWPF.Helper;

namespace TesteBancoMaster.AppWPF.Cadastros.CustoViagem
{
   
    public partial class Edit : UserControl, IMostraDados
    {
        RotaService service;
        public Edit(int id = 0)
        {
            InitializeComponent();
            service = new RotaService();
            MostraDados(id);
        }

        public void MostraDados(int id)
        {
            DataContext = new ViagemView();
            panelResultado.Visibility = Visibility.Hidden;
             
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                panelResultado.Visibility = Visibility.Hidden;
                ViagemView viagem = DataContext as ViagemView;
                txtReultado.Text = service.CalcularMenorCustoPara(viagem);
                panelResultado.Visibility = Visibility.Visible;               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtOrigem.Focus();
        }
    }
}
