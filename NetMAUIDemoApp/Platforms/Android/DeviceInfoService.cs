using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.OS;
using NetMAUIDemoApp.Interfaces;
using Microsoft.Maui.Controls.Platform;

namespace NetMAUIDemoApp.Platforms.Android
{
    public class DeviceInfoService : IDeviceInfoService
    {
        public string GetDeviceModel()
        {
            return Build.Model;
        }
    }
}