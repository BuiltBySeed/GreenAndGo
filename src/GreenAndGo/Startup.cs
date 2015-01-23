using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreenAndGo.Startup))]
namespace GreenAndGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
