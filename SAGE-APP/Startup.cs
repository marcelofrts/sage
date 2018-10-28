using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SAGE_APP.Startup))]
namespace SAGE_APP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
