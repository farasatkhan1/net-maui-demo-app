using NetMAUIDemoApp.Views.auth;
using NetMAUIDemoApp.Views.auth.onboarding;

namespace NetMAUIDemoApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("login", typeof(Login));
            Routing.RegisterRoute("signup", typeof(Signup));
            Routing.RegisterRoute("flow1", typeof(SignupFlow1));
            Routing.RegisterRoute("flow2", typeof(SignupFlow2));
        }
    }
}
