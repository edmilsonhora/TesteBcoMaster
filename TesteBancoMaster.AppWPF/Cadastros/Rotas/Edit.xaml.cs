using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TesteBancoMaster.AppWPF.Api;
using TesteBancoMaster.AppWPF.Api.Modelos;
using TesteBancoMaster.AppWPF.Helper;

namespace TesteBancoMaster.AppWPF.Cadastros.Rotas
{
   
    public partial class Edit : UserControl, IMostraDados
    {
        RotaService service;
        public Edit(int id)
        {
            InitializeComponent();
            service = new RotaService();
            MostraDados(id);
           
        }

        public void MostraDados(int id)
        {
            DataContext = service.ObterPor(id);            
        }

        private void btnVoltarParaLista_MouseUp(object sender, MouseButtonEventArgs e)
        {
            VoltarParaList();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RotaView rota = DataContext as RotaView;
                service.Salvar(rota);
                VoltarParaList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }

        }


        private void VoltarParaList()
        {
            MainWindow frm = Window.GetWindow(this) as MainWindow;
            frm.RemoverTela(frm.IncluirTela<List>());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtOrigem.Focus();
        }
    }
}
