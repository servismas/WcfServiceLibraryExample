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
    public partial class MainWindow : Window, IContractCallback 
    {
        bool isConnected = false;
        ContractClient client;
        int id;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btConDiscon_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                DisconnectUser();
            }
            else ConnectUser();
        }
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (client != null)
            {
                client.SendMess(tbMessage.Text, id);
                tbMessage.Text = "";
            }
        }

        void ConnectUser()
        {
            if (!isConnected)
            {
                client = new ContractClient(new InstanceContext(this));
                btConDiscon.Content = "Disconnect";
                isConnected = true;
                tbUserName.IsEnabled = false;
                id = client.Connect(tbUserName.Text);
            }
        }
        void DisconnectUser()
        {
            if (isConnected)
            {
                client.Disconnect(id);
                tbUserName.IsEnabled = true;
                client = null;
                btConDiscon.Content = "Connect";
                isConnected = false;
            }
        }

        public void ClientMethod(string msg)
        {
            lbMessages.Items.Add(msg);
            lbMessages.ScrollIntoView(lbMessages.Items[lbMessages.Items.Count - 1]);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }
    }
}
