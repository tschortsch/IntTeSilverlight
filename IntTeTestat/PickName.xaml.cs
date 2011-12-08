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
using System.Windows.Shapes;
using IntTeTestat.ViewModel;

namespace IntTeTestat
{
    public partial class PickName : UserControl
    {
        Frame contentFrame;

        public PickName()
        {
            InitializeComponent();
            contentFrame = ((App)Application.Current).MainPage.ContentFrame;
            DataContext = new GameModel();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new Uri("/WaitPage", UriKind.Relative));
            WebContext.Current.GuessServiceClient.AddNameAsync(nameTextBox.Text);
        }
    }
}
