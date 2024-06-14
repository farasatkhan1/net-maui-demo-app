using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.LifecycleEvents;
using NetMAUIDemoApp.Controls;
using NetMAUIDemoApp.Interfaces;
#if __ANDROID__
using NetMAUIDemoApp.Platforms.Android;
#endif
#if __IOS__
using NetMAUIDemoApp.Platforms.iOS;
#endif
using NetMAUIDemoApp.ViewModels;
using NetMAUIDemoApp.ViewModels.auth;
using NetMAUIDemoApp.Views.auth;
using NetMAUIDemoApp.Views.dashboard;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Bundled.Shared;
using System.Security.Cryptography.X509Certificates;
using Plugin.Firebase.Crashlytics;
using Plugin.Firebase.Bundled.Platforms.Android;

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
                }).ConfigureMauiHandlers(handlers =>
                {
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
                .RegisterFirebase();

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
            mauiAppBuilder.Services.AddTransient<LoginViewModel>();
            mauiAppBuilder.Services.AddTransient<SignupViewModel>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {

            mauiAppBuilder.Services.AddTransient<Settings>();
            mauiAppBuilder.Services.AddTransient<Login>();
            mauiAppBuilder.Services.AddTransient<Signup>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterFirebase(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyBU01UWZyobEt7vcDfCuDEHXZPOzxLmw4M",
                AuthDomain = "net-maui-demo-app-firebase.firebaseapp.com",
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[] {
                    new EmailProvider()
                },
                UserRepository = new FileUserRepository("PersistedUserFirebaseInformation"),
            }));
            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
        {
            builder.ConfigureLifecycleEvents(events =>
            {
                #if IOS
                            events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) => {
                                CrossFirebase.Initialize(CreateCrossFirebaseSettings());
                                return false;
                            }));
                #else
                                events.AddAndroid(android => android.OnCreate((activity, _) =>
                                CrossFirebase.Initialize(activity, CreateCrossFirebaseSettings())));
                                CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);
                #endif
            });

            builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
            return builder;
        }
        private static CrossFirebaseSettings CreateCrossFirebaseSettings()
        {
            return new CrossFirebaseSettings(isAuthEnabled: true,
            isCloudMessagingEnabled: true, isAnalyticsEnabled: true);
        }
    }
}
