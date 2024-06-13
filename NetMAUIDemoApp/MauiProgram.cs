﻿using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using NetMAUIDemoApp.Controls;
using NetMAUIDemoApp.Interfaces;
#if __ANDROID__
using NetMAUIDemoApp.Platforms.Android;
#endif
#if __IOS__
using NetMAUIDemoApp.Platforms.iOS;
#endif
using NetMAUIDemoApp.ViewModels;
using NetMAUIDemoApp.Views.dashboard;

namespace NetMAUIDemoApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).ConfigureMauiHandlers(handlers => {
#if __ANDROID__
                        handlers.AddCompatibilityRenderer(typeof(CustomButton), typeof(NetMAUIDemoApp.CustomRendererAndroid.CustomButtonRenderer));
#endif
                    //#if __IOS__
                    //    handlers.AddCompatibilityRenderer(typeof(CustomButton), typeof(DemoShellNavigation.CustomRendererIOS.CustomButtonRenderer));
                    //#endif
                })
                .UseMauiCompatibility(); ;

                #if __ANDROID__
                    builder.Services.AddSingleton<IDeviceInfoService, DeviceInfoService>();

                #endif
                #if __IOS__
                                    builder.Services.AddSingleton<IDeviceInfoService, DeviceInfoService>();
                #endif


            builder.Services.AddTransient<SettingsPageViewModel>();
            builder.Services.AddTransient<Settings>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
