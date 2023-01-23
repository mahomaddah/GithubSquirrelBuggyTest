using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Squirrel;

namespace GithubSquirrelBuggyTest
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TBversion.Text = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;
            TBversion.IsEnabled = false;
            checkForUpdateSquirrel();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            checkForUpdateSquirrel();
        }

        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("your verions is up to date...");
        }

        async void checkForUpdateSquirrel()
        {
            try
            {
                using (var manager= await UpdateManager.GitHubUpdateManager("https://github.com/mahomaddah/GithubSquirrelBuggyTest")) 
                {
                    var relese = await manager.UpdateApp();
                    //UpdateManager.RestartApp();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Unable to check for Updates!\n\n"+ee.Message);
            }
        }
    }
}
