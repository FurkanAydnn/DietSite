using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCMyProject.Startup))]
namespace MVCMyProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
