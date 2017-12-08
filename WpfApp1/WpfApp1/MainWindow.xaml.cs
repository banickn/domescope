using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Net.Http;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IpCamController _controller;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ShowDragMove(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.ScrollAll;
        }

        private void ResetCursor(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void Clicker(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have clicked the clicker!");
        }

        private void exitButton_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _controller = new IpCamController("http://wmccpinetop.axiscam.net", "", "");
            //_controller = new IpCamController("http://96.10.1.168", "","");
            _controller.ImageReady += Dec_FrameReady;
            _controller.StartProcessing();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _controller.StopProcessing();
        }

        void Dec_FrameReady(object sender, ImageReadyEventArgs args)
        {
            imgStream.Source = args.Image;
        }
    }
}
