using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MSTest.OnlineTradingApp.Startup))]
namespace MSTest.OnlineTradingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
