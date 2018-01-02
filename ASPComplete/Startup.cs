using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPComplete.Startup))]
namespace ASPComplete
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
