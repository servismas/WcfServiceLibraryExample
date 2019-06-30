using ChatClientWPF.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
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

namespace ChatClientWPF
{
    public class CallbackHandler : IContractCallback
    {
        public void ClientMethod(string msg)
        {
            MessageBox.Show("Server answer: " + msg); ;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }
        public void Connect()
        {
            ContractClient client = new ContractClient(new InstanceContext(new CallbackHandler()));
            client.Connect("Grisha");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Connect();
        }
    }
}
