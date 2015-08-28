using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GitDeployWebApp.Startup))]
namespace GitDeployWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
