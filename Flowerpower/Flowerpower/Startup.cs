using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Flowerpower.Startup))]
namespace Flowerpower
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
