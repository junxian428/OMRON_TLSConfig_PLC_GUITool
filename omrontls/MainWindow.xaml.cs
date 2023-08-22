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
using Microsoft.Win32;using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using Path = System.IO.Path;

namespace omrontls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                privateKeyTextBox.Text = openFileDialog.FileName;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                awscertTextBox.Text = openFileDialog.FileName;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Show a message box
            //MessageBox.Show( "IP: " + IPAddressTextBox.Text +  
            //    " \nTLS Mode : " +  TLSTextBox.Text +
            //    " \nCert Path : " + awscertTextBox.Text + "\nPrivate Key Path: " +
            //    privateKeyTextBox.Text, "Transfer to PLC");
            //string projectRootPath = AppDomain.CurrentDomain.BaseDirectory;
            //MessageBox.Show("Project Root Path: " + projectRootPath, "Project Root Path", MessageBoxButton.OK, MessageBoxImage.Information);
            //Process.Start(@"Path\To\Your\File.exe");
            // Get the project root path
            // Get the project root path
            string projectRootPath = AppDomain.CurrentDomain.BaseDirectory;

            // Combine with the exe file name
            string exePath = Path.Combine(projectRootPath, "tlsconfig.exe");

            // Provide arguments to the exe
            string arguments = "getAllSessionInfo /ip:" + IPAddressTextBox.Text;

            // Start the exe with arguments
            Process process = new Process();
            process.StartInfo.FileName = exePath;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            // Read and print the process output
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            process.Close();

            // Display the output
            MessageBox.Show(output, "Process Output", MessageBoxButton.OK, MessageBoxImage.Information);


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Get the project root path
            string projectRootPath = AppDomain.CurrentDomain.BaseDirectory;

            // Combine with the exe file name
            string exePath = Path.Combine(projectRootPath, "tlsconfig.exe");

            // Provide arguments to the exe
            string arguments = "delAllSessionInfo /ip:" + IPAddressTextBox.Text;

            // Start cmd.exe with the command
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/C {exePath} {arguments} & pause";
            process.StartInfo.UseShellExecute = false;
            process.Start();

            // Wait for the process to exit (the user closes it)
            process.WaitForExit();


        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            // Show a message box
            MessageBox.Show("IP: " + IPAddressTextBox.Text +
                " \nTLS Mode : " + TLSTextBox.Text +
                " \nCert Path : " + awscertTextBox.Text + "\nPrivate Key Path: " +
                privateKeyTextBox.Text, "Transfer to PLC");




            // Provide arguments to the exe
            //string arguments = "setSessionInfo /id"  +TLSTextBox.Text + " /key '" + privateKeyTextBox.Text + "' /cert '" + awscertTextBox.Text + "'  /ip:" + IPAddressTextBox.Text + " /f";

            // Get the project root path
            string projectRootPath = AppDomain.CurrentDomain.BaseDirectory;

            // Combine with the exe file name
            string exePath = Path.Combine(projectRootPath, "tlsconfig.exe");

            // Provide arguments to the exe
            string arguments = "setSessionInfo /id " + TLSTextBox.Text + " /key \"" + privateKeyTextBox.Text + "\" /cert \"" + awscertTextBox.Text + "\"  /ip:" + IPAddressTextBox.Text + " /f";

            // Start cmd.exe with the command
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/C {exePath} {arguments} & pause";
            process.StartInfo.UseShellExecute = false;
            process.Start();

            // Wait for the process to exit (the user closes it)
            process.WaitForExit();


        }
    }
}
