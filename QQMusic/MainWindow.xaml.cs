using System;
using System.Collections.Generic;
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

namespace QQMusic
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            init();
        }
        /// <summary>
        /// 拖动界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        void init()
        {
            foreach (Image image in toolCanvas.Children)
            {
                image.MouseEnter += replaceColor;
                image.MouseLeave += huifuColor;
            }
        }
        void replaceColor(object sender,MouseEventArgs e)
        {
            Image image = e.Source as Image;
            BitmapImage bitimage = new BitmapImage();
            bitimage.BeginInit();
            bitimage.UriSource = new Uri(image.Source.ToString().Substring(0,image.Source.ToString().IndexOf('.'))+"green.png");
            bitimage.EndInit();
            image.Source = bitimage;
        }
        void huifuColor(object sender, MouseEventArgs e)
        {
            Image image = e.Source as Image;
            BitmapImage bitimage = new BitmapImage();
            bitimage.BeginInit();
            bitimage.UriSource = new Uri(image.Source.ToString().Substring(0, image.Source.ToString().IndexOf("green")) + ".png");
            bitimage.EndInit();
            image.Source = bitimage;
        }
        //最小化
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //关闭
        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
        //变大
        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            Image image = e.Source as Image;
            BitmapImage bitimage = new BitmapImage();
            bitimage.BeginInit();
            if (this.WindowState == WindowState.Normal)
            {
                bitimage.UriSource = new Uri(@"pack://application:,,,/QQMusic;component/Images/复原.png");
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                bitimage.UriSource = new Uri(@"pack://application:,,,/QQMusic;component/Images/small.png");
                this.WindowState = WindowState.Normal;
            }
            bitimage.EndInit();
            image.Source = bitimage;
        }
    }
}
