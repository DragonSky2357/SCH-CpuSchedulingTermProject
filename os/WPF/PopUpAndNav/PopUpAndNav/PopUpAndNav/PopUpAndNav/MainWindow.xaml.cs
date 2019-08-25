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
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Windows.Threading;
using Microsoft.VisualBasic;

namespace OS_Project
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Animation_1.Visibility = Visibility.Visible;
            Animation_2.Visibility = Visibility.Collapsed;
            Animation_3.Visibility = Visibility.Collapsed;
            Animation_4.Visibility = Visibility.Collapsed;
            Animation_5.Visibility = Visibility.Collapsed;
        }

        private void ButtonOPenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOPenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void Resion_Data_Click(object sender, RoutedEventArgs e)
        {
            Animation_1.Visibility = Visibility.Collapsed;
            Animation_2.Visibility = Visibility.Visible;
            Animation_3.Visibility = Visibility.Collapsed;
            Animation_4.Visibility = Visibility.Collapsed;
            Animation_5.Visibility = Visibility.Collapsed;
            Process Resion_Data = new Process();
            Resion_Data.StartInfo.FileName = "Resion_Data.exe";
            Resion_Data.Start();
            Resion_Data.WaitForExit();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOPenMenu.Visibility = Visibility.Visible; 
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            Animation_1.Visibility = Visibility.Visible;
            Animation_2.Visibility = Visibility.Collapsed;
            Animation_3.Visibility = Visibility.Collapsed;
            Animation_4.Visibility = Visibility.Collapsed;
            Animation_5.Visibility = Visibility.Collapsed;
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            Animation_1.Visibility = Visibility.Collapsed;
            Animation_2.Visibility = Visibility.Collapsed;
            Animation_3.Visibility = Visibility.Collapsed;
            Animation_4.Visibility = Visibility.Collapsed;
            Animation_5.Visibility = Visibility.Visible;

            if (MessageBox.Show("프로그램을 종료합니다.", "프로그램 종료", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Environment.Exit(0);
        }

        private void Result_Chart_Click(object sender, RoutedEventArgs e)
        {
            Animation_1.Visibility = Visibility.Collapsed;
            Animation_2.Visibility = Visibility.Collapsed;
            Animation_3.Visibility = Visibility.Visible;
            Animation_4.Visibility = Visibility.Collapsed;
            Animation_5.Visibility = Visibility.Collapsed;
        }

        private void Producer_Click(object sender, RoutedEventArgs e)
        {
            Animation_1.Visibility = Visibility.Collapsed;
            Animation_2.Visibility = Visibility.Collapsed;
            Animation_3.Visibility = Visibility.Collapsed;
            Animation_4.Visibility = Visibility.Visible;
            Animation_5.Visibility = Visibility.Collapsed;
            MessageBox.Show("학   과 : 컴퓨터소프트웨어공학과 \n" +
                "제작자 : 강승우 장석준 박용민\n" +
                "제작일 : 2018 - 11 - 25","제작진",MessageBoxButton.OK);

        }

        private void Button_FCFS_Click(object sender, RoutedEventArgs e)
        {
            FileStream InputDataTxt = new FileStream("data.txt", FileMode.Create, FileAccess.Write);
            StreamWriter InputDataWriter = new StreamWriter(InputDataTxt, Encoding.Default);

            InputDataWriter.WriteLine("FCFS");

            InputDataWriter.Close();
            InputDataTxt.Close();
            Process FCFS = new Process();
            FCFS.StartInfo.FileName = "SchedulerMain.exe";
            FCFS.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            FCFS.StartInfo.CreateNoWindow = true;
            FCFS.Start();
            FCFS.WaitForExit();
        }

        private void Button_SJF_Click(object sender, RoutedEventArgs e)
        {
            FileStream InputDataTxt = new FileStream("data.txt", FileMode.Create, FileAccess.Write);
            StreamWriter InputDataWriter = new StreamWriter(InputDataTxt, Encoding.Default);

            InputDataWriter.WriteLine("SJF");

            InputDataWriter.Close();
            InputDataTxt.Close();
            Process FCFS = new Process();
            FCFS.StartInfo.FileName = "SchedulerMain.exe";
            FCFS.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            FCFS.StartInfo.CreateNoWindow = true;
            FCFS.Start();
            FCFS.WaitForExit();
        }

        private void Button_SRT_Click(object sender, RoutedEventArgs e)
        {
            FileStream InputDataTxt = new FileStream("data.txt", FileMode.Create, FileAccess.Write);
            StreamWriter InputDataWriter = new StreamWriter(InputDataTxt, Encoding.Default);

            InputDataWriter.WriteLine("SRT");

            InputDataWriter.Close();
            InputDataTxt.Close();
            Process FCFS = new Process();
            FCFS.StartInfo.FileName = "SchedulerMain.exe";
            FCFS.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            FCFS.StartInfo.CreateNoWindow = true;
            FCFS.Start();
            FCFS.WaitForExit();
        }

        private void Button_NPP_Click(object sender, RoutedEventArgs e)
        {
            FileStream InputDataTxt = new FileStream("data.txt", FileMode.Create, FileAccess.Write);
            StreamWriter InputDataWriter = new StreamWriter(InputDataTxt, Encoding.Default);

            InputDataWriter.WriteLine("NPP");

            InputDataWriter.Close();
            InputDataTxt.Close();
            Process FCFS = new Process();
            FCFS.StartInfo.FileName = "SchedulerMain.exe";
            FCFS.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            FCFS.StartInfo.CreateNoWindow = true;
            FCFS.Start();
            FCFS.WaitForExit();
        }

        private void Button_PP_Click(object sender, RoutedEventArgs e)
        {
            FileStream InputDataTxt = new FileStream("data.txt", FileMode.Create, FileAccess.Write);
            StreamWriter InputDataWriter = new StreamWriter(InputDataTxt, Encoding.Default);

            InputDataWriter.WriteLine("PP");

            InputDataWriter.Close();
            InputDataTxt.Close();
            Process FCFS = new Process();
            FCFS.StartInfo.FileName = "SchedulerMain.exe";
            FCFS.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            FCFS.StartInfo.CreateNoWindow = true;
            FCFS.Start();
            FCFS.WaitForExit();
        }

        private void Button_RR_Click(object sender, RoutedEventArgs e)
        {
            FileStream InputDataTxt = new FileStream("data.txt", FileMode.Create, FileAccess.Write);
            StreamWriter InputDataWriter = new StreamWriter(InputDataTxt, Encoding.Default);

            InputDataWriter.WriteLine("RR");

            InputDataWriter.Close();
            InputDataTxt.Close();
            Process FCFS = new Process();
            FCFS.StartInfo.FileName = "SchedulerMain.exe";
            FCFS.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            FCFS.StartInfo.CreateNoWindow = true;
            FCFS.Start();
            FCFS.WaitForExit();
        }
    }
}
