using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBandTour.Startup))]
namespace MyBandTour
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
