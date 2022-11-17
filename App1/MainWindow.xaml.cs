using MQTTnet;
using MQTTnet.Client;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace App1
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
            client.ConnectAsync(options);
            
           
        }

        public async void PublishBtn_Click(object sender, RoutedEventArgs e, IMqttClient client)
        {
            string messagePayload = MessageTb.Text;
            var message = new MqttApplicationMessageBuilder()
                                .WithTopic("RishabhSharma")
                                .WithPayload(messagePayload)
                                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                                .Build();
            if (client.IsConnected)
            {
                await client.PublishAsync(message);
                
            }

        }

        
    }
}
