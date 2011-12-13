﻿using System;
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
    public partial class PickName : Page
    {
        Frame contentFrame;

        public PickName()
        {
            InitializeComponent();
            contentFrame = ((App)Application.Current).MainPage.ContentFrame;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new Uri("/WaitPage", UriKind.Relative));
            WebContext.Current.GuessServiceClient.AddNameAsync(nameTextBox.Text);
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new Uri("/Welcome", UriKind.Relative));
        }

        private void nameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (nameTextBox.Text != "")
            {
                btnPlay.IsEnabled = true;
            }
            else
            {
                btnPlay.IsEnabled = false;
            }
        }

    }
}
