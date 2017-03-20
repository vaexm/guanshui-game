using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace guanshui
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //定义了一个代表左上角四个管子的数组。
        PicReady[] picready = new PicReady[4];
        Fields []field=new Fields[49];
        Random r = new Random();
        Canvas canPicReady;
        Image img_pro_back;
        Image img_pro_cover;
        DispatcherTimer dt = new DispatcherTimer();
        Image neck;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += new EventHandler(dt_Tick);
        }

        bool isTimeOver = false;
        void dt_Tick(object sender, EventArgs e)
        {
            img_pro_cover.Height += 2;
            if(img_pro_cover.Height>=img_pro_back.Height)
            {
                dt.Stop();
                isTimeOver = true;
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            back.Children.Remove(button1);
            ShowProgressbar();
            dt.Start();
            for (int i = 0; i < picready.Length; i++)
            {
                picready[i] = new PicReady(r.Next(1, 12));
            }
            canPicReady = new Canvas();
            canPicReady.Width =  280;
            canPicReady.Height = 60;
            Canvas.SetLeft(canPicReady, 0);
            Canvas.SetTop(canPicReady, 0);

            back.Children.Add(canPicReady);
            for (int i = 0; i < picready.Length; i++)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("images/Ready/" + picready[i].PicNum + ".jpg", UriKind.Relative));
                img.Width = img.Height = 60;
                img.Stretch = Stretch.Fill;
                canPicReady.Children.Add(img);

                Canvas.SetLeft(img, i * (img.Width + 5));
                Canvas.SetTop(img, 0);
            }
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = new Fields(i);
                Image img1 = new Image();
                //下面这行代码告诉了这块地它所对应的是哪个元素
                img1.Tag = i;
                img1.Source = new BitmapImage(new Uri("images/cover.jpg", UriKind.Relative));
                img1.Width = img1.Height = 50;
                img1.Stretch = Stretch.Fill;
                img1.MouseLeftButtonDown += new MouseButtonEventHandler(img1_MouseLeftButtonDown);
                back.Children.Add(img1);
                Canvas.SetLeft(img1, i % 7 * img1.Width + (int)back.Width / 2 - (int)7 * img1.Width / 2);
                Canvas.SetTop(img1, i / 7 * img1.Height + (int)back.Height / 2 - (int)7 * img1.Height / 2 + 60);
                //提前将这个图片跟与这个图片对应的其他属性的field数组元素绑定在一起。
                //作用：灌水的时候直接调用当前数组元素绑定的图片直接改变他的Source就可以将其改变成H开头的图片了
                field[i].ClickImage = img1;
                if (i == 3)
                {
                    //添加脖子
                    neck = new Image();
                    neck.Width = img1.Width;
                    neck.Height = img1.Height/2;
                    neck.Stretch = Stretch.Fill;
                    neck.Source = new BitmapImage(new Uri("images/Ready/10.jpg", UriKind.Relative));
                    back.Children.Add(neck);
                    Canvas.SetLeft(neck, i % 7 * img1.Width + (int)back.Width / 2 - (int)7 * img1.Width / 2);
                    Canvas.SetTop(neck, i / 7 * img1.Height + (int)back.Height / 2 - (int)7 * img1.Height / 2 + 60 - neck.Height);
                    //添加水槽
                    Image waterpool = new Image();
                    waterpool.Width = 100;
                    waterpool.Height = 50;
                    waterpool.Stretch = Stretch.Fill;
                    waterpool.Source = new BitmapImage(new Uri("images/Water.jpg", UriKind.Relative));
                    waterpool.MouseLeftButtonDown += new MouseButtonEventHandler(waterpool_MouseLeftButtonDown);
                    back.Children.Add(waterpool);
                    Canvas.SetLeft(waterpool, Canvas.GetLeft(neck) - waterpool.Width / 2 + neck.Width / 2);
                    Canvas.SetTop(waterpool, Canvas.GetTop(neck) - waterpool.Height);
                }
            }
        }
        //显示进度条
        void ShowProgressbar()
        {
            img_pro_back = new Image();
            img_pro_back.Width = 15;
            img_pro_back.Height = 360;
            img_pro_back.Stretch = Stretch.UniformToFill;
            img_pro_back.Source = new BitmapImage(new Uri("images/pro_back.png",UriKind.Relative));
            Canvas.SetLeft(img_pro_back, 600);
            Canvas.SetTop(img_pro_back, 50);
            back.Children.Add(img_pro_back);

            img_pro_cover = new Image();
            img_pro_cover.Height = 0;
            img_pro_cover.Width = 15;
            img_pro_cover.Stretch = Stretch.Fill;
            img_pro_cover.Source = new BitmapImage(new Uri("images/pro_cover.png",UriKind.Relative));
            Canvas.SetTop(img_pro_cover,50);
            Canvas.SetLeft(img_pro_cover,600);
            back.Children.Add(img_pro_cover);
           
        }
        void waterpool_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //开始灌水
            neck.Source = new BitmapImage(new Uri("images/Water/H10.jpg",UriKind.Relative));
            if(field[3].PicReady.IsOpenT)
            {
                //开始用递归算法，该算法已经确定可以灌水的地号，马上把该地对应的图片换成H开头的
                Waterfield(3);
            }
        }
        void Waterfield(int fieldIndex)
        { 
            if(field[fieldIndex].IsWater)
            {
                return;
            }
            field[fieldIndex].ClickImage.Source = new BitmapImage(new Uri("images/Water/H"+field[fieldIndex].PicReady.PicNum+".jpg",UriKind.Relative));
            field[fieldIndex].IsWater = true;
            //已经处理了当前这块地的图片了，现在该以这块地为中心，向四周蔓延
            //判断上面那块地能不能被灌水
            if (field[fieldIndex].PicReady.IsOpenT && field[fieldIndex].IsLinkT && field[fieldIndex - 7].PicReady.IsOpenB)
            {
                Waterfield(fieldIndex - 7);
            }
            if (field[fieldIndex].PicReady.IsOpenB && field[fieldIndex].IsLinkB && field[fieldIndex + 7].PicReady.IsOpenT)
            {
                Waterfield(fieldIndex + 7);
            }
            if (field[fieldIndex].PicReady.IsOpenL && field[fieldIndex].IsLinkL && field[fieldIndex - 1].PicReady.IsOpenR)
            {
                Waterfield(fieldIndex - 1);
            }
            if (field[fieldIndex].PicReady.IsOpenR && field[fieldIndex].IsLinkR && field[fieldIndex + 1].PicReady.IsOpenL)
            {
                Waterfield(fieldIndex + 1);
            }
             
        }
        void img1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isTimeOver)
            {
                //开始铺管子
                Image clickField = sender as Image;
                if (!field[int.Parse(clickField.Tag.ToString())].IsCover)
                {
                    field[int.Parse(clickField.Tag.ToString())].IsCover = true;
                    field[int.Parse(clickField.Tag.ToString())].PicReady = picready[3];
                    field[int.Parse(clickField.Tag.ToString())].ClickImage.Source = new BitmapImage(new Uri("images/Ready/" + field[int.Parse(clickField.Tag.ToString())].PicReady.PicNum + ".jpg", UriKind.Relative));
                }
                //铺完一块地开始更换左上角四个图片的对应的属性还有图片，最后重新生成最左边的那张图片及其属性
                picready[3] = picready[2];
                picready[2] = picready[1];
                picready[1] = picready[0];
                picready[0] = new PicReady(r.Next(1, 12));
                int num = 0;
                foreach (Image img1 in canPicReady.Children)
                {
                    img1.Source = new BitmapImage(new Uri("images/Ready/" + picready[num].PicNum + ".jpg", UriKind.Relative));
                    num++;
                }
            }
            else { }
            
           
        }
        
        //关闭按钮
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        

       
    }
}
