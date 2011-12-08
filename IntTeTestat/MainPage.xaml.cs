using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using IntTeTestat.GuessServiceReference;
using IntTeTestat.ViewModel;

namespace IntTeTestat
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            WebContext.Current.GuessServiceClient.StartGameReceived += OnStartGameReceived;

            WebContext.Current.GuessServiceClient.PlayerGuessReceived += new EventHandler<PlayerGuessReceivedEventArgs>(GuessServiceClient_PlayerGuessReceived); 
            ContentFrame.Navigate(new Uri("/Welcome", UriKind.Relative));
        }

        void GuessServiceClient_PlayerGuessReceived(object sender, PlayerGuessReceivedEventArgs e)
        {
            //e.guess
        }

       
        private void OnStartGameReceived(object sender, StartGameReceivedEventArgs e)
        {

        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }



    /// <summary>
    /// Add GuessServiceClient to WebContext
    /// </summary>
    public sealed partial class WebContext
    {
        private GuessServiceClient _proxy;
        public GuessServiceClient GuessServiceClient
        {
            get
            {
                
                if (_proxy == null)
                {
                    EndpointAddress address = new EndpointAddress("http://localhost:1701/GuessService.svc");
                    PollingDuplexHttpBinding binding = new PollingDuplexHttpBinding();
                    _proxy = new GuessServiceClient(binding, address);
                    _proxy.ConntectAsync();
                }
                return _proxy;
            }
        }
    }
}
