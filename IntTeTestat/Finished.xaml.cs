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
using System.Windows.Navigation;

namespace IntTeTestat
{
    public partial class Finished : Page
    {
        Frame contentFrame;

        public Finished()
        {
            InitializeComponent();
            contentFrame = ((App)Application.Current).MainPage.ContentFrame;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void playAgainButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new Uri("/Welcome", UriKind.Relative));
        }

    }
}
