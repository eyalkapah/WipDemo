using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.EnterpriseData;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WipDemo.Helpers;
using WipDemo.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WipDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel Vm => DataContext as MainViewModel;

        public MainPage()
        {
            this.InitializeComponent();

            DataContext = new MainViewModel();
        }

        private async void ProtectFileClick(object sender, RoutedEventArgs e)
        {
            string outputStr = "";

            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            openPicker.FileTypeFilter.Add("*");
            var m_file = await openPicker.PickSingleFileAsync();
            if (m_file != null)
            {
                // Application now has read/write access to the picked file
                outputStr += "\nPicked file: " + m_file.Path;
            }
            else
            {
                outputStr += "\nPlease pick a file";
            }

            FileProtectionInfo procInfo = await FileProtectionManager.GetProtectionInfoAsync(m_file);
            if (procInfo.Status != FileProtectionStatus.Protected)
            {
                outputStr += "\nProtecting File: ";
                await FileProtectionManager.ProtectAsync(m_file, "microsoft.com");
                procInfo = await FileProtectionManager.GetProtectionInfoAsync(m_file);
                outputStr += "\nProtected File: " + m_file.Path + "Status:" + procInfo.Status;
            }
            else
            {
                outputStr += "\nFile protection status is: " + procInfo.Status;
            }
        }
    }
}