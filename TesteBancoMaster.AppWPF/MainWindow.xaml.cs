using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TesteBancoMaster.AppWPF.Helper;

namespace TesteBancoMaster.AppWPF
{
   
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnRotas_Click(object sender, RoutedEventArgs e)
        {
            RemoverTela(IncluirTela<Cadastros.Rotas.List>());

        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            RemoverTela(IncluirTela<Cadastros.CustoViagem.Edit>());
        }


        public UserControl IncluirTela<T>(int id = 0) where T : UserControl, IMostraDados
        {           
                UserControl newScreen = (UserControl)Activator.CreateInstance(typeof(T), id);
                newScreen.Height = PanelConteudo.ActualHeight;
                PanelConteudo.Children.Add(newScreen);

                return newScreen;
           

        }

        public void RemoverTela(UserControl itemAtivo)
        {
            var list = PanelConteudo.Children.OfType<UserControl>().ToList();

            foreach (var item in list)
            {                
                if(item != itemAtivo)
                PanelConteudo.Children.Remove(item);
            }

        }

    }
}
