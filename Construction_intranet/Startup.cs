using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Construction_intranet.Startup))]
namespace Construction_intranet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
