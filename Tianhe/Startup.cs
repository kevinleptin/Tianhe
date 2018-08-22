using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tianhe.Startup))]
namespace Tianhe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
