using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TaskExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Task task1 = new Task(() =>
            {
                UpdateTime(StartTimeLabel);
            });

            task1.Start();
        }

        private void FactoryStartNewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Task task2 = Task.Factory.StartNew(() =>
            {
                UpdateTime(FactoryStartTimeLabel);
            });
        }

        private void UpdateTime(Label label)
        {
            while (true)
            {
                DateTime currentTime = DateTime.Now;
                string time = currentTime.ToString("HH:mm:ss");
                string date = currentTime.ToString("yyyy-MM-dd");

                Dispatcher.Invoke(() =>
                {
                    label.Content = $"Time: {time}, Date: {date}";
                });

                // Sleep for 1 second.
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void TaskRunButton_Click(object sender, RoutedEventArgs e)
        {
            Task task3 = Task.Run(() =>
            {
                UpdateTime(TaskRunTimeLabel);
            });
        }
    }
}
