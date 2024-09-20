using System.ComponentModel;
using System.Data;
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
using System.Xml.Serialization;

namespace mvvm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker? worker;
        public ProgressbarProgress? temp;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addObject(object sender, RoutedEventArgs e)//add class progressbarprogress to datagrid
        {
            progressBarDataGrid.Items.Add(temp = new ProgressbarProgress { progress = 0 });
        }

        private void Button_Click(object sender, RoutedEventArgs e)//button to start thread work per object
        {
            ProgressbarProgress fill = (ProgressbarProgress)progressBarDataGrid.CurrentItem;

            worker = new BackgroundWorker();
            worker.DoWork += StartIncreaseCount;
            worker.RunWorkerAsync(argument: fill);
        }

        private void StartIncreaseCount(object sender, DoWorkEventArgs e)//start method for worker
        {
            increaseCount((ProgressbarProgress)e.Argument);
        }

        private void increaseCount(ProgressbarProgress fill)//change calue for progress
        {
            while (fill.progress < 100)
            {
                Thread.Sleep(1000);
                fill.progress++;
                refreshGridFunction();
            }
        }

        private void refreshDatgrid(object sender, RoutedEventArgs e)//Manual refresh button
        {
            refreshGridFunction();   
        }

        private void refreshGridFunction()
        {
            this.Dispatcher.Invoke(new Action(() => { progressBarDataGrid.Items.Refresh(); }));
        }
    }
}