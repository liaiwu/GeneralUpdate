﻿using GeneralUpdate.Core.Events.OSSArgs;
using GeneralUpdate.Maui.OSS;
using GeneralUpdate.Maui.OSS.Domain.Entity;

namespace TestMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            //http://192.168.50.203/version.json
            string url = "http://192.168.50.203";
            string appName = "MainApplication.exe";
            string currentVersion = "1.1.1.1";
            string versionFileName = "versions.json";
            GeneralUpdateOSS.AddListenerDownloadProcess(OnOSSDownload);
            await GeneralUpdateOSS.Start<Strategy>(new ParamsAndroid(url, appName,"", currentVersion, versionFileName));
        }

        private void OnOSSDownload(object sender, OSSDownloadArgs e)
        {
            Console.WriteLine($"{e.ReadLength},{e.TotalLength}");
        }
    }
}