using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace Coupon_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Current;

        public MainWindow()
        {
            Current = this;
            InitializeComponent();
        }

        void MainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("CouponSetupPage.xaml", UriKind.Relative));
        }

        #region MainWindow Menu
        private void mainWindow_File_New_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentCouponSettings = new CouponSettings();
            mainFrame.NavigationService.Refresh();
        }

        private void mainWindow_File_Open_Click(object sender, RoutedEventArgs e)
        {
            // Load the File
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".coupon";
            dlg.Filter = "Coupon Files (*.coupon) | *.coupon";

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string file = System.IO.File.ReadAllText(dlg.FileName);
                App.CurrentCouponSettings = CouponSettings.JsonToObject(file);
                App.CurrentCouponSettings.SaveLocation = new Uri(dlg.FileName, UriKind.Absolute);
            }

            // Refresh the Page
            mainFrame.NavigationService.Refresh();
        }

        public void mainWindow_File_Save_Click(object sender, RoutedEventArgs e)
        {
            if (App.CurrentCouponSettings.SaveLocation == null)
                mainWindow_File_SaveAs_Click(sender, e);
            else
            {
                string json = App.CurrentCouponSettings.ToJson();

                TextWriter textWriter = new StreamWriter(App.CurrentCouponSettings.SaveLocation.OriginalString, false);
                textWriter.WriteLine(json);
                textWriter.Close();
                textWriter.Dispose();
            }
        }

        private void mainWindow_File_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Coupon";
            dlg.DefaultExt = ".coupon";
            dlg.Filter = "Coupon Files (*.coupon) | *.coupon";
            Nullable<bool> dlgResult = dlg.ShowDialog();

            if (dlgResult == true)
            {
                App.CurrentCouponSettings.SaveLocation = new Uri(dlg.FileName, UriKind.Absolute);
                string json = App.CurrentCouponSettings.ToJson();

                TextWriter textWriter = new StreamWriter(dlg.FileName, false);
                textWriter.WriteLine(json);
                textWriter.Close();
                textWriter.Dispose();
            }
        }

        private void mainWindow_File_Close_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Other
        private void mainWindow_Other_About_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }

        private void mainWindow_Other_Help_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        private void Window_PreviewDragEnter(object sender, DragEventArgs e)
        {
            bool isCorrect = true;

            if (e.Data.GetDataPresent(DataFormats.FileDrop, true) == true)
            {
                string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, true);
                foreach (string filename in filenames)
                {
                    if (File.Exists(filename) == false)
                    {
                        isCorrect = false;
                        break;
                    }
                    FileInfo info = new FileInfo(filename);
                    if (info.Extension != ".coupon")
                    {
                        isCorrect = false;
                        break;
                    }
                }
            }
            if (isCorrect == true)
                e.Effects = DragDropEffects.All;
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, true);
            foreach (string filename in filenames)
                Debug.WriteLine(File.ReadAllText(filename));
            e.Handled = true; 
        }
    }
}
