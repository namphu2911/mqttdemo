using App1.Model;
using MQTTnet;
using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;



namespace App1.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        //private string _data1;
        //public string Data1
        //{
        //    get => _data1;
        //    set
        //    {
        //        _data1 = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public ObservableCollection<MqttModel> _list;

        //public ObservableCollection<MqttModel> List
        //{
        //    get { return _list; }
        //    set
        //    {
        //        _list = value;
        //        OnPropertyChanged();
        //    }
        //}
      
        
        //public ICommand PublishCommand { get; set; }

        //public MainViewModel()
        //{
        //    var mqttFactory = new MqttFactory();
        //    var client = mqttFactory.CreateMqttClient();
        //    var options = new MqttClientOptionsBuilder()
        //                    .WithClientId(Guid.NewGuid().ToString())
        //                    .WithTcpServer("test.mosquitto.org", 8883)
        //                    .WithCleanSession()
        //                    .Build();



        //}

       

    }
}
