using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelHulton1.Startup))]
namespace HotelHulton1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
