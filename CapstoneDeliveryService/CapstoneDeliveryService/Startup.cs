using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CapstoneDeliveryService.Startup))]
namespace CapstoneDeliveryService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
