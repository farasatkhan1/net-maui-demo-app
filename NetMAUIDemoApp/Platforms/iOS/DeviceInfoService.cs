using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMAUIDemoApp.Interfaces;

namespace NetMAUIDemoApp.Platforms.iOS
{
    public class DeviceInfoService : IDeviceInfoService
    {
        public string GetDeviceModel()
        {
            return UIKit.UIDevice.CurrentDevice.Model;
        }
    }
}
