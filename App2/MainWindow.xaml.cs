using MQTTnet;
using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace App2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> MQMessage = new ObservableCollection<string>();
        public MainWindow()
        {

            InitializeComponent();
            MQResultList.ItemsSource = MQMessage;

            var mqttFactory = new MqttFactory();
            IMqttClient client = mqttFactory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                                          .WithTcpServer("test.mosquitto.org", 8883)
                                          .WithClientId(Guid.NewGuid().ToString())
                                          .WithCleanSession(true)
                                          .Build();
            
            var topicFilter = new MqttTopicFilterBuilder()
                                        .WithTopic("RishabhSharma")
                                        .Build();
            client.SubscribeAsync(topicFilter);
            client.ConnectAsync(options);
            
            
        }
        private void MqttClient_MessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("MQTT MessageReceived!");
            str.AppendLine($"Content Type : {e.ApplicationMessage.ContentType}");
            str.AppendLine($"Payload : {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            string message = str.ToString();
        }
    }
}
