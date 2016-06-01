using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MsUni.Startup))]
namespace MsUni
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
