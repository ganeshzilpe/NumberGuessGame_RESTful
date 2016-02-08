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
using System.Text;
using System.Collections.Specialized;
using System.Windows.Media;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        public static int secretNumber = -1;
        public static int numberOfAttempts = 0;
        public MainPage()
        {
            InitializeComponent();
            myStoryboard.Begin();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            string UriPath = "http://localhost:50909/Service1.svc/checkSecret/" + GuessTextbox.Text.Trim() + "/" + secretNumber;
            
            WebClient client = new WebClient();
            client.DownloadStringCompleted += (s, ev) =>
            {
                Error.Content = "";
                try
                {
                    Result.Content = "The Number is :" + ev.Result;
                }
                catch
                {
                    MessageBox.Show("Internet Connection problem");
                    return;
                }
                numberOfAttempts++;
                Attempts.Content = "Attempts: " + numberOfAttempts;

                SolidColorBrush mySolidColorBrush = new SolidColorBrush();

                if (!ev.Result.Contains("correct"))
                {
                    mySolidColorBrush.Color = Color.FromArgb(150, 220, 20, 60);
                }
                else
                {
                    mySolidColorBrush.Color = Color.FromArgb(150, 0, 201, 87);
                }
                ellipse1.Fill = mySolidColorBrush;
            };
            client.DownloadStringAsync(new Uri(UriPath));
        }
        

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            string UriPath = "http://localhost:50909/Service1.svc/generateSecret/" + LowerLimitTextbox.Text.Trim() + "/" + UpperLimitTextbox.Text.Trim();
            WebClient client = new WebClient();

            client.DownloadStringCompleted += (s, ev) =>
            {
                try
                {
                    Console.WriteLine("*************Im here********");
                    secretNumber = Int32.Parse(ev.Result);
                    Error.Content ="Secret Number is generated";
                    numberOfAttempts = 0;
                    GuessTextbox.Text = "";
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Internet Connection problem or Entered data is not numbers");
                    return;
                }
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = Color.FromArgb(150, 30, 144, 255);
                ellipse1.Fill = mySolidColorBrush;
            };
            client.DownloadStringAsync(new Uri(UriPath));
        }
    }
}
