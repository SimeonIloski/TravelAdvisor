using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TripAdvisor.Startup))]
namespace TripAdvisor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
