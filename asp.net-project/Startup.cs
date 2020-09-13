using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asp.net_project.Startup))]
namespace asp.net_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
