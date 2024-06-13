﻿using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Hosting;
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
using System.Security.Cryptography.X509Certificates;

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
                .UseMauiCompatibility()
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews();

            #if DEBUG
                builder.Logging.AddDebug();
            #endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            #if __ANDROID__
                  mauiAppBuilder.Services.AddSingleton<IDeviceInfoService, DeviceInfoService>();

            #endif
            #if __IOS__
                   mauiAppBuilder.Services.AddSingleton<IDeviceInfoService, DeviceInfoService>();
            #endif

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {

            mauiAppBuilder.Services.AddTransient<SettingsPageViewModel>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {

            mauiAppBuilder.Services.AddTransient<Settings>();
            return mauiAppBuilder;
        }
    }
}
