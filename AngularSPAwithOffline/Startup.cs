using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularSPAwithOffline.Startup))]
namespace AngularSPAwithOffline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
