using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(kodimax.Startup))]
namespace kodimax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
