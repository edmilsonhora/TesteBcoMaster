using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TesteBancoMaster.AppWPF.Api;
using TesteBancoMaster.AppWPF.Api.Modelos;
using TesteBancoMaster.AppWPF.Helper;

namespace TesteBancoMaster.AppWPF.Cadastros.Rotas
{
  
    public partial class List : UserControl, IMostraDados
    {
        RotaService service;
        public List(int id = 0)
        {
            InitializeComponent();
            service = new RotaService();
            MostraDados();

        }
        public void MostraDados(int id = 0)
        {
            var p = service.ObterTodos();
            gridList.ItemsSource = p;
        }



        private void BtnEdit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (gridList.CurrentCell.Column.Header.ToString() == "Edit")
            {
                var item = gridList.CurrentItem as RotaView;
                MostrarEdit(item.Id);
            }
        }


        private void MostrarEdit(int id = 0)
        {
            MainWindow frm = Window.GetWindow(this) as MainWindow;
            frm.RemoverTela(frm.IncluirTela<Edit>(id));
        }

        private void BtnDel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (gridList.CurrentCell.Column.Header.ToString() == "Del")
            {
                if (MessageBox.Show("Tem certeza que deseja excluir o item?", "Confirma Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes) return;

                try
                {
                    var item = gridList.CurrentItem as RotaView;
                    service.Excluir(item.Id);
                    MostraDados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            MostrarEdit();
        }
    }
}
