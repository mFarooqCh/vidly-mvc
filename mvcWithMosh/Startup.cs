using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcWithMosh.App_Start.Startup))]
namespace mvcWithMosh.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
